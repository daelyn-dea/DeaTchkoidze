// Copyright (C) TBC Bank. All Rights Reserved.

using Newtonsoft.Json;
using Serilog;

namespace Forum.API.Infrastructure.MiddleWares.ErrorHandling
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext).ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex).ConfigureAwait(false);
            }
            finally
            {
                LogResponseStatus(httpContext.Response.StatusCode);
            }
        }

        private void LogResponseStatus(int statusCode)
        {
            if (statusCode >= 500)
            {
                _logger.LogError($"Server error occurred with status code {statusCode}");
            }
            else if (statusCode >= 400)
            {
                _logger.LogWarning($"Client error occurred with status code {statusCode}");
            }
            else
            {
                _logger.LogInformation($"Request succeeded with status code {statusCode}");
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var error = new Error(context, ex);
            var result = JsonConvert.SerializeObject(error);

            Log.Error(result);

            context.Response.Clear();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = error.Status!.Value;

            await context.Response.WriteAsync(result).ConfigureAwait(false);
        }

    }
}
