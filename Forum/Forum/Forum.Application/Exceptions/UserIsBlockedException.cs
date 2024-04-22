// Copyright (C) TBC Bank. All Rights Reserved.

namespace Forum.Application.Exceptions
{
    public class UserIsBlockedException : Exception
    {
        public readonly string Code = "UserIsBlocked";

        public UserIsBlockedException(string message = "User is blocked for 3 days") : base(message)
        {
        }
    }
}
