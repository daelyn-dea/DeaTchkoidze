// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Domain.Topics;

namespace Forum.Application.Topics.ResponseModels
{
    public class TopicWithCommentCount
    {
        public Topic Topic { get; set; } = default!;
        public int CommentCount { get; set; }
        public string UserName { get; set; } = default!;
        public string UserImageUrl { get; set; } = default!;
    }
}
