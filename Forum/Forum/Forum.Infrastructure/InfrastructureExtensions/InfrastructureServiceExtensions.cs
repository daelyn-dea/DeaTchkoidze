// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Comments;
using Forum.Application.Images;
using Forum.Application.Topics;
using Forum.Application.Users;
using Forum.Infrastructure.Comments;
using Forum.Infrastructure.Images;
using Forum.Infrastructure.Topics;
using Forum.Infrastructure.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Forum.Infrastructure.InfrastructureExtensions
{
    public static class InfrastructureServiceExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITopicRepository, TopicRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IImagesRepository, ImagesRepository>();
        }
    }
}
