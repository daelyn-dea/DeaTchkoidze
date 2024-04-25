// Copyright (C) TBC Bank. All Rights Reserved.

using System.Reflection;
using Forum.API.Infrastructure.Extensions;
using Serilog;
using Forum.API.Infrastructure.Authentication;
using Forum.Application.Infrastructure.ServiceExtensions;
using FluentValidation;
using FluentValidation.AspNetCore;
using Forum.Infrastructure.InfrastructureExtensions;
using Forum.Persistence.PersistenceExtensions;

namespace Forum.API.Infrastructure.StartupConfiguration
{
    /// <summary>
    /// Configuration class for setting up services in the web application.
    /// </summary>
    public static class ServiceConfiguration
    {
        /// <summary>
        /// Configures services for the web application.
        /// </summary>
        /// <param name="builder">The <see cref="WebApplicationBuilder"/> instance.</param>
        /// <returns>The <see cref="WebApplicationBuilder"/> instance.</returns>
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog();

            builder.Services.AddControllers(); 

            builder.Services.UseSwaggerConfiguration();

            builder.Services.AddHealthChecks(builder.Configuration);

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddApplication(builder.Configuration);
            builder.Services.AddPersistence(builder.Configuration);
            builder.Services.AddInfrastructure();

            builder.Services.Configure<AuthenticationConfiguration>(builder.Configuration.GetSection(nameof(AuthenticationConfiguration)));
            builder.Services.AddTokenAuthentication(builder.Configuration);

            return builder;
        }
    }
}
