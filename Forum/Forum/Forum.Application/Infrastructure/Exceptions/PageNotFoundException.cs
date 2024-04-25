// Copyright (C) TBC Bank. All Rights Reserved.

namespace Forum.Application.Infrastructure.Exceptions
{
    public class PageNotFoundException : Exception
    {
        public readonly string Code = "PageNotFound";

        public PageNotFoundException(string message = "Page not found.") : base(message)
        {
        }
    }
}
