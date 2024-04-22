// Copyright (C) TBC Bank. All Rights Reserved.

namespace Forum.Application.Users.Models.UpdateModel
{
    public class UpdatePassword
    {
        public string OldPassword { get; set; } = default!;
        public string NewPassword { get; set; } = default!;
        public string ConfirmPassword { get; set; } = default!;
    }
}
