// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Users.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NCrontab;

namespace Forum.Worker.BackgroundWorkers
{
    public class BlockRemovalWorker : BackgroundService
    {
        private readonly ILogger<BlockRemovalWorker> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private readonly CrontabSchedule _schedule;
        private DateTime _nextRun;

        public BlockRemovalWorker(ILogger<BlockRemovalWorker> logger, IServiceProvider serviceProvider, IConfiguration config)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _configuration = config;
            var crontabExpression = _configuration.GetValue<string>("CrontabConfig:CrontabExpressionOfBlockRemovalWorker");
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
                            var topic = scope.ServiceProvider.GetRequiredService<IWorkerUserRepository>();
                            if (now > _nextRun)
                            {
                                _logger.LogInformation("BlockRemovalWorker started at time {Time}", DateTimeOffset.UtcNow);
                                await topic.BlockExpiration(stoppingToken).ConfigureAwait(false);
                                _nextRun = _schedule.GetNextOccurrence(DateTime.UtcNow);
                                _logger.LogInformation("BlockRemovalWorker ended at: {Time}", DateTimeOffset.Now);
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
