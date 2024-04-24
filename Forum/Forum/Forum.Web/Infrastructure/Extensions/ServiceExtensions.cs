using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Forum.Persistence.PersistenceExtensions;
using Forum.Infrastructure.InfrastructureExtensions;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Forum.Application.Infrastructure.ServiceExtensions;

namespace Forum.Web.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                    .AddSqlServer(configuration["ConnectionStrings:DefaultConnection"], healthQuery: "select 1", name: "SQL Server", failureStatus: HealthStatus.Unhealthy, tags: new[] { "Feedback", "Database" })
                    .AddUrlGroup(new Uri("https://localhost:7218/"), name: "base URL", failureStatus: HealthStatus.Unhealthy);

            services.AddHealthChecksUI(opt =>
            {
                opt.SetEvaluationTimeInSeconds(10);
                opt.MaximumHistoryEntriesPerEndpoint(60);
                opt.SetApiMaxActiveRequests(1);
                opt.AddHealthCheckEndpoint("feedback api", "/api/health");

            })
                .AddInMemoryStorage();


            services.AddSession();


            services.AddApplication(configuration);
            services.AddPersistence(configuration);
            services.AddInfrastructure();

            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
