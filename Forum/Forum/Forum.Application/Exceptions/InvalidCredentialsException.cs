// Copyright (C) TBC Bank. All Rights Reserved.

namespace Forum.Application.Exceptions
{
    public class InvalidCredentialsException : Exception
    {
        public readonly string Code = "PasswordOrUsernameIncorrect";

        public InvalidCredentialsException(string message = "Password or Username is incorrect") : base(message)
        {
        }
    }
}
