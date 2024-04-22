// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Helpers;
using Forum.Application.Users.Models.ResponseModels;

namespace Forum.Application.Users
{
    public interface IUserRepository
    {
        Task<PagedList<UserTopicsSummary>> GetUserAsync(int pageNumber, int pageSize, string email, CancellationToken cancellationToken);
        Task<PagedList<UserTopicsSummary>> GetUserByNameAsync(int pageNumber, int pageSize, string userName, CancellationToken cancellationToken);
        Task<PagedList<UserSummary>> GetAllUser(int pageNumber, int pageSize, CancellationToken cancellationToken);
        Task<bool> AccessOfPostTopic(string userId, CancellationToken cancellationToken);
        Task BlockExpiration(CancellationToken cancellationToken);
    }
}
