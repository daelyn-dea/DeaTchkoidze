// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Authentications.RequestModels;
using Swashbuckle.AspNetCore.Filters;

namespace Forum.API.Infrastructure.Examples
{
    public class RequestLoginModelExample : IExamplesProvider<RequestLoginModel>
    {
        public RequestLoginModel GetExamples()
        {
            return new RequestLoginModel
            {
                Username = "Deakaigogoa",
                Password = "Didi12@",
                RememberLogin = true
            };
        }
    }
}
