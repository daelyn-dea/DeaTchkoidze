// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Authentications.RequestModels;
using Swashbuckle.AspNetCore.Filters;

namespace Forum.API.Infrastructure.Examples
{
    /// <summary>
    /// Provides examples for the <see cref="RequestLoginModel"/> class.
    /// </summary>
    public class RequestLoginModelExample : IExamplesProvider<RequestLoginModel>
    {
        /// <summary>
        /// Gets an example of a <see cref="RequestLoginModel"/>.
        /// </summary>
        /// <returns>An example <see cref="RequestLoginModel"/>.</returns>
        public RequestLoginModel GetExamples()
        {
            return new RequestLoginModel
            {
                Username = "Dea98",
                Password = "Didi12@",
                RememberLogin = true
            };
        }
    }
}
