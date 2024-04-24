// Copyright (C) TBC Bank. All Rights Reserved.

namespace Forum.API.Infrastructure.Authentication
{
    public class JwtTokenResponse
    {
        public string JWTToken { get; set; } = default!;
        public int ExpirationTime { get; set; }

        public JwtTokenResponse(string jwtToken, int expirationTime)
        {
            JWTToken = jwtToken;
            ExpirationTime = expirationTime;
        }
    }
}
