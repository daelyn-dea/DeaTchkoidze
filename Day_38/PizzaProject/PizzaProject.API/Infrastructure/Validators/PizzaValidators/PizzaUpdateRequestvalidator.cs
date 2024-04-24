using FluentValidation;
using PizzaProject.API.Infrastructure.Localization;
using PizzaProject.API.Models.Requests.PizzaRequests;

namespace PizzaProject.API.Infrastructure.Validators.PizzaValidators
{
    public class PizzaUpdateRequestvalidator : AbstractValidator<PizzaUpdateModel>
    {
        public PizzaUpdateRequestvalidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(MessagesOfValidation.NameMandatoryField).Length(3, 20).WithMessage(MessagesOfValidation.NameLength);
            RuleFor(x => x.Price).NotEmpty().WithMessage(MessagesOfValidation.PriceMandatoryField).Must(x => x > 0).WithMessage(MessagesOfValidation.PriceLength);
            RuleFor(x => x.Description).MaximumLength(100).WithMessage(MessagesOfValidation.DescriptionLength);
            RuleFor(x => x.CaloryCount).NotEmpty().WithMessage(MessagesOfValidation.CaloryCountMandatoryField).Must(x => x > 0).WithMessage(MessagesOfValidation.CaloryCountLength);
        }
    }
}
