// Copyright (C) TBC Bank. All Rights Reserved.

using Asp.Versioning;
using Forum.Application.Comments.RequestModels;
using Forum.Application.Comments.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.API.Controllers.V2.User
{
    /// <summary>
    /// Controller for handling comments in the forum API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for creating and deleting comments.
    /// </remarks>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/comment")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentController"/> class.
        /// </summary>
        /// <param name="commentService">The comment service for handling comment-related operations.</param>
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        /// <summary>
        /// Creates a new comment in the forum/topic.
        /// </summary>
        /// <param name="commentRequestModel">The model containing the data for the new comment.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task Create(CommentRequestModel commentRequestModel, CancellationToken cancellationToken)
        {
            await _commentService.CreateCommentAsync(commentRequestModel, User, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes a comment from the forum/topic, A user can only delete his own comments.
        /// </summary>
        /// <param name="id">The ID of the comment to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        [Authorize(Roles = "User, Admin")]
        [HttpDelete]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _commentService.DeleteCommentAsync(id, User, cancellationToken).ConfigureAwait(false);
        }
    }
}
