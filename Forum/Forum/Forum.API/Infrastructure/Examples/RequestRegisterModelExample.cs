// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Authentications.RequestModels;
using Swashbuckle.AspNetCore.Filters;

namespace Forum.API.Infrastructure.Examples
{
    /// <summary>
    /// Provides examples for the <see cref="RequestRegisterModel"/> class.
    /// </summary>
    public class RequestRegisterModelExample : IExamplesProvider<RequestRegisterModel>
    {
        /// <summary>
        /// Gets an example of a <see cref="RequestRegisterModel"/>.
        /// </summary>
        /// <returns>An example <see cref="RequestRegisterModel"/>.</returns>
        public RequestRegisterModel GetExamples()
        {
            return new RequestRegisterModel
            {
                Email = "example@example.com",
                UserName = "Dea100",
                Password = "Didi12!",
                ConfirmPassword = "Didi12!",
                Name = "Dea",
                LastName = "Tchkoidze",
                BirthDate = new DateTime(1998, 5, 15)
            };
        }
    }
}
