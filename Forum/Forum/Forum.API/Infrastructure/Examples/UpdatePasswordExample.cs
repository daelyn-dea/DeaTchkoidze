// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Users.Models.UpdateModel;
using Swashbuckle.AspNetCore.Filters;

namespace Forum.API.Infrastructure.Examples
{
    /// <summary>
    /// Provides examples for updating a user's password.
    /// </summary>
    public class UpdatePasswordExample : IExamplesProvider<UpdatePassword>
    {
        /// <summary>
        /// Gets an example of an <see cref="UpdatePassword"/> model.
        /// </summary>
        /// <returns>An example <see cref="UpdatePassword"/> model.</returns>
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
