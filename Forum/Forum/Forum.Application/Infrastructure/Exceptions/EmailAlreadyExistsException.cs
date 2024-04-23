// Copyright (C) TBC Bank. All Rights Reserved.

namespace Forum.Application.Infrastructure.Exceptions
{
    public class EmailAlreadyExistsException : Exception
    {
        public readonly string Code = "EmailAlreadyExists";

        public EmailAlreadyExistsException(string message = "Email already exists") : base(message)
        {
        }
    }
}
