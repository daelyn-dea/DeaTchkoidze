using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using ToDo.API.Infrastructure.Authentication;
using ToDo.API.Infrastructure.Extensions;
using ToDo.API.Infrastructure.Mappings;
using ToDo.API.Infrastructure.MiddleWares;
using ToDo.Persistence;
using ToDo.Persistence.Context;

namespace ToDo.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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

            app.UseSerilogRequestLogging();

            app.UseCultureMiddleware();

            app.MapControllers();

            app.Run();
        }
    }
}
