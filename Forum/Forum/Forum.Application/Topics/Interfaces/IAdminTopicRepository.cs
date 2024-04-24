// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Infrastructure.Helpers;
using Forum.Application.Topics.ResponseModels;
using Forum.Domain.Topics;

namespace Forum.Application.Topics.Interfaces
{
    public interface IAdminTopicRepository
    {
        Task<PagedList<Topic>?> GetTopicAsync(int pageNumber, int pageSize, int id, CancellationToken cancellationToken);
        Task<PagedList<TopicWithCommentCount>> GetAllTopicAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
        Task<Topic?> GetAsync(CancellationToken cancellationToken, params object[] key);
        Task UpdateAsync(Topic topic, CancellationToken cancellationToken);
        Task<bool> Exists(int id, CancellationToken cancellationToken);
    }
}
