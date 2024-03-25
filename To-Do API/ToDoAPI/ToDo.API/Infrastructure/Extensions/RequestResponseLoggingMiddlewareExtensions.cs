using Microsoft.AspNetCore.Diagnostics;
using ToDo.API.Infrastructure.MiddleWares;

namespace ToDo.API.Infrastructure.Extensions
{
    public static class RequestResponseLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestResponseLogging(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<RequestResponseLoginMiddleware>();

            return builder;
        }
    }
}
