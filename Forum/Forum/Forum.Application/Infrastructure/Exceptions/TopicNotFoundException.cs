// Copyright (C) TBC Bank. All Rights Reserved.

namespace Forum.Application.Infrastructure.Exceptions
{
    public class TopicNotFoundException : Exception
    {
        public readonly string Code = "TopicNotFound";

        public TopicNotFoundException(string message = "Topic Not Found") : base(message)
        {
        }
    }
}
