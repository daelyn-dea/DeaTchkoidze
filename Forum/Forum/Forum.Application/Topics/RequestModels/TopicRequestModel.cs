// Copyright (C) TBC Bank. All Rights Reserved.

using Microsoft.AspNetCore.Http;

namespace Forum.Application.Topics.RequestModels
{
    public class TopicRequestModel
    {
        public IFormFile? Image { get; set; }
        public string Title { get; set; } = default!;
    }
}
