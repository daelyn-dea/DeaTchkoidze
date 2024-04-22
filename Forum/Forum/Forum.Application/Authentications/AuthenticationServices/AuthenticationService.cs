using Forum.Application.Authentications.AbstractionOfAuthenticationServices;
using Forum.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace Forum.Application.Authentications.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly SignInManager<User> _signInManager;

        public AuthenticationService(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {

            var ku = await _signInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure).ConfigureAwait(false);
            return ku;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync().ConfigureAwait(false);
        }
    }
}
