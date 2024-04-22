using Forum.Application.Authentications.RequestModels;
using Forum.Application.Authentications.ResponseModel;
using Microsoft.AspNetCore.Identity;

namespace Forum.Application.Authentications
{
    public interface IUserManagementService
    {
        Task<IdentityResult> CreateUserAsync(RequestRegisterModel registerModel);
        Task<ResponseLoginModel> LoginAsync(RequestLoginModel loginModel);
        Task SignOutAsync();
        Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);
    }
}

