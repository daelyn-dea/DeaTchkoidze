// Copyright (C) TBC Bank. All Rights Reserved.

namespace Forum.Application.Topics.ResponseModels
{
    public class TopicsModel
    {
        public TopicsModel()
        {
            
        }
        public string Id { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; } = default!;
        public string? UserImageUrl { get; set; }
    }
}
