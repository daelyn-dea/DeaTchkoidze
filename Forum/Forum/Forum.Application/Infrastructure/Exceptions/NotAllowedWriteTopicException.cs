// Copyright (C) TBC Bank. All Rights Reserved.

namespace Forum.Application.Infrastructure.Exceptions
{
    public class NotAllowedWriteTopicException : Exception
    {
        public readonly string Code = "NotAllowedWriteTopic";

        public NotAllowedWriteTopicException(string message = "You are not allowed to write a comment") : base(message)
        {
        }
    }
}
