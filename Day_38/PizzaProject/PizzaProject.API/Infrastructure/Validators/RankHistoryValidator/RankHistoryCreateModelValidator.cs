using FluentValidation;
using PizzaProject.API.Infrastructure.Localization;
using PizzaProject.API.Models.Requests.OrderRequest;
using PizzaProject.API.Models.Requests.RankHistoryRequest;
using PizzaProject.Application.Repositories;
using PizzaProject.API.Infrastructure.Extensions;

namespace PizzaProject.API.Infrastructure.Validators.RankHistoryValidator
{
    public class RankHistoryCreateModelValidator : AbstractValidator<RankHistoryCreateModel>
    { 
        public RankHistoryCreateModelValidator()
        {


            RuleFor(x => x.UserId).NotEmpty().WithMessage(MessagesOfValidation.MandatorUserId);

            RuleFor(x => x.PizzaId).NotEmpty().WithMessage(MessagesOfValidation.PizzaIdMandatory);
              
            RuleFor(x => x.Rank).NotEmpty().WithMessage(MessagesOfValidation.RankMandatoryField).Rank();
        }

    }
}