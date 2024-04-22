// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Helpers;
using Forum.Application.Topics.ResponseModels;
using Forum.Application.Users.Models.ResponseModels;
using Swashbuckle.AspNetCore.Filters;

namespace Forum.API.Infrastructure.Examples
{
    public class PagedListUserWithTopicsExample : IExamplesProvider<PagedList<UserWithTopics>>
    {
        public PagedList<UserWithTopics> GetExamples()
        {
            var item = new UserWithTopics
            {
                Email = "user1@example.com",
                UserName = "Dea",
                Topics = new List<UserTopicDetailsModel>
                {
                    new UserTopicDetailsModel
                    {
                        Title = "General Discussion",
                        Id = "Dgd23Dgse1",
                        UserName = "User1",
                        CreatedAt = DateTime.Now.AddDays(-2),
                        UserImageUrl = "/UserImages/Default.jpg"
                    },
                    new UserTopicDetailsModel
                    {
                        Title = "Jobs and Career",
                        Id = "Dgd23Dgse2",
                        UserName = "User1",
                        CreatedAt = DateTime.Now.AddDays(-3),
                        UserImageUrl = "/UserImages/Default.jpg"
                    }
                },
                ImageUrl = "/TopicImages/a76d12d8-6cff-4802-bbf1-bbbbcf155cbc.png.jpg"
            };

            return new PagedList<UserWithTopics>(
                item: item,
                count: item.Topics.Count,
                pageNumber: 1,
                pageSize: 10
            );
        }
    }
}
