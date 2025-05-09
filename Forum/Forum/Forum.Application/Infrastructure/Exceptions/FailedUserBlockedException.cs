﻿// Copyright (C) TBC Bank. All Rights Reserved.

namespace Forum.Application.Infrastructure.Exceptions
{
    public class FailedUserBlockedException : Exception
    {
        public readonly string Code = "FailedUserBlocked";

        public FailedUserBlockedException(string message = "Failed user blocked") : base(message)
        {
        }
    }
}
