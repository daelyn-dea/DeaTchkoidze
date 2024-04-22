// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Helpers;
using Forum.Application.Topics.ResponseModels;
using Forum.Domain.Topics;

namespace Forum.Application.Topics
{
    public interface ITopicRepository
    {
        Task<PagedList<TopicWithCommentCount>> GetAllTopicsForUserAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
        Task<PagedList<Topic>?> GetTopicAsync(int pageNumber, int pageSize, int id, CancellationToken cancellationToken);
        Task<PagedList<Topic>?> GetTopicForAdminAsync(int pageNumber, int pageSize, int id, CancellationToken cancellationToken);
        Task<Topic?> GetAsync(CancellationToken cancellationToken, params object[] key);
        Task<PagedList<TopicWithCommentCount>> GetAllTopicsForAdminAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
        Task CreateTopicAsync(Topic topic, CancellationToken cancellationToken);
        Task<bool> Exists(int id, CancellationToken cancellationToken);
        Task<bool> ExistsTopic(int id, CancellationToken cancellationToken);
        Task<bool> CanDelete(int id, string userId, CancellationToken cancellationToken);
        Task UpdateAsync(Topic topic, CancellationToken cancellationToken);
        void InactivateTopic();
    }
}
