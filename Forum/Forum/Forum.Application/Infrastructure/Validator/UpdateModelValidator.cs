// Copyright (C) TBC Bank. All Rights Reserved.

using FluentValidation;
using Forum.Application.Users.Models.UpdateModel;

namespace Forum.Application.Infrastructure.Validator
{
    public class UpdateModelValidator : AbstractValidator<UpdateModel>
    {
        public UpdateModelValidator()
        {
            RuleFor(model => model.Email)
               .Matches(@"^[\w-]+(?:\.[\w-]+)*@(?:[\w-]+\.)+[a-zA-Z]{2,7}$")
               .WithMessage("Invalid Email format");

            RuleFor(model => model.UserName)
               .MaximumLength(50)
               .WithMessage("UserName max length is 50");

            RuleFor(model => model.Name)
               .MaximumLength(50)
               .WithMessage("Name max length is 50");

            RuleFor(model => model.LastName)
               .MaximumLength(50)
               .WithMessage("Name max length is 50");

            RuleFor(model => model.BirthDate).LessThan(DateTime.Now)
               .WithMessage("invalid birthdate");

        }
    }
}
