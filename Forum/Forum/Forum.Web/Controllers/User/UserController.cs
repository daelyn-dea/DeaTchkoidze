// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Infrastructure.Exceptions;
using Forum.Application.Users.Models.UpdateModel;
using Forum.Application.Users.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Web.Controllers.User
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userManagementService) => _userService = userManagementService;

        [AllowAnonymous]
        public async Task<IActionResult> GetUserByName(string userName, CancellationToken cancellationToken, int pageNumber = 1, int pageSize = 8)
        {
            var user = await _userService.GetUserByNameAsync(pageNumber, pageSize, userName, cancellationToken).ConfigureAwait(false);
            return View(user);
        }

        [AllowAnonymous]
        public async Task<IActionResult> GetUser(string email, CancellationToken cancellationToken, int pageNumber = 1, int pageSize = 8)
        {
            var user = await _userService.GetUserAsync(pageNumber, pageSize, email, cancellationToken).ConfigureAwait(false);
            return View(user);
        }

        [AllowAnonymous]
        public async Task<IActionResult> GetUserProfile(CancellationToken cancellationToken)
        {
            var claims = User;
            var user = await _userService.GetProfileOfUserAsync(claims, cancellationToken).ConfigureAwait(false);
            return View(user);
        }

        [Authorize(Roles = "User,Admin")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> EditPassword(UpdatePassword model)
        {
            if (!ModelState.IsValid)
                throw new LoginFailedException();

            var claims = User;
            await _userService.UpdatePassword(model, claims).ConfigureAwait(false);

            return RedirectToAction(nameof(GetUserProfile));
        }

        [Authorize(Roles = "User")]
        [HttpGet("editprofile")]
        public IActionResult EditProfile()
        {
            return View();
        }

        [Authorize(Roles = "User")]
        public async Task<IActionResult> UpdateUserInfo([FromForm] UpdateModel model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                throw new LoginFailedException();

            var claims = User;
            await _userService.UpdateUserInfo(model, claims, cancellationToken).ConfigureAwait(false);

            return RedirectToAction(nameof(GetUserProfile));
        }
    }
}
