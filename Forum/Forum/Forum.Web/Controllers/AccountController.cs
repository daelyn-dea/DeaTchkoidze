// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Authentications;
using Forum.Application.Authentications.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserManagementService _userManagementService;
        public AccountController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }
        public IActionResult Login()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] RequestLoginModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _userManagementService.PasswordSignInAsync(model.Username, model.Password, false, false).ConfigureAwait(false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to login. Invalid username or password.");
                return View(model);
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromForm] RequestRegisterModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _userManagementService.CreateUserAsync(model).ConfigureAwait(false);

            if (result.Succeeded)
                return RedirectToAction(nameof(Login));

            ModelState.AddModelError(string.Empty, "Failed to registration. Try again");
            return View(result);
        }
        public async Task<IActionResult> Logout()
        {
            await _userManagementService.SignOutAsync().ConfigureAwait(false);

            return RedirectToAction("Index", "Home");
        }
    }
}
