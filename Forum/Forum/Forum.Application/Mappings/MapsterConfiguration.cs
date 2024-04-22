// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Authentications.RequestModels;
using Forum.Application.Comments.RequestModels;
using Forum.Application.Comments.ResponseModels;
using Forum.Application.Helpers;
using Forum.Application.Topics.ResponseModels;
using Forum.Application.Users.Models.ResponseModels;
using Forum.Domain.Comments;
using Forum.Domain.Topics;
using Forum.Domain.Users;
using HashidsNet;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Forum.Application.Mappings
{
    public static class MapsterConfiguration
    {
        public static void RegisterMappings(this IServiceCollection services)
        {

            TypeAdapterConfig<User, RequestLoginModel>
                .NewConfig()
                .Map(des => des.Password, src => src.PasswordHash)
                .TwoWays();

            TypeAdapterConfig<User, UserWithTopics>
                .NewConfig()
                .Map(des => des.Topics, src => src.Topics)
                .TwoWays();

            TypeAdapterConfig<RequestRegisterModel, User>
                .NewConfig()
                .Map(des => des.PasswordHash, src => src.Password)
                .TwoWays();

            TypeAdapterConfig<UserResponseModelForAdmin, User>
                .NewConfig()
                .Map(des => des.IsBlocked, src => src.IsBlocked)
                .TwoWays();

            var hashId = services.BuildServiceProvider().GetRequiredService<IHashids>();

            TypeAdapterConfig<Topic, ImagedTopicModel>
                .NewConfig()
                .Map(des => des.Id, src => hashId.Encode(src.Id))
                .Map(des => des.UserName, src => src.User.UserName)
                .Map(des => des.UserImageUrl, src => src.User.ImageUrl);

            TypeAdapterConfig<Topic, AdminImagedTopicModel>
                .NewConfig()
                .Map(des => des.Id, src => hashId.Encode(src.Id))
                .Map(des => des.UserName, src => src.User.UserName)
                .Map(des => des.UserImageUrl, src => src.User.ImageUrl);

            TypeAdapterConfig<Comment, CommentResponseModel>
                .NewConfig()
                .Map(des => des.UserName, src => src.User.UserName)
                .Map(des => des.UserImageUrl, src => src.User.ImageUrl)
                .TwoWays();
            TypeAdapterConfig<Comment, CommentResponseModelWithDelete>
               .NewConfig()
               .Map(des => des.UserName, src => src.User.UserName)
               .Map(des => des.UserImageUrl, src => src.User.ImageUrl)
               .TwoWays();

            TypeAdapterConfig<CommentRequestModel, Comment>
               .NewConfig()
               .Map(des => des.TopicId, src => hashId.Decode(src.TopicId)[0])
               .TwoWays();

            TypeAdapterConfig<TopicWithCommentCount, UserTopicDetailsModel>
               .NewConfig()
               .Map(des => des.CountOfComments, src => src.CommentCount)
               .Map(des => des.Title, src => src.Topic.Title)
               .Map(des => des.CreatedAt, src => src.Topic.CreatedAt)
               .Map(des => des.UserName, src => src.UserName)
               .Map(des => des.Id, src => hashId.Encode(src.Topic.Id))
               .Map(des => des.UserImageUrl, src => src.UserImageUrl)
               .TwoWays();

            TypeAdapterConfig<TopicWithCommentCount, AdminTopicDetailsModel>
               .NewConfig()
               .Map(des => des.TopicsCommentCount, src => src.CommentCount)
               .Map(des => des.Title, src => src.Topic.Title)
               .Map(des => des.CreatedAt, src => src.Topic.CreatedAt)
               .Map(des => des.UserName, src => src.UserName)
               .Map(des => des.UserId, src => src.Topic.UserId)
               .Map(des => des.Id, src => hashId.Encode(src.Topic.Id))
               .Map(des => des.State, src => src.Topic.State)
               .Map(des => des.Status, src => src.Topic.Status)
               .Map(des => des.UserImageUrl, src => src.UserImageUrl)
               .TwoWays();

            TypeAdapterConfig<UserSummary, UserResponseModelForAdmin>
              .NewConfig()
              .Map(des => des.TotalTopics, src => src.TotalTopics)
              .Map(des => des.TotalComments, src => src.TotalComments)
              .Map(des => des.Id, src => src.UserEntity.Id)
              .Map(des => des.BirthDate, src => src.UserEntity.BirthDate)
              .Map(des => des.CreatedAt, src => src.UserEntity.CreatedAt)
              .Map(des => des.Email, src => src.UserEntity.Email)
              .Map(des => des.ImageUrl, src => src.UserEntity.ImageUrl)
              .Map(des => des.IsBlocked, src => src.UserEntity.IsBlocked)
              .Map(des => des.LastName, src => src.UserEntity.LastName)
              .Map(des => des.Name, src => src.UserEntity.Name)
              .Map(des => des.UserName, src => src.UserEntity.UserName)
              .TwoWays();

            TypeAdapterConfig<PagedList<TopicWithCommentCount>, PagedList<UserTopicDetailsModel>>
               .NewConfig()
               .ConstructUsing(src => new PagedList<UserTopicDetailsModel>(
                    src.Items!.Select(item => item.Adapt<UserTopicDetailsModel>()).ToList(),
                    src.TotalCount,
                    src.CurrentPage,
                    src.PageSize
                ))
              .Map(des => des.TotalPages, src => src.TotalPages)
              .Map(des => des.HasPreviousPage, src => src.HasPreviousPage)
              .Map(des => des.HasNextPage, src => src.HasNextPage);

            TypeAdapterConfig<PagedList<TopicWithCommentCount>, PagedList<AdminTopicDetailsModel>>
               .NewConfig()
               .ConstructUsing(src => new PagedList<AdminTopicDetailsModel>(
                    src.Items!.Select(item => item.Adapt<AdminTopicDetailsModel>()).ToList(),
                    src.TotalCount,
                    src.CurrentPage,
                    src.PageSize
                ))
              .Map(des => des.TotalPages, src => src.TotalPages)
              .Map(des => des.HasPreviousPage, src => src.HasPreviousPage)
              .Map(des => des.HasNextPage, src => src.HasNextPage);

            TypeAdapterConfig<PagedList<Topic>, PagedList<ImagedTopicModel>>
              .NewConfig()
              .ConstructUsing(src => new PagedList<ImagedTopicModel>(
                   src.Item!.Adapt<ImagedTopicModel>(),
                   src.TotalCount,
                   src.CurrentPage,
                   src.PageSize
               ))
             .Map(des => des.TotalPages, src => src.TotalPages)
             .Map(des => des.HasPreviousPage, src => src.HasPreviousPage)
             .Map(des => des.HasNextPage, src => src.HasNextPage);

            TypeAdapterConfig<PagedList<Topic>, PagedList<AdminImagedTopicModel>>
             .NewConfig()
             .ConstructUsing(src => new PagedList<AdminImagedTopicModel>(
                  src.Item!.Adapt<AdminImagedTopicModel>(),
                  src.TotalCount,
                  src.CurrentPage,
                  src.PageSize
              ))
            .Map(des => des.TotalPages, src => src.TotalPages)
            .Map(des => des.HasPreviousPage, src => src.HasPreviousPage)
            .Map(des => des.HasNextPage, src => src.HasNextPage);

            TypeAdapterConfig<PagedList<UserSummary>, PagedList<UserResponseModelForAdmin>>
            .NewConfig()
            .ConstructUsing(src => new PagedList<UserResponseModelForAdmin>(
                 src.Items!.Select(item => item.Adapt<UserResponseModelForAdmin>()).ToList(),
                 src.TotalCount,
                 src.CurrentPage,
                 src.PageSize
             ))
           .Map(des => des.TotalPages, src => src.TotalPages)
           .Map(des => des.HasPreviousPage, src => src.HasPreviousPage)
           .Map(des => des.HasNextPage, src => src.HasNextPage);

        }
    }
}
