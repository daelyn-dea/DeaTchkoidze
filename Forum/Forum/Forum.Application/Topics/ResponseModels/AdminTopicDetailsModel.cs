// Copyright (C) TBC Bank. All Rights Reserved.

using static Forum.Domain.Topics.TopicStatusEnum;
using static Forum.Domain.Topics.TopicStateEnum;

namespace Forum.Application.Topics.ResponseModels
{
    public class AdminTopicDetailsModel : TopicsModel
    {
        public int TopicsCommentCount { get; set; }
        public DbTopicState State { get; set; }
        public TopicStatus Status { get; set; }
        public string UserId { get; set; } = default!;
    }
}
