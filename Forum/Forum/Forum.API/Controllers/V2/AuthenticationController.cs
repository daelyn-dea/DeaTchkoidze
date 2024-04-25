using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Forum.API.Infrastructure.Authentication;
using Forum.Application.Authentications.RequestModels;
using Forum.Application.Authentications;
using Asp.Versioning;

namespace Forum.API.Controllers.V2
{
    /// <summary>
    /// Controller responsible for handling user authentication.
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/authentication")]
	public class AuthenticationController : ControllerBase
	{
		private readonly IUserManagementService _userManagementService;
		private readonly IOptions<AuthenticationConfiguration> _authenticationOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationController"/> class.
        /// </summary>
        /// <param name="userManagementService">The user management service.</param>
        /// <param name="authenticationOptions">The authentication options.</param>
        public AuthenticationController(IUserManagementService userManagementService, IOptions<AuthenticationConfiguration> authenticationOptions)
		{
			_userManagementService = userManagementService;
			_authenticationOptions = authenticationOptions;
		}

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="registerRequestModel">The registration request model.</param>
        /// <returns>A task representing the asynchronous operation of registration.</returns>
		[HttpPost("register")]
		public async Task RegisterUser(RequestRegisterModel registerRequestModel)
		{
         await _userManagementService.CreateUserAsync(registerRequestModel).ConfigureAwait(false);

		}

        /// <summary>
        /// Logs in a user and generates a JWT token.
        /// </summary>
        /// <param name="model">The login request model.</param>
        /// <returns>The generated JWT token response.</returns>
		[HttpPost("login")]
		public async Task<JwtTokenResponse> LoginUser(RequestLoginModel model)
		{
            var user = await _userManagementService.LoginAsync(model).ConfigureAwait(false);

            var jwtToken = JwtTokenGenerator.GenerateToken(user.Username, user.Id, user.Role, _authenticationOptions);
            var expirationTime = _authenticationOptions.Value.JwtExpirationInMinutes;

            return new JwtTokenResponse(jwtToken, expirationTime);
        }
    }
}
