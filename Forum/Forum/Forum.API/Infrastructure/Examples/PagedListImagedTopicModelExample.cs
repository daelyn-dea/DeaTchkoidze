// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Comments.ResponseModels;
using Forum.Application.Infrastructure.Helpers;
using Forum.Application.Topics.ResponseModels;
using Swashbuckle.AspNetCore.Filters;

namespace Forum.API.Infrastructure.Examples
{
    /// <summary>
    /// Provides examples for the <see cref="PagedList{ImagedTopicModel}"/> class.
    /// </summary>
    public class PagedListImagedTopicModelExample : IExamplesProvider<PagedList<ImagedTopicModel>>
    {
        /// <summary>
        /// Gets an example of a <see cref="PagedList{ImagedTopicModel}"/>.
        /// </summary>
        /// <returns>An example <see cref="PagedList{ImagedTopicModel}"/>.</returns>
        public PagedList<ImagedTopicModel> GetExamples()
        {
            var imagedTopicModel = new ImagedTopicModel
            {
                Id = "1dasf4fSf",
                UserName = "user1",
                CreatedAt = DateTime.Now,
                Title = "Java vs C#",
                UserImageUrl = "/UserImages/Default.jpg",
                ImageUrl = "/TopicImages/a76d12d8-6cff-4802-bbf1-bbbbcf155cbc.png.jpg",
                Comments = new List<CommentResponseModel>
                {
                    new CommentResponseModel
                    {
                        UserImageUrl = "/UserImages/Default.jpg",
                        UserName = "YourHeartHero",
                        Title = "WTF, of course C#",
                        CreatedAt = DateTime.Now.AddDays(-1)
                    },
                    new CommentResponseModel
                    {
                        UserImageUrl = "/UserImages/Default.jpg",
                        UserName = "GauqmebuliaGauqmebulia",
                        Title = "Me gavaukme magram mgoni henit unda mihvde hemo dsmao",
                        CreatedAt = DateTime.Now.AddDays(-1)
                    }
                }
            };

            return new PagedList<ImagedTopicModel>(
                item: imagedTopicModel,
                count: imagedTopicModel.Comments.Count,
                pageNumber: 1,
                pageSize: 10
            );
        }
    }
}
