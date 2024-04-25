// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Infrastructure.Helpers;
using Forum.Application.Topics.ResponseModels;
using Forum.Domain.Topics;

namespace Forum.Application.Topics.Interfaces
{
    public interface IUserTopicRepository
    {
        Task<PagedList<TopicWithCommentCount>> GetAllTopicsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
        Task<PagedList<Topic>?> GetTopicAsync(int pageNumber, int pageSize, int id, CancellationToken cancellationToken);    
        Task CreateTopicAsync(Topic topic, CancellationToken cancellationToken);
        Task<bool> ExistsTopic(int id, CancellationToken cancellationToken);
        Task<bool> CanDelete(int id, string userId, CancellationToken cancellationToken);
    }
}
