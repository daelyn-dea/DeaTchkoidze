using Forum.Application.Authentications.RequestModels;
using Forum.Application.Authentications.ResponseModel;
using Microsoft.AspNetCore.Identity;

namespace Forum.Application.Authentications.AbstractionOfAuthenticationServices
{
    public interface IUserManagementService
    {
        Task<IdentityResult> CreateUserAsync(RequestRegisterModel registerModel);
        Task<ResponseLoginModel> LoginAsync(RequestLoginModel loginModel);
    }
}
