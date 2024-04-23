// Copyright (C) TBC Bank. All Rights Reserved.

namespace Forum.Application.Infrastructure.Exceptions
{
    public class UserNameAlreadyExistsException : Exception
    {
        public readonly string Code = "UserNameAlreadyExists";

        public UserNameAlreadyExistsException(string message = "Username already exists") : base(message)
        {
        }
    }
}
