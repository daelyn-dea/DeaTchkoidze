// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.API.Infrastructure.MiddleWares.ErrorHandling;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Forum.API.Infrastructure.StartupConfiguration
{
    /// <summary>
    /// Configuration class for middleware setup.
    /// </summary>
    public static class MiddlewareConfiguration
    {
        /// <summary>
        /// Configures middleware for the web application.
        /// </summary>
        /// <param name="app">The <see cref="WebApplication"/> to configure middleware for.</param>
        /// <returns>The <see cref="WebApplication"/> instance with middleware configured.</returns>
        public static WebApplication ConfigureMiddleware(this WebApplication app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(opts =>
                {
                    opts.SwaggerEndpoint("/swagger/v2/swagger.json", "2.0");
                    opts.SwaggerEndpoint("/swagger/v1/swagger.json", "1.0");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapHealthChecks("/api/health", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.MapControllers();

            return app;
        }
    }
}
