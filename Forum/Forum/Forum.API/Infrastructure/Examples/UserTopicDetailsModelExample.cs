//Copyright(C) TBC Bank. All Rights Reserved.

using Forum.Application.Infrastructure.Helpers;
using Forum.Application.Topics.ResponseModels;
using Swashbuckle.AspNetCore.Filters;

namespace Forum.API.Infrastructure.Examples
{
    /// <summary>
    /// Provides examples for the <see cref="UserTopicDetailsModel"/>.
    /// </summary>
    public class UserTopicDetailsModelExample : IExamplesProvider<PagedList<UserTopicDetailsModel>>
    {
        /// <summary>
        /// Gets an example of a <see cref="PagedList{UserTopicDetailsModel}"/>.
        /// </summary>
        /// <returns>An example <see cref="PagedList{UserTopicDetailsModel}"/>.</returns>
        public PagedList<UserTopicDetailsModel> GetExamples()
        {
            var items = new List<UserTopicDetailsModel>
            {
                new UserTopicDetailsModel
                {
                    Title = "Sample Title 1",
                    Id = "Dgd23Dgse1",
                    UserName = "User1",
                    CreatedAt = DateTime.Now.AddDays(-2),
                    UserImageUrl = null
                },
                new UserTopicDetailsModel
                {
                    Title = "Sample Title 2",
                    Id = "Dgd23Dgse2",
                    UserName = "User2",
                    CreatedAt = DateTime.Now.AddDays(-3),
                    UserImageUrl = null
                },

            };
            return new PagedList<UserTopicDetailsModel>(
                items: items,
                count: items.Count,
                pageNumber: 1,
                pageSize: 10
            );
        }
    }
}
