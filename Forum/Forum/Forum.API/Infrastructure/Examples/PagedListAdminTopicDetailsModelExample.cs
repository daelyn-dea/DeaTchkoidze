// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Helpers;
using Forum.Application.Topics.ResponseModels;
using Forum.Domain.Topics;
using Swashbuckle.AspNetCore.Filters;
using static Forum.Application.Topics.ResponseModels.TopicResponseStateEnum;
using static Forum.Domain.Topics.TopicStateEnum;

namespace Forum.API.Infrastructure.Examples
{
    public class PagedListAdminTopicDetailsModelExample : IExamplesProvider<PagedList<AdminTopicDetailsModel>>
    {
        public PagedList<AdminTopicDetailsModel> GetExamples()
        {
            var topic1 = new AdminTopicDetailsModel
            {
                Id = "64df8bf3-8b0a-44d7-83b4-f42f203eb794",
                UserName = "Dealodea",
                CreatedAt = DateTime.Now.AddDays(-30),
                Title = "Sample Title 1",
                UserImageUrl = "/UserImages/Default.jpg",
                TopicsCommentCount = 5,
                State = DbTopicState.Show,
                Status = TopicStatusEnum.TopicStatus.Active,
                UserId = "user1"
            };

            var topic2 = new AdminTopicDetailsModel
            {
                Id = "64df8bf3-8b0a-44d7-83b4-f42f203eb794",
                UserName = "Liak12",
                CreatedAt = DateTime.Now.AddDays(-20),
                Title = "Sample Title 2",
                UserImageUrl = "/UserImages/Default.jpg",
                TopicsCommentCount = 3,
                State = DbTopicState.Show,
                Status = TopicStatusEnum.TopicStatus.Active,
                UserId = "user2"
            };
            var topics = new List<AdminTopicDetailsModel> { topic1, topic2 };

            return new PagedList<AdminTopicDetailsModel>(
                items: topics,
                count: topics.Count,
                pageNumber: 1,
                pageSize: 10
            );
        }
    }
}
