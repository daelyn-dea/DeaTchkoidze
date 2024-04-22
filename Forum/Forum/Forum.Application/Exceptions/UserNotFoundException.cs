// Copyright (C) TBC Bank. All Rights Reserved.

namespace Forum.Application.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public readonly string Code = "UserNotFound";

        public UserNotFoundException(string message = "User not found.") : base(message)
        {
        }
    }
}
