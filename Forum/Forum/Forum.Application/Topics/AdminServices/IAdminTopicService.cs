// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Infrastructure.Helpers;
using Forum.Application.Topics.ResponseModels;
using static Forum.Application.Topics.ResponseModels.TopicResponseStateEnum;
using static Forum.Domain.Topics.TopicStatusEnum;

namespace Forum.Application.Topics.AdminServices
{
    public interface IAdminTopicService
    {
        Task<PagedList<AdminTopicDetailsModel>> GetAllTopicsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
        Task<PagedList<AdminImagedTopicModel>> GetTopicAsync(int pageNumber, int pageSize, string id, CancellationToken cancellationToken);
        Task ChangeState(string topicId, TopicState state, CancellationToken cancellationToken);
        Task ChangeStatus(string topicId, TopicStatus status, CancellationToken cancellationToken);
    }
}
