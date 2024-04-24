// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Users.AdminServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Web.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class ManageUserController : Controller
    {
        private readonly IAdminService _iAdminService;
        public ManageUserController(IAdminService iAdminService) => _iAdminService = iAdminService;
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser(CancellationToken cancellationToken, int pageNumber = 1, int pageSize = 15)
        {
            var users = await _iAdminService.GetAllUser(pageNumber, pageSize, cancellationToken).ConfigureAwait(false);
            return View(users);
        }

        public async Task<IActionResult> UnBlockUser(string userId)
        {
            await _iAdminService.UnBlockUser(userId).ConfigureAwait(false);
            return RedirectToAction(nameof(GetAllUser));
        }

        public async Task<IActionResult> BlockUser(string userId)
        {
            await _iAdminService.BlockUser(userId).ConfigureAwait(false);
            return RedirectToAction(nameof(GetAllUser));
        }
    }
}
