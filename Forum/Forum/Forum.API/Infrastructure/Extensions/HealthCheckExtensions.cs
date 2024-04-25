// Copyright (C) TBC Bank. All Rights Reserved.

using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Forum.API.Infrastructure.Extensions
{
    /// <summary>
    /// Extension methods for configuring health checks.
    /// </summary>
    public static class HealthCheckExtensions
    {
        /// <summary>
        /// Adds health checks to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add health checks to.</param>
        /// <param name="configuration">The <see cref="IConfiguration"/> containing the configuration settings.</param>
        public static void AddHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddHealthChecks()
                    .AddSqlServer(configuration["ConnectionStrings:DefaultConnection"], healthQuery: "select 1", name: "SQL Server", failureStatus: HealthStatus.Unhealthy, tags: new[] { "Feedback", "Database" })
                    .AddUrlGroup(new Uri("https://localhost:7257/swagger/index.html"), name: "base URL", failureStatus: HealthStatus.Unhealthy);

            services.AddHealthChecksUI(opt =>
            {
                opt.SetEvaluationTimeInSeconds(10);
                opt.MaximumHistoryEntriesPerEndpoint(60);
                opt.SetApiMaxActiveRequests(1);
                opt.AddHealthCheckEndpoint("feedback api", "/api/health");

            })
                .AddInMemoryStorage();
        }
    }
}
