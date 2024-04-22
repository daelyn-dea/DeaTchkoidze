using Forum.API.Infrastructure.Extensions;
using Forum.API.Infrastructure.MiddleWares.ErrorHandling;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
               .ReadFrom.Configuration(builder.Configuration)
               .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddControllers();

builder.Services.UseSwaggerConfiguration();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
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

app.Run();
