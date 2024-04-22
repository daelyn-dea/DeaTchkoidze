// Copyright (C) TBC Bank. All Rights Reserved.

using Microsoft.AspNetCore.Identity;

namespace Forum.Application.Authentications.AbstractionOfAuthenticationServices
{
    public interface IAuthenticationService
    {
        Task SignOutAsync();
        Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);
    }
}
