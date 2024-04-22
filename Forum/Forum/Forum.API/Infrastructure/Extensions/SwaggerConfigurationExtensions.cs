using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

//using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

namespace Forum.API.Infrastructure.Extensions
{
    public static class SwaggerConfigurationExtensions
    {
        public static void UseSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerExamplesFromAssemblyOf<Program>();
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Forum API",
                    Description = "Forum for everyone who wants talking",
                    Contact = new OpenApiContact
                    {
                        Name = "Forum",
                        Url = new Uri("https://whatareyoudoing.com/contact")
                    },
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                options.IncludeXmlComments(xmlPath);
                options.ExampleFilters();
            });
            services.AddEndpointsApiExplorer(); 
        }
    }
}
