// Copyright (C) TBC Bank. All Rights Reserved.

namespace Forum.API.Infrastructure.Authentication
{
    /// <summary>
    /// Represents a response containing a JWT token and its expiration time.
    /// </summary>
    public class JwtTokenResponse
    {
        /// <summary>
        /// Gets or sets the JWT token.
        /// </summary>
        public string JWTToken { get; set; } = default!;
        /// <summary>
        /// Gets or sets the expiration time of the JWT token.
        /// </summary>
        public int ExpirationTime { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="JwtTokenResponse"/> class with the specified JWT token and expiration time.
        /// </summary>
        /// <param name="jwtToken">The JWT token.</param>
        /// <param name="expirationTime">The expiration time of the JWT token.</param>
        public JwtTokenResponse(string jwtToken, int expirationTime)
        {
            JWTToken = jwtToken;
            ExpirationTime = expirationTime;
        }
    }
}
