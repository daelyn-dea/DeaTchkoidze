// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Infrastructure.Helpers;
using Forum.Application.Users.Interfaces;
using Forum.Application.Users.Models.ResponseModels;
using Forum.Domain.Users;
using Forum.Infrastructure.BaseRepository;
using Forum.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Forum.Infrastructure.Users
{
    public class AdminRepository : BaseRepository<User>, IAdminRepository
    {
        public AdminRepository(ForumContext context) : base(context)
        {

        }
        public async Task<PagedList<UserSummary>> GetAllUser(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var skipCount = (pageNumber - 1) * pageSize;

            var users = await _dbSet
                .OrderBy(user => user.CreatedAt)
                .Skip(skipCount)
                .Take(pageSize)
                .Select(user => new UserSummary
                {
                    UserEntity = user,
                    TotalComments = user.Comments!.Count(),
                    TotalTopics = user.Topics!.Count()
                })
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            var totalCount = await _context.Users
            .CountAsync(cancellationToken).ConfigureAwait(false);

            var pagedList = new PagedList<UserSummary>(users, totalCount, pageNumber, pageSize);

            return pagedList;
        }
    }
}
