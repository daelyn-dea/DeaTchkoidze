using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using ToDo.API.Infrastructure.Authentication;
using ToDo.API.Infrastructure.Extensions;
using ToDo.API.Infrastructure.Mappings;
using ToDo.API.Infrastructure.MiddleWares;
using ToDo.Persistence;
using ToDo.Persistence.Context;
using HealthChecks.UI.Client;
using HealthChecks.UI.Configuration;
using Options = HealthChecks.UI.Configuration.Options;

namespace ToDo.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //health check
            builder.Services.AddHealthChecks()
        .AddSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"], healthQuery: "select 1", name: "SQL Server", failureStatus: HealthStatus.Unhealthy, tags: new[] { "Feedback", "Database" })
        .AddUrlGroup(new Uri("https://medium.com/@jeslurrahman/implementing-health-checks-in-net-8-c3ba10af83c3"), name: "base URL", failureStatus: HealthStatus.Unhealthy); // ნებისმიერ ურლ სადაც საჭიროა როწ ვდომა გქონდეს, თუ არ არის საჭრო დაიკიდე ვაფშე ეს ნაწილი
            builder.Services.AddHealthChecksUI(opt =>
            {
                opt.SetEvaluationTimeInSeconds(10); //time in seconds between check    
                opt.MaximumHistoryEntriesPerEndpoint(60); //maximum history of checks    
                opt.SetApiMaxActiveRequests(1); //api requests concurrency    
                opt.AddHealthCheckEndpoint("feedback api", "/api/health"); //map health check api    

            })
                .AddInMemoryStorage();

            //ende health

            builder.Services.AddControllers();
            builder.Services.AddSwaggerExamplesFromAssemblyOf<Program>();
            builder.Services.UseSwaggerConfiguration();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();
            builder.Host.UseSerilog();

            builder.Services.AddServices();

            builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

            builder.Services.Configure<AuthenticationConfiguration>(builder.Configuration.GetSection(nameof(AuthenticationConfiguration)));
            builder.Services.AddTokenAuthentication(builder.Configuration);

            builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection(nameof(ConnectionStrings)));

            builder.Services.AddDbContext<ToDoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(ConnectionStrings.DefaultConnection))));

            builder.Services.RegisterMappings();

            var app = builder.Build();

            app.UseMiddleware<ErrorHandlingMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDo API v1");
                });
            }
            app.UseRequestResponseLogging();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            // health
            app.MapHealthChecks("/api/health", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            app.UseHealthChecksUI(delegate (Options options)
            {
                options.UIPath = "/healthcheck-ui";
                //options.AddCustomStylesheet("./HealthCheck/Custom.css");

            });
            //end health


            app.UseSerilogRequestLogging();

            app.UseCultureMiddleware();

            app.MapControllers();

            app.Run();
        }
    }
}
