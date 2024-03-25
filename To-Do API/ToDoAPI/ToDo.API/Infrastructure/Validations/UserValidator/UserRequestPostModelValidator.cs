using FluentValidation;
using ToDo.API.Infrastructure.Localizations;
using ToDo.Application.Users.RequestModels;
using ToDo.Domain.Users;

namespace ToDo.API.Infrastructure.Validations.UserValidator
{
    public class UserRequestPostModelValidator : AbstractValidator<UserRequestPostModel>
    {
        public UserRequestPostModelValidator()
        {
            RuleFor(user => user.Username)
                .MaximumLength(50)
                .WithMessage(ErrorMessages.MaxLenth)
                .NotEmpty()
                .WithMessage(ErrorMessages.MandatoryUsername);

            RuleFor(user => user.Password)
                .NotEmpty()
                .WithMessage(ErrorMessages.MandatoryPassword)
                .MinimumLength(8)
                .WithMessage(ErrorMessages.MinLengthPassword)
                .Matches("[0-9]")
                .WithMessage(ErrorMessages.ContainDigitInPassword)
                .Matches("[A-Z]")
                .WithMessage(ErrorMessages.UpperCaseInPassword);
        }
    }
}
