// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Authentications.RequestModels;
using Swashbuckle.AspNetCore.Filters;

namespace Forum.API.Infrastructure.Examples
{
    public class RequestRegisterModelExample : IExamplesProvider<RequestRegisterModel>
    {
        public RequestRegisterModel GetExamples()
        {
            return new RequestRegisterModel
            {
                Email = "example@example.com",
                UserName = "Dea98",
                Password = "3xamp!3",
                ConfirmPassword = "3xamp!3",
                Name = "Dea",
                LastName = "Tchkoidze",
                BirthDate = new DateTime(1998, 5, 15)
            };
        }
    }
}
