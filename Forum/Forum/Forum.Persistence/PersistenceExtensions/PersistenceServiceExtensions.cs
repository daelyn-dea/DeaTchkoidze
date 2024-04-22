// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Persistence.Context;
using Forum.Persistence.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Forum.Persistence.PersistenceExtensions
{
    public static class PersistenceServiceExtensions
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ForumContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(nameof(ConnectionStrings.DefaultConnection)));
            });

            ForumSeed.Initialize(services.BuildServiceProvider()).Wait();
        }
    }
}
