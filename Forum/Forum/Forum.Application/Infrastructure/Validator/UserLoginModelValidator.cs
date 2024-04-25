// Copyright (C) TBC Bank. All Rights Reserved.

using FluentValidation;
using Forum.Application.Authentications.RequestModels;

namespace Forum.Application.Infrastructure.Validator
{
    public class UserLoginModelValidator : AbstractValidator<RequestLoginModel>
    {
        public UserLoginModelValidator()
        {
            RuleFor(model => model.Username)
                .NotEmpty()
                .WithMessage("UserName is required");

            RuleFor(model => model.Password)
                .NotEmpty()
                .WithMessage("Password is required");
        }
    }
}
