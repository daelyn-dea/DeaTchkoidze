// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Users.Interfaces;
using Forum.Domain.Users;
using Forum.Infrastructure.BaseRepository;
using Forum.Persistence.Context;
using Microsoft.Extensions.Configuration;

namespace Forum.Infrastructure.Users
{
    public class WorkerUserRepository : BaseRepository<User>, IWorkerUserRepository
    {
        private readonly IConfiguration _configuration;
        public WorkerUserRepository(ForumContext context, IConfiguration configuration) : base(context)
        {
            _configuration = configuration;
        }
        public async Task BlockExpiration(CancellationToken cancellationToken)
        {
            var expirationTime = _configuration.GetValue<int>("WorkerConfig:BlockedTime");
            var currentTime = DateTime.Now;
            var expirationThreshold = currentTime - TimeSpan.FromSeconds(expirationTime);

            var expiredUsers = _dbSet
                .Where(x => x.IsBlocked && x.BlockedTime <= expirationThreshold);

            foreach (var user in expiredUsers)
            {
                user.IsBlocked = false;
                user.BlockedTime = null;
            }

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
