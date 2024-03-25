using FluentValidation;
using ToDo.API.Infrastructure.Localizations;
using ToDo.API.Infrastructure.Models.ToDoItemModels;

namespace ToDo.API.Infrastructure.Validations.ToDoValidator
{
    public class ToDoItemPatchModelValidator : AbstractValidator<ToDoItemPatchModel>
    {
        public ToDoItemPatchModelValidator()
        {
            RuleFor(toDoItem => toDoItem.Title)
                .MaximumLength(100)
                .WithMessage(ErrorMessages.TitleMaxLength);

        }
    }
}
