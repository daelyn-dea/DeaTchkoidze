using Forum.Persistence.PersistenceExtensions;
using Forum.Infrastructure.InfrastructureExtensions;
using Forum.Application.Infrastructure.ServiceExtensions;

namespace Forum.Web.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplication(configuration);
            services.AddPersistence(configuration);
            services.AddInfrastructure();
        }
    }
}
