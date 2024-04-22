// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Topics.ResponseModels;

namespace Forum.Application.Users.Models.ResponseModels
{
    public class UserWithTopics
    {
        public string Email { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public List<UserTopicDetailsModel>? Topics { get; set; }
        public string? ImageUrl { get; set; }

    }
}
