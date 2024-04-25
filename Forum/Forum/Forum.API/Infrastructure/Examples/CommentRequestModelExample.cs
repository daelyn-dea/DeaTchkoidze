// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Comments.RequestModels;
using Swashbuckle.AspNetCore.Filters;

namespace Forum.API.Infrastructure.Examples
{
    /// <summary>
    /// Provides examples for the <see cref="CommentRequestModel"/> class.
    /// </summary>
    public class CommentRequestModelExample : IExamplesProvider<CommentRequestModel>
    {
        /// <summary>
        /// Gets an example of a <see cref="CommentRequestModel"/>.
        /// </summary>
        /// <returns>An example <see cref="CommentRequestModel"/>.</returns>
        public CommentRequestModel GetExamples()
        {
            return new CommentRequestModel
            {
                Title = "I really love this forum! <3",
                TopicId = "2epxdpE1"
            };
        }
    }
}
