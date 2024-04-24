// Copyright (C) TBC Bank. All Rights Reserved.

namespace Forum.Application.Users.Models.ResponseModels
{
    public class UserAccountModel
    {
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Email { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string? ImageUrl { get; set; }
    }
}
