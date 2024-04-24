// Copyright (C) TBC Bank. All Rights Reserved.

using FluentValidation;
using Forum.Application.Comments.RequestModels;

namespace Forum.API.Infrastructure.Validator
{
    public class CommentRequestModelValidator : AbstractValidator<CommentRequestModel>
    {
        public CommentRequestModelValidator()
        {

            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(4000);

            RuleFor(x => x.TopicId)
           .NotEmpty();
        }
    }
}
