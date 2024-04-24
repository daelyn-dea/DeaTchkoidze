// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Topics.ResponseModels;
using Forum.Domain.Users;

namespace Forum.Application.Users.Models.ResponseModels
{
    public class UserTopicsSummary
    {
        public User User { get; set; } = default!;
        public List<TopicWithCommentCount> Topics { get; set; } = default!;
    }
}
