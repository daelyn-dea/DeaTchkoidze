// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Web.Infrastructure.MiddleWares;
using Serilog;
using Forum.Web.Infrastructure.Extensions;
using Microsoft.Extensions.FileProviders;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Configuration;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
               .ReadFrom.Configuration(builder.Configuration)
               .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

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
    FileProvider = new PhysicalFileProvider(builder.Configuration.GetValue<string>("UserImagesConfiguration:SavePath")),
    RequestPath = "/UserImages"
});

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(builder.Configuration.GetValue<string>("TopicImagesConfiguration:SavePath")),
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

app.Run();
