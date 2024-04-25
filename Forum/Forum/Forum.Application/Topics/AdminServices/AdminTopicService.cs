// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Infrastructure.Exceptions;
using Forum.Application.Infrastructure.Helpers;
using Forum.Application.Topics.Interfaces;
using Forum.Application.Topics.ResponseModels;
using HashidsNet;
using Mapster;
using static Forum.Application.Topics.ResponseModels.TopicResponseStateEnum;
using static Forum.Domain.Topics.TopicStateEnum;
using static Forum.Domain.Topics.TopicStatusEnum;

namespace Forum.Application.Topics.AdminServices
{
    internal class AdminTopicService : IAdminTopicService
    {
        private readonly IAdminTopicRepository _topicRepository;
        private readonly IHashids _hashIds;

        public AdminTopicService(IAdminTopicRepository topicRepository, IHashids hashIds)
        {
            _topicRepository = topicRepository;
            _hashIds = hashIds;
        }

        public async Task<PagedList<AdminTopicDetailsModel>> GetAllTopicsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            if (pageNumber <= 0)
                throw new PageNotFoundException();

            var result = await _topicRepository
                .GetAllTopicAsync(pageNumber, pageSize, cancellationToken)
                .ConfigureAwait(false);

            if (pageNumber > result.TotalPages)
                throw new PageNotFoundException();

            return result.Adapt<PagedList<AdminTopicDetailsModel>>();
        }
        public async Task ChangeState(string id, TopicState state, CancellationToken cancellationToken)
        {
            var topicId = await GetTopicId(id, cancellationToken).ConfigureAwait(false);

            var topic = await _topicRepository.GetAsync(cancellationToken, topicId).ConfigureAwait(false);

            if (topic == null)
                throw new TopicNotFoundException();

            topic.State = state switch
            {
                TopicState.Show => DbTopicState.Show,
                TopicState.Hide => DbTopicState.Hide,
                _ => DbTopicState.Pending,
            };

            await _topicRepository.UpdateAsync(topic!, cancellationToken).ConfigureAwait(false);
        }

        public async Task ChangeStatus(string id, TopicStatus status, CancellationToken cancellationToken)
        {
            var topicId = await GetTopicId(id, cancellationToken).ConfigureAwait(false);

            var topic = await _topicRepository.GetAsync(cancellationToken, topicId).ConfigureAwait(false);

            if (topic == null)
                throw new TopicNotFoundException();

            if(topic.Status == status)
                throw new TopicNotFoundException();

            topic.Status = status;

            await _topicRepository.UpdateAsync(topic!, cancellationToken).ConfigureAwait(false);
        }
        public async Task<PagedList<AdminImagedTopicModel>> GetTopicAsync(int pageNumber, int pageSize, string id, CancellationToken cancellationToken)
        {
            if (pageNumber <= 0)
                throw new PageNotFoundException();

            var topicId = DecodeAndValidateTopicId(id);
            var topicForResponse = await _topicRepository.GetTopicAsync(pageNumber, pageSize, topicId, cancellationToken).ConfigureAwait(false);

            if (topicForResponse!.Item == null)
                throw new TopicNotFoundException();

            if (pageNumber > topicForResponse.TotalPages)
                throw new PageNotFoundException();

            return topicForResponse!.Adapt<PagedList<AdminImagedTopicModel>>();
        }
        private int DecodeAndValidateTopicId(string id)
        {
            var intIds = _hashIds.Decode(id);
            if (intIds.Length == 0)
            {
                throw new TopicNotFoundException();
            }
            return intIds[0];
        }
        private async Task<int> GetTopicId(string id, CancellationToken cancellationToken)
        {
            var intIds = _hashIds.Decode(id);
            if (intIds.Length == 0)
            {
                throw new TopicNotFoundException();
            }
            var topicId = intIds[0];

            var exist = await _topicRepository.Exists(topicId, cancellationToken).ConfigureAwait(false);
            if (!exist)
                throw new TopicNotFoundException();
            return topicId;
        }
    }
}
