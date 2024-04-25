// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Web.Infrastructure.MiddleWares;
using HealthChecks.UI.Client;
using HealthChecks.UI.Configuration;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.FileProviders;

namespace Forum.Web.Infrastructure.StartupConfiguration
{
    public static class MiddlewareConfiguration
    {
        public static WebApplication ConfigureMiddleware(this WebApplication app, IConfiguration configuration)
        {
            app.UseSession();

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseStaticFiles();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(configuration.GetValue<string>("UserImagesConfiguration:SavePath")),
                RequestPath = "/UserImages"
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(configuration.GetValue<string>("TopicImagesConfiguration:SavePath")),
                RequestPath = "/TopicImages"
            });

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapHealthChecks("/api/health", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI(delegate (Options options)
            {
                options.UIPath = "/healthcheck-ui";
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            return app;
        }
    }
}
