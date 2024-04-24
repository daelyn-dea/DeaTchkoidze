using FluentValidation;
using ToDo.API.Infrastructure.Localizations;
using ToDo.API.Infrastructure.Models.ToDoItemModels;
using ToDo.Application.Users.RequestModels;

namespace ToDo.API.Infrastructure.Validations.ToDoValidator
{
    public class ToDoItemPostModelValidator : AbstractValidator<ToDoItemPostModel>
    {
        public ToDoItemPostModelValidator()
        {
            RuleFor(toDoItem => toDoItem.Title)
                .MaximumLength(100)
                .WithMessage(ErrorMessages.TitleMaxLength)
                .NotEmpty()
                .WithMessage(ErrorMessages.MandatoryTitle);

            RuleFor(toDoItem => toDoItem.Subtasks)
                 .NotEmpty()
                 .WithMessage(ErrorMessages.MandatorySubtasks);
        }
    }
}
