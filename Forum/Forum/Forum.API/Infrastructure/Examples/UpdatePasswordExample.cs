// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Users.Models.UpdateModel;
using Swashbuckle.AspNetCore.Filters;

namespace Forum.API.Infrastructure.Examples
{
    public class UpdatePasswordExample : IExamplesProvider<UpdatePassword>
    {
        public UpdatePassword GetExamples()
        {
            return new UpdatePassword
            {
                OldPassword = "Didi12!",
                NewPassword = "DidiNew12#",
                ConfirmPassword = "DidiNew12#"
            };
        }
    }
}
