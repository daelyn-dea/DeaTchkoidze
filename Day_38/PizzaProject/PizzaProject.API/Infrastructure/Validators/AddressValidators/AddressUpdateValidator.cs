using FluentValidation;
using PizzaProject.API.Infrastructure.Localization;
using PizzaProject.API.Models.Requests.AddressRequests;

namespace PizzaProject.API.Infrastructure.Validators.AddressValidators
{
    public class AddresUpdateValidator : AbstractValidator<AddressUpdateModel>
    {
        public AddresUpdateValidator()
        {
            RuleFor(x => x.City).NotEmpty().WithMessage(MessagesOfValidation.CityMandatoryField).Length(0, 15).WithMessage(MessagesOfValidation.CityLength);
            RuleFor(x => x.Country).NotEmpty().WithMessage(MessagesOfValidation.CountryMandatoryField).Length(0, 15).WithMessage(MessagesOfValidation.CountryLength);
            RuleFor(x => x.Region).MaximumLength(15).WithMessage(MessagesOfValidation.RegionLength);
            RuleFor(x => x.Description).MaximumLength(100).WithMessage(MessagesOfValidation.DescriptionLength);
        }
    }
}
