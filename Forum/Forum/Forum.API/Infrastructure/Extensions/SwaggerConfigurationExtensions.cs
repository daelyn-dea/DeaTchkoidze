using Asp.Versioning;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

namespace Forum.API.Infrastructure.Extensions
{

    /// <summary>
    /// Extension methods for configuring Swagger/OpenAPI documentation.
    /// </summary>
    public static class SwaggerConfigurationExtensions
    {
        /// <summary>
        /// Configures Swagger/OpenAPI documentation for the API.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add Swagger services to.</param>
        public static void UseSwaggerConfiguration(this IServiceCollection services)
        {

            services.AddApiVersioning(opts =>
            {
                opts.ApiVersionReader = new UrlSegmentApiVersionReader();
                opts.DefaultApiVersion = new ApiVersion(2, 0);
                opts.AssumeDefaultVersionWhenUnspecified = true;
            })
            .AddApiExplorer(opts =>
            {
                opts.GroupNameFormat = "'v'VVV";
                opts.SubstituteApiVersionInUrl = true;
            });

            services.AddEndpointsApiExplorer();
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
                    Version = "1.0",
                    Title = "Forum API 2",
                    Description =  "This version is Deprecated. Will be supported until 5/23/2024",
                    Contact = new OpenApiContact
                    {
                        Name = "Forum",
                    },
                });

                options.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "2.0",
                    Title = "Forum API 2",
                    Description = "Forum for everyone who wants to talk",
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
        }
    }
}
