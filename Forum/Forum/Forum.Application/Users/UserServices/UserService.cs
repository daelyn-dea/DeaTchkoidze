// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Infrastructure.Exceptions;
using Forum.Application.Images;
using Forum.Application.Infrastructure.Helpers;
using Forum.Application.Topics.ResponseModels;
using Forum.Application.Users.Interfaces;
using Forum.Application.Users.Models.ResponseModels;
using Forum.Application.Users.Models.UpdateModel;
using Forum.Domain.Users;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace Forum.Application.Users.UserServices
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IImagesRepository _imagesRepository;
        private readonly IUserRepository _userRepository;

        public UserService(UserManager<User> userManager, IConfiguration configuration, IImagesRepository imagesRepository, IUserRepository userRepository)
        {
            _userManager = userManager;
            _configuration = configuration;
            _imagesRepository = imagesRepository;
            _userRepository = userRepository;
        }

        public async Task<UserAccountModel> GetProfileOfUserAsync(ClaimsPrincipal claimsPrincipal, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(claimsPrincipal).ConfigureAwait(false);

            if (user == null)
                throw new UserNotFoundException();

            var userAccountModel = user.Adapt<UserAccountModel>();

            return userAccountModel;
        }

        public async Task<PagedList<UserWithTopics>> GetUserAsync(int pageNumber, int pageSize, string email, CancellationToken cancellationToken)
        {
            if (pageNumber <= 0)
                throw new PageNotFoundException();

            var userWithTopics = await _userRepository.GetUserAsync(pageNumber, pageSize, email, cancellationToken).ConfigureAwait(false);

            if (pageNumber > userWithTopics.TotalPages)
                throw new PageNotFoundException();

            if (userWithTopics.Item == null)
                throw new UserNotFoundException();

            var userResponseModel = userWithTopics.Item.User.Adapt<UserWithTopics>();

            userResponseModel.Topics = userWithTopics.Item.Topics.Adapt<List<UserTopicDetailsModel>>();

            var pagedList = new PagedList<UserWithTopics>(userResponseModel, userWithTopics.TotalCount, pageNumber, pageSize);

            return pagedList;
        }

        public async Task<PagedList<UserWithTopics>> GetUserByNameAsync(int pageNumber, int pageSize, string userName, CancellationToken cancellationToken)
        {
            if (pageNumber <= 0)
                throw new PageNotFoundException();

            var userWithTopics = await _userRepository.GetUserByNameAsync(pageNumber, pageSize, userName, cancellationToken).ConfigureAwait(false);

            if (pageNumber > userWithTopics.TotalPages)
                throw new PageNotFoundException();

            if (userWithTopics.Item == null)
                throw new UserNotFoundException();

            var userResponseModel = userWithTopics.Item.User.Adapt<UserWithTopics>();

            userResponseModel.Topics = userWithTopics.Item.Topics.Adapt<List<UserTopicDetailsModel>>();

            var pagedList = new PagedList<UserWithTopics>(userResponseModel, userWithTopics.TotalCount, pageNumber, pageSize);

            return pagedList;
        }

        public async Task UpdatePassword(UpdatePassword password, ClaimsPrincipal claimsPrincipal)
        {
            var user = await _userManager.GetUserAsync(claimsPrincipal).ConfigureAwait(false);
            var result = await _userManager.ChangePasswordAsync(user, password.OldPassword, password.NewPassword).ConfigureAwait(false);
            if (!result.Succeeded)
                throw new FailedUpdateException("Failed to update password");
        }

        public async Task UpdateUserInfo(UpdateModel updateModel, ClaimsPrincipal claimsPrincipal, CancellationToken cancellationToken)
        {
            var userBefore = await _userManager.GetUserAsync(claimsPrincipal).ConfigureAwait(false);

            if (userBefore == null)
                throw new UserNotFoundException();

            await UpdateInfo(updateModel, userBefore, cancellationToken).ConfigureAwait(false);

            var result = await _userManager.UpdateAsync(userBefore).ConfigureAwait(false);

            if (!result.Succeeded)
                throw new FailedUpdateException();
        }
        public async Task DeleteProfilePicture(ClaimsPrincipal claimsPrincipal)
        {
            var userBefore = await _userManager.GetUserAsync(claimsPrincipal).ConfigureAwait(false);

            if (userBefore == null)
                throw new UserNotFoundException();

            userBefore.ImageUrl = "/UserImages/Default.jpg";

            var result = await _userManager.UpdateAsync(userBefore).ConfigureAwait(false);

            if (!result.Succeeded)
                throw new FailedUpdateException();
        }

        public async Task<bool> AccessOfPostTopic(string userId, CancellationToken cancellationToken)
        {
            return await _userRepository.AccessOfPostTopic(userId, cancellationToken).ConfigureAwait(false);
        }

        private async Task UpdateInfo(UpdateModel updateModel, User userBefore, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(updateModel.UserName))
            {
                var existingUser = await _userManager.FindByNameAsync(updateModel.UserName).ConfigureAwait(false);
                if (existingUser != null && existingUser.Id != userBefore.Id)
                    throw new UserNameAlreadyExistsException();
                userBefore.UserName = updateModel.UserName;
            }

            if (!string.IsNullOrEmpty(updateModel.Email))
            {
                var existingUser = await _userManager.FindByEmailAsync(updateModel.Email).ConfigureAwait(false);
                if (existingUser != null && existingUser.Id != userBefore.Id)

                    throw new EmailAlreadyExistsException();

                userBefore.Email = updateModel.Email;
            }
            if (!string.IsNullOrEmpty(updateModel.Name))
                userBefore.Name = updateModel.Name;

            if (!string.IsNullOrEmpty(updateModel.LastName))
                userBefore.LastName = updateModel.LastName;

            if (updateModel.BirthDate.HasValue)
                userBefore.BirthDate = updateModel.BirthDate.Value;

            if (updateModel.Image != null && updateModel.Image.Length > 0)
            {
                var savePath = _configuration.GetValue<string>("UserImagesConfiguration:SavePath");
                var requestPath = _configuration.GetValue<string>("UserImagesConfiguration:RequestPath");

                string imageName, imageUrl;

                ImageFileHelper.GenerateUrl(updateModel.Image.FileName, savePath, out imageName, out imageUrl);

                await _imagesRepository.SaveImageAsync(updateModel.Image, savePath, imageUrl, cancellationToken).ConfigureAwait(false);

                userBefore.ImageUrl = $"{requestPath}/{imageName}";
            }
        }

    }
}
