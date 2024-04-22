// Copyright (C) TBC Bank. All Rights Reserved.

namespace Forum.Application.Users.Models.ResponseModels
{
    public class UserResponseModelForAdmin : UserAccountModel
    {
        public string Id { get; set; } = default!;
        public int TotalComments { get; set; }
        public int TotalTopics { get; set; }
        public bool IsBlocked { get; set; }
    }
}
