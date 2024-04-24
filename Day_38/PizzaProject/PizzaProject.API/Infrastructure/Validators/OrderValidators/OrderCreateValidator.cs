using FluentValidation;
using PizzaProject.API.Infrastructure.Localization;
using PizzaProject.API.Models.Requests.OrderRequest;
using PizzaProject.API.Models.Requests.PizzaRequests;
using PizzaProject.Application.Repositories;
using PizzaProject.Infrastructure.Addresses;

namespace PizzaProject.API.Infrastructure.Validators.OrderValidators
{
    public class OrderCreateValidator : AbstractValidator<OrderCreateModel>
    {

        public OrderCreateValidator()
        {

            RuleFor(x => x.UserId).NotEmpty().WithMessage(MessagesOfValidation.MandatorUserId);

            RuleForEach(x => x.PizzasIds).NotEmpty().WithMessage(MessagesOfValidation.PizzaIdMandatory);
        }
    }
}
