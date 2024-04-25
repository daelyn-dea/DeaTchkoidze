// Copyright (C) TBC Bank. All Rights Reserved.

using FluentValidation;
using Forum.Application.Comments.RequestModels;

namespace Forum.Application.Infrastructure.Validator
{
    public class CommentRequestModelValidator : AbstractValidator<CommentRequestModel>
    {
        public CommentRequestModelValidator()
        {

            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(400)
                .WithMessage("Max Length is 400");

            RuleFor(x => x.TopicId)
           .NotEmpty();
        }
    }
}
