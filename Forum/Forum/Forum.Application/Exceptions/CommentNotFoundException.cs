// Copyright (C) TBC Bank. All Rights Reserved.

namespace Forum.Application.Exceptions
{
    public class CommentNotFoundException : Exception
    {
        public readonly string Code = "CommentNotFound";

        public CommentNotFoundException(string message = "Comment Not Found") : base(message)
        {
        }
    }
}
