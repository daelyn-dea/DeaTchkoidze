// Copyright (C) TBC Bank. All Rights Reserved.

using Asp.Versioning;
using Forum.Application.Infrastructure.Helpers;
using Forum.Application.Users.Models.ResponseModels;
using Forum.Application.Users.Models.UpdateModel;
using Forum.Application.Users.UserServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.API.Controllers.V2.User
{
    /// <summary>
    /// Controller for managing user-related operations in the forum API.
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/user")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        [Authorize(Roles = "User")]
        [HttpPut("profile-info")]
        public async Task UpdateUserInfo([FromForm] UpdateModel model, CancellationToken cancellationToken)
        {
            await _userService.UpdateUserInfo(model, User, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates user password.
        /// </summary>
        /// <param name="model">The model containing the updated password information.</param>
        [Authorize(Roles = "Admin, User")]
        [HttpPut("password")]
        public async Task UpdatePassword(UpdatePassword model)
        {
            await _userService.UpdatePassword(model, User).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete user profile picture.
        /// </summary>
        [Authorize(Roles = "User")]
        [HttpDelete("profile-picture")]
        public async Task DeleteProfilePicture()
        {
            await _userService.DeleteProfilePicture(User).ConfigureAwait(false);
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
        [HttpGet("by-email")]
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
        [HttpGet("by-username")]
        public async Task<PagedList<UserWithTopics>> GetUserByName(int pageNumber, int pageSize, string userName, CancellationToken cancellationToken)
        {
            return await _userService.GetUserByNameAsync(pageNumber, pageSize, userName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves the profile and all information of the current user.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The profile of the current user.</returns>
        [Authorize(Roles = "Admin, User")]
        [HttpGet("profile")]
        public async Task<UserAccountModel> GetUserProfile(CancellationToken cancellationToken)
        {
            return await _userService.GetProfileOfUserAsync(User, cancellationToken).ConfigureAwait(false);
        }
    }
}
