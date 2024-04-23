// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Infrastructure.Helpers;
using Forum.Application.Users.Models.ResponseModels;

namespace Forum.Application.Users.AdminServices
{
    public interface IAdminService
    {
        Task BlockUser(string userId);
        Task<PagedList<UserResponseModelForAdmin>> GetAllUser(int pageNumber, int pageSize, CancellationToken cancellationToken);
        Task UnBlockUser(string userId);
    }
}
