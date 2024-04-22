// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Exceptions;
using Forum.Application.Helpers;
using Forum.Application.Topics.ResponseModels;
using Forum.Application.Users.Models.ResponseModels;
using Forum.Domain.Users;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace Forum.Application.Users.AdminServices
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepository;

        public AdminService(UserManager<User> userManager, IUserRepository userRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
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
                throw new UserAlreadyIsBlockedException("User Is not blocked");

            user.IsBlocked = false;
            user.BlockedTime = null;

            var result = await _userManager.UpdateAsync(user).ConfigureAwait(false);
            if (!result.Succeeded)
                throw new FailedUserBlockedException("Failed  UnBlocked user");
        }
        public async Task<PagedList<UserResponseModelForAdmin>> GetAllUser(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var userSummary = await _userRepository.GetAllUser(pageNumber, pageSize, cancellationToken).ConfigureAwait(false);

            if (userSummary.Items == null || !userSummary.Items.Any())
                throw new UserNotFoundException();

            return userSummary.Adapt<PagedList<UserResponseModelForAdmin>>();
        }
    }
}
