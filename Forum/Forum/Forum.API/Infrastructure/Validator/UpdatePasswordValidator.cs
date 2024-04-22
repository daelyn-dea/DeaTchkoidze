// Copyright (C) TBC Bank. All Rights Reserved.

using FluentValidation;
using Forum.Application.Users.Models.UpdateModel;

namespace Forum.API.Infrastructure.Validator
{
    public class UpdatePasswordValidator : AbstractValidator<UpdatePassword>
    {
        public UpdatePasswordValidator()
        {
            RuleFor(model => model.NewPassword)
                 .NotEmpty().WithMessage("Password is required")
                 .MinimumLength(6).WithMessage("Password must be at least 6 characters long")
                 .MaximumLength(30).WithMessage("Password must be at most 30 characters long")
                 .Matches("[A-Z]+").WithMessage("Password must contain one or more capital letters.")
                 .Matches("[a-z]+").WithMessage("Password must contain one or more lowercase letters.")
                 .Matches(@"(\d)+").WithMessage("Password must contain one or more digits.")
                 .Matches(@"[""!@$%^&*(){}:;<>,.?/+\-_=|'[\]~\\]").WithMessage("Password must contain one or more special characters.");

            RuleFor(model => model.OldPassword)
                 .NotEmpty().WithMessage("Old Password is required");

            RuleFor(model => model.ConfirmPassword)
                 .NotEmpty().WithMessage("Confirm Password is required");

            RuleFor(model => model.ConfirmPassword)
                .Equal(model => model.NewPassword)
                .WithMessage("Passwords do not match");
        }
    }
}
