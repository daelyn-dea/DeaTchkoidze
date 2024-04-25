// Copyright (C) TBC Bank. All Rights Reserved.

namespace Forum.Application.Infrastructure.Exceptions
{
    public class NotAllowedWriteTopicException : Exception
    {
        public readonly string Code = "NotAllowedWriteTopic";

        public NotAllowedWriteTopicException(string message = "Your message could not be saved. Try again later") : base(message)
        {
        }
    }
}
