// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Infrastructure.Helpers;
using Forum.Application.Users.Models.ResponseModels;
using Forum.Application.Users.Models.UpdateModel;
using System.Security.Claims;

namespace Forum.Application.Users.UserServices
{
    public interface IUserService
    {
        Task UpdateUserInfo(UpdateModel updateModel, ClaimsPrincipal claimsPrincipal, CancellationToken cancellationToken);
        Task UpdatePassword(UpdatePassword password, ClaimsPrincipal claimsPrincipal);
        Task<PagedList<UserWithTopics>> GetUserAsync(int pageNumber, int pageSize, string email, CancellationToken cancellationToken);
        Task<PagedList<UserWithTopics>> GetUserByNameAsync(int pageNumber, int pageSize, string userName, CancellationToken cancellationToken);
        Task<UserAccountModel> GetProfileOfUserAsync(ClaimsPrincipal claimsPrincipal, CancellationToken cancellationToken);
        Task<bool> AccessOfPostTopic(string userId, CancellationToken cancellationToken);
        Task DeleteProfilePicture(ClaimsPrincipal claimsPrincipal);
    }
}
