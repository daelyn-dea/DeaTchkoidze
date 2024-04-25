// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Infrastructure.Helpers;
using Forum.Application.Topics.Interfaces;
using Forum.Application.Topics.ResponseModels;
using Forum.Domain.Comments;
using Forum.Domain.Topics;
using Forum.Infrastructure.BaseRepository;
using Forum.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Forum.Infrastructure.Topics
{
    internal class AdminTopicRepository : BaseRepository<Topic>, IAdminTopicRepository
    {
        public AdminTopicRepository(ForumContext context) : base(context)
        {
        }

        public async Task<PagedList<TopicWithCommentCount>> GetAllTopicAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var skipCount = (pageNumber - 1) * pageSize;

            var topicsQuery = _dbSet
                .OrderByDescending(x => x.CreatedAt)
                .Select(topic => new TopicWithCommentCount
                {
                    Topic = topic,
                    UserName = topic.User.UserName,
                    CommentCount = topic.Comments!.Count(c => !c.IsDeleted),
                    UserImageUrl = topic.User.ImageUrl!,
                });

            var topics = await topicsQuery
                .Skip(skipCount)
                .Take(pageSize)
                .ToListAsync(cancellationToken).ConfigureAwait(false);

            var totalCount = await topicsQuery
                .CountAsync(cancellationToken).ConfigureAwait(false);

            return new PagedList<TopicWithCommentCount>(topics, totalCount, pageNumber, pageSize);
        }
        public async Task<PagedList<Topic>?> GetTopicAsync(int pageNumber, int pageSize, int id, CancellationToken cancellationToken)
        {
            var skipCount = (pageNumber - 1) * pageSize;

            var topic = await _dbSet
                    .Include(topic => topic.User)
                    .Include(topic => topic.Comments!)
                        .ThenInclude(comment => comment.User)
                    .SingleOrDefaultAsync(x => x.Id == id, cancellationToken)
                    .ConfigureAwait(false);

            if (topic is null)
                return null;

            var comments = topic.Comments?
                .OrderByDescending(c => c.CreatedAt)
                .Skip(skipCount)
                .Take(pageSize)
                .ToList() ?? new List<Comment>();

            var totalCount = topic.Comments!.Count;

            topic.Comments = comments;

            var pagedList = new PagedList<Topic>(topic, totalCount, pageNumber, pageSize);

            return pagedList;
        }

        public async Task<bool> Exists(int id, CancellationToken cancellationToken)
        {
            return await _dbSet
                .AnyAsync(x => x.Id == id, cancellationToken).ConfigureAwait(false);
        }
    }
}
