// Copyright (C) TBC Bank. All Rights Reserved.

using FluentValidation;
using Forum.Application.Topics.RequestModels;

namespace Forum.Application.Infrastructure.Validator
{
    public class TopicRequestModelValidator : AbstractValidator<TopicRequestModel>
    {
        public TopicRequestModelValidator()
        {

            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(1000)
                .WithMessage("MAc Length is 1000");
        }
    }
}
