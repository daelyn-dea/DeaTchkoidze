// Copyright (C) TBC Bank. All Rights Reserved.

namespace Forum.Application.Infrastructure.Exceptions
{
    public class FailedUpdateException : Exception
    {
        public readonly string Code = "FailesUpdate";

        public FailedUpdateException(string message = "Failed to update user info") : base(message)
        {
        }
    }
}
