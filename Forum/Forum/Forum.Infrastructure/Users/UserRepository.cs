// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Helpers;
using Forum.Application.Topics.ResponseModels;
using Forum.Application.Users;
using Forum.Application.Users.Models.ResponseModels;
using Forum.Domain.Topics;
using Forum.Domain.Users;
using Forum.Infrastructure.BaseRepository;
using Forum.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Forum.Infrastructure.Users
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly IConfiguration _configuration;
        public UserRepository(ForumContext context, IConfiguration configuration) : base(context)
        {
            _configuration = configuration;
        }

        public async Task<PagedList<UserTopicsSummary>> GetUserAsync(int pageNumber, int pageSize, string email, CancellationToken cancellationToken)
        {
            var skipCount = (pageNumber - 1) * pageSize;
            var totalCount = 0;

            var userTopicsSummary = await _context.Users
                .Where(user => user.Email == email)
                 .Select(user => new UserTopicsSummary
                 {
                     User = user,
                     Topics = user.Topics != null ? user.Topics
                        .Where(topic => topic.State == TopicStateEnum.DbTopicState.Show)
                        .OrderByDescending(t => t.CreatedAt)
                        .Skip(skipCount)
                        .Take(pageSize)
                        .Select(topic => new TopicWithCommentCount
                        {
                            UserName = user.UserName,
                            Topic = topic,
                            CommentCount = topic.Comments != null ? topic.Comments.Count(x => x.IsDeleted == false) : 0,
                            UserImageUrl = topic.User.ImageUrl!
                        })
                        .ToList() : new List<TopicWithCommentCount>()
                 })
                .FirstOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);

            if (userTopicsSummary != null)
                totalCount = userTopicsSummary.Topics.Count;

            var pagedList = new PagedList<UserTopicsSummary>(userTopicsSummary, totalCount, pageNumber, pageSize);

            return pagedList;
        }
        public async Task<PagedList<UserTopicsSummary>> GetUserByNameAsync(int pageNumber, int pageSize, string userName, CancellationToken cancellationToken)
        {
            var skipCount = (pageNumber - 1) * pageSize;
            var totalCount = 0;

            var userTopicsSummary = await _context.Users
                .Where(user => user.UserName == userName)
                .Select(user => new UserTopicsSummary
                {
                    User = user,
                    Topics = user.Topics != null ? user.Topics
                        .Where(topic => topic.State == TopicStateEnum.DbTopicState.Show)
                        .OrderByDescending(t => t.CreatedAt)
                        .Skip(skipCount)
                        .Take(pageSize)
                        .Select(topic => new TopicWithCommentCount
                        {
                            UserName = user.UserName,
                            Topic = topic,
                            CommentCount = topic.Comments != null ? topic.Comments.Count(x => x.IsDeleted == false) : 0,
                            UserImageUrl = topic.User.ImageUrl!
                        })
                        .ToList() : new List<TopicWithCommentCount>()
                })
                .FirstOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);

            if (userTopicsSummary != null)
                totalCount = userTopicsSummary.Topics.Count;

            var pagedList = new PagedList<UserTopicsSummary>(userTopicsSummary, totalCount, pageNumber, pageSize);

            return pagedList;
        }
        public async Task<PagedList<UserSummary>> GetAllUser(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var skipCount = (pageNumber - 1) * pageSize;

            var users = await _context.User
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

            var totalCount = await _context.User
            .CountAsync(cancellationToken).ConfigureAwait(false);

            var pagedList = new PagedList<UserSummary>(users, totalCount, pageNumber, pageSize);

            return pagedList;
        }
        public async Task<bool> AccessOfPostTopic(string userId, CancellationToken cancellationToken)
        {
            var commentCount = await _context.Users
                    .Where(user => user.Id == userId)
                    .Include(user => user.Comments!.Where(c => !c.IsDeleted))
                    .Select(user => user.Comments!.Count())
                    .FirstOrDefaultAsync(cancellationToken)
                    .ConfigureAwait(false);

            return commentCount > 3;
        }
        public async Task BlockExpiration(CancellationToken cancellationToken)
        {
            var expirationTime = _configuration.GetValue<int>("BlockedTime");
            var currentTime = DateTime.Now;
            var expirationThreshold = currentTime - TimeSpan.FromDays(expirationTime);

            var expiredUsers = _context.User
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
