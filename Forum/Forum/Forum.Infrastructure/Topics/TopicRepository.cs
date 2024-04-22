// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Helpers;
using Forum.Application.Topics;
using Forum.Application.Topics.ResponseModels;
using Forum.Domain.Comments;
using Forum.Domain.Topics;
using Forum.Infrastructure.BaseRepository;
using Forum.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Forum.Infrastructure.Topics
{
    public class TopicRepository : BaseRepository<Topic>, ITopicRepository
    {
        public TopicRepository(ForumContext context) : base(context)
        {
        }
 
        public async Task<PagedList<TopicWithCommentCount>> GetAllTopicsForUserAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var skipCount = (pageNumber - 1) * pageSize;

            var topics = await _context.Topic
                .Where(x => x.State == TopicStateEnum.DbTopicState.Show)
                .OrderByDescending(x => x.CreatedAt)
                .Skip(skipCount)
                .Take(pageSize)
                .Select(topic => new TopicWithCommentCount
                {
                    Topic = topic,
                    UserName = topic.User.UserName,
                    CommentCount = topic.Comments!.Count(c => !c.IsDeleted),
                    UserImageUrl = topic.User.ImageUrl!,
                })
                .ToListAsync(cancellationToken).ConfigureAwait(false);

            var totalCount = await _context.Topic
                  .Where(x => x.State == TopicStateEnum.DbTopicState.Show)
                  .CountAsync(cancellationToken).ConfigureAwait(false);

            var pagedList = new PagedList<TopicWithCommentCount>(topics, totalCount, pageNumber, pageSize);

            return pagedList;
        }

        public async Task<PagedList<TopicWithCommentCount>> GetAllTopicsForAdminAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var skipCount = (pageNumber - 1) * pageSize;

            var topics = await _context.Topic
                .OrderBy(x => x.State)
                .Skip(skipCount)
                .Take(pageSize)
                .Select(topic => new TopicWithCommentCount
                {
                    Topic = topic,
                    UserName = topic.User.UserName,
                    CommentCount = topic.Comments!.Count()
                })
                .ToListAsync(cancellationToken).ConfigureAwait(false);

            var totalCount = await _context.Topic
                  .CountAsync(cancellationToken).ConfigureAwait(false);

            var pagedList = new PagedList<TopicWithCommentCount>(topics, totalCount, pageNumber, pageSize);

            return pagedList;
        }

        public async Task<PagedList<Topic>?> GetTopicAsync(int pageNumber, int pageSize, int id, CancellationToken cancellationToken)
        {
            var skipCount = (pageNumber - 1) * pageSize;

            var topic = await _context.Topic
                    .Include(topic => topic.User)
                    .Include(topic => topic.Comments!.Where(c => !c.IsDeleted))
                          .ThenInclude(comment => comment.User)
                    .SingleOrDefaultAsync(x => x.Id == id && x.State == TopicStateEnum.DbTopicState.Show, cancellationToken)
                    .ConfigureAwait(false);

            if (topic is null)
                return null;

            var comments = topic.Comments?
                .OrderByDescending(c => c.CreatedAt)
                .Skip(skipCount)
                .Take(pageSize)
                .ToList() ?? new List<Comment>();

            var totalCount = topic.Comments!.Count(c => !c.IsDeleted);

            topic.Comments = comments;

            var pagedList = new PagedList<Topic>(topic, totalCount, pageNumber, pageSize);

            return pagedList;
        }

        public async Task<PagedList<Topic>?> GetTopicForAdminAsync(int pageNumber, int pageSize, int id, CancellationToken cancellationToken)
        {
            var skipCount = (pageNumber - 1) * pageSize;

            var topic = await _context.Topic
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

        public async Task CreateTopicAsync(Topic topic, CancellationToken cancellationToken)
        {
            await CreateAsync(topic, cancellationToken).ConfigureAwait(false);
        }

        public async Task<bool> Exists(int id, CancellationToken cancellationToken)
        {
            return await AnyAsync(x => x.Id == id, cancellationToken).ConfigureAwait(false);
        }

        public async Task<bool> ExistsTopic(int id, CancellationToken cancellationToken)
        {
            return await _context.Topic
                .AnyAsync(x => x.State == TopicStateEnum.DbTopicState.Show
                            && x.Status == TopicStatusEnum.TopicStatus.Active
                            && x.Id == id, cancellationToken).ConfigureAwait(false);
        }

        public async Task<bool> CanDelete(int id, string userId, CancellationToken cancellationToken)
        {
            return await _context.Topic.AnyAsync(x => x.UserId == userId, cancellationToken).ConfigureAwait(false);
        }

        public async Task InactivateTopic(CancellationToken cancellationToken)
        {
            var currentTime = DateTime.Now;
            var twoDaysAgo = currentTime.AddDays(-2);

            var inactiveTopics = _context.Topic
                   .Where(t => t.CreatedAt < twoDaysAgo)
                   .Where(t => !t.Comments!.Any() ||
                   t.Comments!.Any() &&
                   t.Comments!.OrderByDescending(c => c.CreatedAt)
                   .First().CreatedAt < twoDaysAgo);

            foreach (var topic in inactiveTopics)
            {
                topic.Status = TopicStatusEnum.TopicStatus.Inactive;
            }

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
