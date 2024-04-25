// Copyright (C) TBC Bank. All Rights Reserved.

using FluentValidation;
using Forum.Application.Users.Models.UpdateModel;

namespace Forum.Application.Infrastructure.Validator
{
    public class UpdatePasswordValidator : AbstractValidator<UpdatePassword>
    {
        public UpdatePasswordValidator()
        {
            RuleFor(x => x.OldPassword)
           .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long")
                .MaximumLength(30).WithMessage("Password must be at most 30 characters long");

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long")
                .MaximumLength(30).WithMessage("Password must be at most 30 characters long");
            
            RuleFor(model => model.ConfirmPassword)
                .Equal(model => model.NewPassword)
                .WithMessage("Passwords do not match");
        }
    }
}
