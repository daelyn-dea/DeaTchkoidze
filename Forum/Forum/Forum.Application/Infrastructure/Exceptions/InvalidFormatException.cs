// Copyright (C) TBC Bank. All Rights Reserved.

namespace Forum.Application.Infrastructure.Exceptions
{
    public class InvalidFormatException : Exception
    {
        public readonly string Code = "InvalidFormatOfImage";

        public InvalidFormatException(string message = "Image format is not valid") : base(message)
        {
        }
    }
}
