// Copyright (C) TBC Bank. All Rights Reserved.

using System.Security.Claims;
using Forum.Application.Comments.RequestModels;
using Forum.Application.Comments.ResponseModels;
using Forum.Application.Comments.Services;
using Forum.Domain.Comments;
using Forum.Domain.Topics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Web.Controllers.User
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService) => _commentService = commentService;

        [Authorize(Roles = "User")]
        public async Task<IActionResult> Create(string topicId, string body, CancellationToken cancellationToken)
        {
            var commentRequestModel = new CommentRequestModel
            {
                TopicId = topicId,
                Title = body
            };
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _commentService.CreateCommentAsync(commentRequestModel, userId!, cancellationToken).ConfigureAwait(false);

            return RedirectToAction("GetTopicById", "UserTopic", new { id = topicId });
        }

        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> Delete(int commentId, string topicId, CancellationToken cancellationToken)
        {
            var claims = User;
            await _commentService.DeleteCommentAsync(commentId, claims, cancellationToken).ConfigureAwait(false);
            if (User.IsInRole("User"))
                return RedirectToAction("GetTopicById", "UserTopic", new {id = topicId });
            else 
                return RedirectToAction("GetTopicById", "ManageTopic", new { id = topicId });
        }
    }
}
