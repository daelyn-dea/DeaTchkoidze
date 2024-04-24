using PizzaProject.API.Middlewares;

namespace PizzaProject.API.Infrastructure.Extensions
{
    public static class CultureMiddlewareExtension
    {
        public static IApplicationBuilder UseRequestCulture(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<CultureMiddleware>();

            return builder;
        }
    }
}
