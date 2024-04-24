// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Infrastructure.Helpers;
using Forum.Application.Users.Models.ResponseModels;
using Swashbuckle.AspNetCore.Filters;

namespace Forum.API.Infrastructure.Examples
{
    public class PagedListUserResponseModelForAdminExample : IExamplesProvider<PagedList<UserResponseModelForAdmin>>
    {
        public PagedList<UserResponseModelForAdmin> GetExamples()
        {
            var user1 = new UserResponseModelForAdmin
            {
                Id = "1dsaf-ads3-afs3-fdsf",
                CreatedAt = DateTime.Now.AddDays(-30),
                Name = "Lika",
                LastName = "Maghlakelidze",
                BirthDate = new DateTime(1990, 5, 15),
                IsBlocked = false,
                UserName = "Liku123",
                Email = "Lika.doe@example.com"
            };

            var user2 = new UserResponseModelForAdmin
            {
                Id = "djhs2-vskjdb3-sfjsdn2-sfjln",
                CreatedAt = DateTime.Now.AddDays(-20),
                Name = "Dea",
                LastName = "Tchkoidze",
                BirthDate = new DateTime(1995, 10, 20),
                IsBlocked = true,
                UserName = "Dealo345",
                Email = "Dea.doe@example.com"
            };

            var users = new List<UserResponseModelForAdmin> { user1, user2 };

            return new PagedList<UserResponseModelForAdmin>(
                items: users,
                count: users.Count,
                pageNumber: 1,
                pageSize: 10
            );
        }
    }
}
