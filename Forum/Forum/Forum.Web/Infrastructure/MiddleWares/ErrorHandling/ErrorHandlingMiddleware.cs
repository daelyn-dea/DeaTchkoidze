// Copyright (C) TBC Bank. All Rights Reserved.

using System.Text;
using Forum.Web.Infrastructure.ApplicationError;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;

namespace Forum.Web.Infrastructure.MiddleWares
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
                try
                {
                    HandleExceptionAsync(httpContext, ex);
                }
                catch (Exception exx)
                {
                    HandleExceptionAsync(httpContext, exx);
                }
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

        private static void HandleExceptionAsync(HttpContext context, Exception ex)
        {
            Error error = new(context, ex);

            var log = JsonConvert.SerializeObject(error);

            Log.Error(log);

            context.Session.Set("ErrorMessage", Encoding.UTF8.GetBytes(error.Title));

            context.Response.Redirect("/Home/Error");
        }

    }
}
