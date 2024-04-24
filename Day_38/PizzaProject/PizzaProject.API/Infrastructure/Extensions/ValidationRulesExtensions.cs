using FluentValidation;
using PizzaProject.API.Infrastructure.Localization;
using System.Text.RegularExpressions;

namespace PizzaProject.API.Infrastructure.Extensions
{
    public static class ValidationRulesExtensions
    {

        public static IRuleBuilderOptions<T, string> Phone<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(x => Regex.IsMatch(x, @"^5\d{8}$")).WithMessage(MessagesOfValidation.Phone);
        }
        public static IRuleBuilderOptions<T, string> Email<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(x => Regex.IsMatch(x, @"^[\w\.-]+@[a-zA-Z\d\.-]+\.[a-zA-Z]{2,}$")).WithMessage(MessagesOfValidation.Email);
        }
        public static IRuleBuilderOptions<T, decimal> Rank<T>(this IRuleBuilder<T, decimal> ruleBuilder)
        {
            return ruleBuilder
                .Must(x => Regex.IsMatch(x.ToString(), @"^(10|[1-9](\.\d{1,2})?)$"))
                .WithMessage(MessagesOfValidation.Rank);
        }


    }
}
