// Copyright (C) TBC Bank. All Rights Reserved.

namespace Forum.Application.Exceptions
{
    public class PhotoNotFoundException : Exception
    {
        public readonly string Code = "PhotoNotFound";

        public PhotoNotFoundException(string message = "Photo Not Found") : base(message)
        {
        }
    }
}
