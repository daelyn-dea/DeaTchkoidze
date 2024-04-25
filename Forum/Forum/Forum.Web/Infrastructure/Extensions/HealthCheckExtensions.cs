// Copyright (C) TBC Bank. All Rights Reserved.

using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Forum.Web.Infrastructure.Extensions
{
    public static class HealthCheckExtensions
    {
        public static void AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddHealthChecks()
                    .AddSqlServer(configuration["ConnectionStrings:DefaultConnection"]!, healthQuery: "select 1", name: "SQL Server", failureStatus: HealthStatus.Unhealthy, tags: new[] { "Feedback", "Database" })
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
