// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Users.Models.ResponseModels;
using Swashbuckle.AspNetCore.Filters;

namespace Forum.API.Infrastructure.Examples
{
    /// <summary>
    /// Provides examples for the <see cref="UserAccountModel"/>.
    /// </summary>
    public class UserAccountModelExample : IExamplesProvider<UserAccountModel>
    {
        /// <summary>
        /// Gets an example of a <see cref="UserAccountModel"/>.
        /// </summary>
        /// <returns>An example <see cref="UserAccountModel"/>.</returns>
        public UserAccountModel GetExamples()
        {
            return new UserAccountModel
            {
                Name = "John",
                CreatedAt = DateTime.Now.AddDays(-30),
                LastName = "Doe",
                BirthDate = new DateTime(1990, 5, 15),
                Email = "john.doe@example.com",
                UserName = "johndoe",
                ImageUrl = "/UserImages/Default.jpg"
            };
        }
    }
}
