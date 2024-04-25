// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Topics.Interfaces;
using Forum.Persistence.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NCrontab;

namespace Forum.Worker.BackgroundWorkers
{
    public class TopicArchiveWorker : BackgroundService
    {
        private readonly ILogger<TopicArchiveWorker> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private readonly CrontabSchedule _schedule;
        private DateTime _nextRun;

        public TopicArchiveWorker(ILogger<TopicArchiveWorker> logger, IServiceProvider serviceProvider, IConfiguration config)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _configuration = config;
            var crontabExpression = _configuration.GetValue<string>("CrontabConfig:CrontabExpressionOfTopicArchiveWorker");
            _schedule = CrontabSchedule.Parse(crontabExpression, new CrontabSchedule.ParseOptions { IncludingSeconds = true });
            _nextRun = _schedule.GetNextOccurrence(DateTime.UtcNow);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Run(async () =>
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    try
                    {
                        using var scope = _serviceProvider.CreateScope();
                        {
                            var now = DateTime.UtcNow;
                            var topic = scope.ServiceProvider.GetRequiredService<IWorkerTopicRepository>();
                            if (now > _nextRun)
                            {
                                _logger.LogInformation("TopicArchiveWorker running at: {Time}", DateTimeOffset.Now);
                                await topic.InactivateTopic(stoppingToken).ConfigureAwait(false);
                                _nextRun = _schedule.GetNextOccurrence(DateTime.UtcNow);
                                _logger.LogInformation("TopicArchiveWorker stopping at: {Time}", DateTimeOffset.Now);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, ex.Message);
                    }
                }
            }, stoppingToken).ConfigureAwait(false);
        }
    }
}
