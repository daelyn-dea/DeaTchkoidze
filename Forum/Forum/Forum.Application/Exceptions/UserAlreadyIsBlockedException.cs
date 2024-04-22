// Copyright (C) TBC Bank. All Rights Reserved.

namespace Forum.Application.Exceptions
{
    public class UserAlreadyIsBlockedException : Exception
    {
        public readonly string Code = "UserIsBlocked";

        public UserAlreadyIsBlockedException(string message = "User already is blocked") : base(message)
        {
        }
    }
}
