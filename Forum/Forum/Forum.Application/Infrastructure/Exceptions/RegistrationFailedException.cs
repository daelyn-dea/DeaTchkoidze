// Copyright (C) TBC Bank. All Rights Reserved.

namespace Forum.Application.Infrastructure.Exceptions
{
    public class RegistrationFailedException : Exception
    {
        public readonly string Code = "UserRegistrationFailed";

        public RegistrationFailedException(string message = "User registration failed") : base(message)
        {
        }
    }
}
