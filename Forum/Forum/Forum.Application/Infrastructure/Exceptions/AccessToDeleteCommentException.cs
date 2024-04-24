// Copyright (C) TBC Bank. All Rights Reserved.

namespace Forum.Application.Infrastructure.Exceptions
{
    public class AccessToDeleteCommentException : Exception
    {
        public readonly string Code = "Don'tHavePermissionToDeleteComment";

        public AccessToDeleteCommentException(string message = "you don't have permission to delete comment") : base(message)
        {
        }
    }
}
