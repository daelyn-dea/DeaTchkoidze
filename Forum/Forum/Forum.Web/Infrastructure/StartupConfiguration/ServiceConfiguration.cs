// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Web.Infrastructure.Extensions;
using Serilog;

namespace Forum.Web.Infrastructure.StartupConfiguration
{
    public static class ServiceConfiguration
    {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddHealthCheck(builder.Configuration);

            builder.Services.AddSession();

            builder.Host.UseSerilog();

            builder.Services.AddControllersWithViews();

            builder.Services.AddServices(builder.Configuration);

            return builder;
        }
    }
}
