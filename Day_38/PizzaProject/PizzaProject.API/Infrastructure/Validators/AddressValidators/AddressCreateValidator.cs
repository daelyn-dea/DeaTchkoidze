using FluentValidation;
using PizzaProject.API.Infrastructure.Localization;
using PizzaProject.API.Models.Requests.AddressRequests;

namespace PizzaProject.API.Infrastructure.Validators.AddressValidators
{
    public class AddressCreateValidator : AbstractValidator<AddressCreateModel>
    {
        public AddressCreateValidator()
        {
            RuleFor(x => x.City).NotEmpty().WithMessage(MessagesOfValidation.CityMandatoryField).Length(0, 15).WithMessage(MessagesOfValidation.CityLength);
            RuleFor(x => x.Country).NotEmpty().WithMessage(MessagesOfValidation.CountryMandatoryField).Length(0, 15).WithMessage(MessagesOfValidation.CountryLength);
            RuleFor(x => x.Region).Length(0, 15).WithMessage(MessagesOfValidation.RegionLength);
            RuleFor(x => x.Description).Length(0, 100).WithMessage(MessagesOfValidation.DescriptionLength);
        }
    }
}
