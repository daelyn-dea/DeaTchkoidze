// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Topics.Interfaces;
using Forum.Domain.Topics;
using Forum.Infrastructure.BaseRepository;
using Forum.Persistence.Context;
using Microsoft.Extensions.Configuration;

namespace Forum.Infrastructure.Topics
{
    public class WorkerTopicRepository : BaseRepository<Topic>, IWorkerTopicRepository
    {
        private readonly IConfiguration _configuration;
        public WorkerTopicRepository(ForumContext context, IConfiguration configuration) : base(context)
        {
            _configuration = configuration;
        }
        public async Task InactivateTopic(CancellationToken cancellationToken)
        {
            var expirationTime = _configuration.GetValue<int>("WorkerConfig:ArchiveTime");
            var currentTime = DateTime.Now;
            var expirationThreshold = currentTime - TimeSpan.FromSeconds(expirationTime);

            var inactiveTopics = _dbSet
                   .Where(t => t.CreatedAt < expirationThreshold)
                   .Where(t => !t.Comments!.Any() ||
                   t.Comments!.Any() &&
                   t.Comments!.OrderByDescending(c => c.CreatedAt)
                   .First().CreatedAt < expirationThreshold);

            foreach (var topic in inactiveTopics)
            {
                topic.Status = TopicStatusEnum.TopicStatus.Inactive;
            }

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
