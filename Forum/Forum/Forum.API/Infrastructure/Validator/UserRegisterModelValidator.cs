using FluentValidation;
using Forum.Application.Authentications.RequestModels;

namespace Forum.API.Infrastructure.Validator
{
    public class UserRegisterModelValidator : AbstractValidator<RequestRegisterModel>
	{
		public UserRegisterModelValidator() 
		{
            RuleFor(model => model.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .Matches(@"^[\w-]+(?:\.[\w-]+)*@(?:[\w-]+\.)+[a-zA-Z]{2,7}$")
                .WithMessage("Invalid Email format");

			RuleFor(model => model.UserName)
			   .NotEmpty()
			   .WithMessage("UserName is required")
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

			RuleFor(model => model.Password)
				.NotEmpty().WithMessage("Password is required")
				.MinimumLength(6).WithMessage("Password must be at least 6 characters long")
				.MaximumLength(30).WithMessage("Password must be at most 30 characters long")
				.Matches("[A-Z]+").WithMessage("Password must contain one or more capital letters.")
				.Matches("[a-z]+").WithMessage("Password must contain one or more lowercase letters.")
				.Matches(@"(\d)+").WithMessage("Password must contain one or more digits.")
				.Matches(@"[""!@$%^&*(){}:;<>,.?/+\-_=|'[\]~\\]").WithMessage("Password must contain one or more special characters.");

            RuleFor(model => model.ConfirmPassword)
                 .NotEmpty().WithMessage("Confirm Password is required");

            RuleFor(model => model.ConfirmPassword)
				.Equal(model => model.Password)
				.WithMessage("Passwords do not match");
		}
	}
}
