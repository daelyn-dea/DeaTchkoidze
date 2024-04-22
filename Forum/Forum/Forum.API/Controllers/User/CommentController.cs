// Copyright (C) TBC Bank. All Rights Reserved.

using System.Security.Claims;
using Forum.Application.Comments.RequestModels;
using Forum.Application.Comments.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.API.Controllers.User
{
    /// <summary>
    /// Controller for handling comments in the forum API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for creating and deleting comments.
    /// </remarks>
    [Route("api/comment")]
    [ApiController]
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
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _commentService.CreateCommentAsync(commentRequestModel, userId!, cancellationToken).ConfigureAwait(false);
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
            var user = User;
            await _commentService.DeleteCommentAsync(id, user!, cancellationToken).ConfigureAwait(false);
        }
    }
}
