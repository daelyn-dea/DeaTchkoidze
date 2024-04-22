// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Domain.Users;

namespace Forum.Application.Users.Models.ResponseModels
{
    public class UserSummary
    {
        public User UserEntity { get; set; } = default!;
        public int TotalComments { get; set; }
        public int TotalTopics { get; set; }
    }
}
