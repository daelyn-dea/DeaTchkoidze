// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Infrastructure.Helpers;
using Forum.Application.Users.Models.ResponseModels;

namespace Forum.Application.Users.Interfaces
{
    public interface IAdminRepository
    {
        Task<PagedList<UserSummary>> GetAllUser(int pageNumber, int pageSize, CancellationToken cancellationToken);
    }
}
