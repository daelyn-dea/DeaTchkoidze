using PizzaProject.API.Middlewares;

namespace PizzaProject.API.Infrastructure.Extensions
{
    public static class RequestResponseLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddlware>();
        }
    }
}
