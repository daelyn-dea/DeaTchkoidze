// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Exceptions;
using Forum.Application.Helpers;
using Forum.Application.Users.Models.ResponseModels;
using Forum.Application.Users.Models.UpdateModel;
using Forum.Application.Users.UserServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.API.Controllers.User
{
    /// <summary>
    /// Controller for managing user-related operations in the forum API.
    /// </summary>
    [Route("api/user")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "User")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userManagementService">The service for managing users.</param>
        public UserController(IUserService userManagementService) => _userService = userManagementService;

        /// <summary>
        /// Updates user information.
        /// </summary>
        /// <param name="model">The model containing the updated user information.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        [HttpPatch]
        public async Task UpdateUserInfo([FromForm] UpdateModel model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                throw new LoginFailedException();

            var claims = User;
            await _userService.UpdateUserInfo(model, claims, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates user password.
        /// </summary>
        /// <param name="model">The model containing the updated password information.</param>
        [HttpPatch("password")]
        public async Task UpdatePassword(UpdatePassword model)
        {
            if (!ModelState.IsValid)
                throw new LoginFailedException();

            var claims = User;
            await _userService.UpdatePassword(model, claims).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves topics of a user by email.
        /// </summary>
        /// <param name="pageNumber">The page number for pagination.</param>
        /// <param name="pageSize">The size of each page.</param>
        /// <param name="email">The email of the user to retrieve.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A paged list of users with topics.</returns>
        [AllowAnonymous]
        [HttpGet("email")]
        public async Task<PagedList<UserWithTopics>> GetUser(int pageNumber, int pageSize, string email, CancellationToken cancellationToken)
        {
            return await _userService.GetUserAsync(pageNumber, pageSize, email, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves topics of a user by email.
        /// </summary>
        /// <param name="pageNumber">The page number for pagination.</param>
        /// <param name="pageSize">The size of each page.</param>
        /// <param name="userName">The username of the user to retrieve.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A paged list of users with topics.</returns>
        [AllowAnonymous]
        [HttpGet("username")]
        public async Task<PagedList<UserWithTopics>> GetUserByName(int pageNumber, int pageSize, string userName, CancellationToken cancellationToken)
        {
            return await _userService.GetUserByNameAsync(pageNumber, pageSize, userName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves the profile and all information of the current user.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The profile of the current user.</returns>
        [HttpGet("profile")]
        public async Task<UserAccountModel> GetUserProfile(CancellationToken cancellationToken)
        {
            var claims = User;
            return await _userService.GetProfileOfUserAsync(claims, cancellationToken).ConfigureAwait(false);
        }
    }
}
