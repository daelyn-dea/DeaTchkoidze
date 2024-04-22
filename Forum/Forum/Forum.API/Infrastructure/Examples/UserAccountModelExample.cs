// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Users.Models.ResponseModels;
using Swashbuckle.AspNetCore.Filters;

namespace Forum.API.Infrastructure.Examples
{
    public class UserAccountModelExample : IExamplesProvider<UserAccountModel>
    {
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
