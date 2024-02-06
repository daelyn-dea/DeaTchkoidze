using CompaniesManagmentApplication;

namespace CompaniesManagment.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICompanyService, CompanyService>();
        }
    }
}
