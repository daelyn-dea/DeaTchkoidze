using Forum.Domain.Users;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Forum.Application.Exceptions;
using Forum.Application.Authentications.RequestModels;
using Forum.Application.Authentications.ResponseModel;

namespace Forum.Application.Authentications
{
    public class UserManagementService : IUserManagementService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserManagementService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateUserAsync(RequestRegisterModel registerUser)
        {
            var existingUserWithEmail = await _userManager.FindByEmailAsync(registerUser.Email).ConfigureAwait(false);
            if (existingUserWithEmail != null)
                throw new EmailAlreadyExistsException();

            var existingUserWithUserName = await _userManager.FindByNameAsync(registerUser.UserName).ConfigureAwait(false);
            if (existingUserWithUserName != null)
                throw new UserNameAlreadyExistsException();

            var createUser = registerUser.Adapt<User>();
            createUser.ImageUrl = "Default";

            var result = await _userManager.CreateAsync(createUser, registerUser.Password).ConfigureAwait(false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(createUser.UserName).ConfigureAwait(false);
                if (user != null)
                {
                    var defaultRole = "User";
                    await _userManager.AddToRoleAsync(user, defaultRole).ConfigureAwait(false);
                }
                else
                {
                    throw new UserNotFoundException();
                }
            }
            else
            {
                var errors = string.Join(", ", result.Errors.Select(error => error.Description));
                throw new UserNotFoundException(errors);
            }

            return result;
        }
        public async Task<ResponseLoginModel> LoginAsync(RequestLoginModel loginModel)
        {
            var user = await _userManager.FindByNameAsync(loginModel.Username).ConfigureAwait(false);

            if (user == null)
                throw new InvalidCredentialsException();

            if (user.IsBlocked)
                throw new UserIsBlockedException();

            var valid = await _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false).ConfigureAwait(false);

            if (!valid.Succeeded)
                throw new InvalidCredentialsException();

            var role = await _userManager.GetRolesAsync(user).ConfigureAwait(false);

            var result = new ResponseLoginModel() { Id = user.Id, Username = user.UserName, Role = role };

            return result;
        }
        public async Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            var user = await _userManager.FindByNameAsync(userName).ConfigureAwait(false);

            if (user == null)
                throw new InvalidCredentialsException();

            if (user.IsBlocked)
                throw new UserIsBlockedException();

            var ku = await _signInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure).ConfigureAwait(false);
            return ku;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync().ConfigureAwait(false);
        }
    }
}
