// Copyright (C) TBC Bank. All Rights Reserved.

namespace Forum.Application.Authentications.ResponseModel
{
    public class ResponseLoginModel
    {
        public string Id { get; set; } = default!;
        public string Username { get; set; } = default!;
        public IList<string> Role { get; set; } = default!;
    }
}
