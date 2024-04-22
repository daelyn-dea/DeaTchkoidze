// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Comments.ResponseModels;

namespace Forum.Application.Topics.ResponseModels
{
    public class AdminImagedTopicModel: TopicsModel
    {
        public string? ImageUrl { get; set; }
        public List<CommentResponseModelWithDelete>? Comments { get; set; }
    }
}
