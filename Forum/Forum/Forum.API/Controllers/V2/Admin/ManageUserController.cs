// Copyright (C) TBC Bank. All Rights Reserved.

using Asp.Versioning;
using Forum.Application.Infrastructure.Helpers;
using Forum.Application.Users.AdminServices;
using Forum.Application.Users.Models.ResponseModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.API.Controllers.Admin
{
    /// <summary>
    /// Controller for managing user-related operations by admins in the forum API.
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/manage-users")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "Admin")]
    public class ManageUserController : ControllerBase
    {
        private readonly IAdminService _iAdminService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManageUserController"/> class.
        /// </summary>
        /// <param name="iAdminService">The service for managing admin operations.</param>
        public ManageUserController(IAdminService iAdminService) => _iAdminService = iAdminService;

        /// <summary>
        /// Blocks a user.
        /// </summary>
        /// <param name="userId">The ID of the user to block.</param>
        [HttpPost("block")]
        public async Task BlockUser(string userId)
        {
            await _iAdminService.BlockUser(userId).ConfigureAwait(false);
        }

        /// <summary>
        /// Unblocks a user.
        /// </summary>
        /// <param name="userId">The ID of the user to unblock.</param>
        [HttpPost("unblock")]
        public async Task UnBlockUser(string userId)
        {
            await _iAdminService.UnBlockUser(userId).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves all users and information about them.
        /// </summary>
        /// <param name="pageNumber">The page number for pagination.</param>
        /// <param name="pageSize">The size of each page.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A paged list of user response models for admin.</returns>
        [HttpGet]
        public async Task<PagedList<UserResponseModelForAdmin>> GetAllUser(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return await _iAdminService.GetAllUser(pageNumber, pageSize, cancellationToken).ConfigureAwait(false);
        }
    }
}
