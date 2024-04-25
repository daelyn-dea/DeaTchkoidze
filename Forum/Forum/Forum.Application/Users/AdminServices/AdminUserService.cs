// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Infrastructure.Exceptions;
using Forum.Application.Infrastructure.Helpers;
using Forum.Application.Users.Interfaces;
using Forum.Application.Users.Models.ResponseModels;
using Forum.Domain.Users;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace Forum.Application.Users.AdminServices
{
    public class AdminUserService : IAdminUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IAdminRepository _userRepository;

        public AdminUserService(UserManager<User> userManager, IAdminRepository userRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }
        public async Task<PagedList<UserResponseModelForAdmin>> GetAllUser(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            if (pageNumber <= 0)
                throw new PageNotFoundException();

            var userSummary = await _userRepository.GetAllUser(pageNumber, pageSize, cancellationToken).ConfigureAwait(false);

            if (pageNumber > userSummary.TotalPages)
                throw new PageNotFoundException();

            if (userSummary.Items == null || !userSummary.Items.Any())
                throw new UserNotFoundException();

            return userSummary.Adapt<PagedList<UserResponseModelForAdmin>>();
        }

        public async Task BlockUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId).ConfigureAwait(false);

            user = user ?? throw new UserNotFoundException();

            if (user.IsBlocked)
                throw new UserAlreadyIsBlockedException();

            user.IsBlocked = true;
            user.BlockedTime = DateTime.UtcNow;

            var result = await _userManager.UpdateAsync(user).ConfigureAwait(false);
            if (!result.Succeeded)
                throw new FailedUserBlockedException();
        }

        public async Task UnBlockUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId).ConfigureAwait(false);

            user = user ?? throw new UserNotFoundException();

            if (!user.IsBlocked)
                throw new UserAlreadyIsBlockedException();

            user.IsBlocked = false;
            user.BlockedTime = null;

            var result = await _userManager.UpdateAsync(user).ConfigureAwait(false);
            if (!result.Succeeded)
                throw new FailedUserBlockedException();
        }
    }
}
