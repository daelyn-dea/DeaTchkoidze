// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Comments.RequestModels;
using Swashbuckle.AspNetCore.Filters;

namespace Forum.API.Infrastructure.Examples
{
    public class CommentRequestModelExample : IExamplesProvider<CommentRequestModel>
    {
        public CommentRequestModel GetExamples()
        {
            return new CommentRequestModel
            {
                Title = "I really love this forum! <3",
                TopicId = "Dgd23Dgse1" 
            };
        }
    }
}
