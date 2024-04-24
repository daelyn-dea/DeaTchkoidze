using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using ToDo.API.Infrastructure.Authentication;
using ToDo.Application.Users;
using ToDo.Application.Users.RequestModels;
using ToDo.Application.Users.ResponseModels;

namespace ToDo.API.Controllers
{

    /// <summary>
    /// Controller for managing user authentication and registration.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class usersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IOptions<AuthenticationConfiguration> _authOptions;

        public usersController(IUserService userService, IOptions<AuthenticationConfiguration> authOptions)
        {
            _userService = userService;
            _authOptions = authOptions;
        }

        /// <summary>
        /// Endpoint for user login.
        /// </summary>
        /// <param name="user">The user credentials.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The JWT token for the authenticated user.</returns>
        [Route("login")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<string> Login(UserRequestPostModel user, CancellationToken cancellationToken)
        {
            var result = await _userService.LoginAsync(user, cancellationToken);

            return JwtTokenGenerator.GenerateToken(result.Username, result.Id.ToString(), _authOptions);
        }

        /// <summary>
        /// Endpoint for user registration.
        /// </summary>
        /// <param name="user">The user data to register.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [Route("register")]
        [AllowAnonymous]
        [HttpPost]
        public async Task Register(UserRequestPostModel user, CancellationToken cancellationToken)
        {
            await _userService.RegisterAsync(user, cancellationToken).ConfigureAwait(false);
        }
    }
}
