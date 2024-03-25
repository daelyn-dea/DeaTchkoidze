using FluentValidation;
using ToDo.API.Infrastructure.Localizations;
using ToDo.Application.Subtasks.RequestModel;

namespace ToDo.API.Infrastructure.Validations.SubTaskValidator
{
    public class SubtaskRequestPostModelValidator : AbstractValidator<SubtaskRequestPostModel>
    {
        public SubtaskRequestPostModelValidator()
        {
            RuleFor(subtask => subtask.Title)
                .NotEmpty()
                .WithMessage(ErrorMessages.TitleMaxLength)
                .MaximumLength(100)
                .WithMessage(ErrorMessages.MandatoryTitle);
        }
    }
}