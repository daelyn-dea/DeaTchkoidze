// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Domain.Users;
using Forum.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using HashidsNet;
using Microsoft.Extensions.Configuration;
using Forum.Application.Topics.UserServices;
using Forum.Application.Comments.Services;
using Forum.Application.Topics.AdminServices;
using Forum.Application.Authentications.AbstractionOfAuthenticationServices;
using Forum.Application.Authentications.AuthenticationServices;
using Forum.Application.Users.UserServices;
using Forum.Application.Users.AdminServices;
using Forum.Application.Mappings;

namespace Forum.Application.ServiceExtensions
{
    public static class ApplicationServiceExtensions
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ForumContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IUserManagementService, UserManagementService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddScoped<IUserTopicService, UserTopicService>();
            services.AddScoped<IAdminTopicService, AdminTopicService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAdminService, AdminService>();

            services.AddSingleton<IHashids>(_ => new Hashids
          (
             configuration.GetRequiredSection(nameof(HashIdConfiguration)).GetRequiredSection(nameof(HashIdConfiguration.Salt)).Value, 8
          ));

            services.RegisterMappings();
        }
    }
}
