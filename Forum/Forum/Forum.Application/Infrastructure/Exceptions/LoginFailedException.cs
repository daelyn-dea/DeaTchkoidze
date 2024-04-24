// Copyright (C) TBC Bank. All Rights Reserved.

namespace Forum.Application.Infrastructure.Exceptions
{
    public class LoginFailedException : Exception
    {
        public readonly string Code = "LoginFailed";

        public LoginFailedException(string message = "Login failed") : base(message)
        {
        }
    }
}
