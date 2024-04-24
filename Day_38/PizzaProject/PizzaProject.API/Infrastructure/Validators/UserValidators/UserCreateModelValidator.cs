using FluentValidation;
using PizzaProject.API.Infrastructure.Extensions;
using PizzaProject.API.Infrastructure.Localization;
using PizzaProject.API.Infrastructure.Validators.AddressValidators;
using PizzaProject.API.Models.Requests.UserRequests;

namespace PizzaProject.API.Infrastructure.Validators.UserValidators
{
    public class UserCreateModelValidator : AbstractValidator<UserCreateModel>
    {
        public UserCreateModelValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(MessagesOfValidation.FirstNameMandatoryField).Length(2, 20).WithMessage(MessagesOfValidation.FirstNameLength);
            RuleFor(x => x.LastName).NotEmpty().WithMessage(MessagesOfValidation.LastNameMandatoryField).Length(2, 30).WithMessage(MessagesOfValidation.LastNameLength);
            RuleFor(x => x.Email).NotEmpty().WithMessage(MessagesOfValidation.EmailMandatoryField).Email();
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage(MessagesOfValidation.PhoneMandatoryField).Phone();

            RuleForEach(x => x.AddressList)
               .SetValidator(new AddressCreateValidator());
        }

    }
}
