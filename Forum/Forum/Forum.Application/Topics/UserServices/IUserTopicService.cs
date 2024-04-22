// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Helpers;
using Forum.Application.Topics.RequestModels;
using Forum.Application.Topics.ResponseModels;

namespace Forum.Application.Topics.UserServices
{
    public interface IUserTopicService
    {
        Task<PagedList<UserTopicDetailsModel>> GetAllTopicsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
        Task<PagedList<ImagedTopicModel>> GetTopicAsync(int pageNumber, int pageSize, string id, CancellationToken cancellationToken);
        Task CreateTopicAsync(TopicRequestModel topic, string id,  CancellationToken cancellationToken);
        Task<bool> CanDelete(int id, string userId, CancellationToken cancellationToken);
        Task<bool> ExistsTopic(int id, CancellationToken cancellationToken);
        void InactivateTopic();
    }
}
