// Copyright (C) TBC Bank. All Rights Reserved.

using System.Security.Claims;
using Forum.Application.Comments.RequestModels;
using Forum.Application.Exceptions;
using Forum.Application.Topics.UserServices;
using Forum.Domain.Comments;
using Mapster;

namespace Forum.Application.Comments.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUserTopicService _topicService;

        public CommentService(ICommentRepository commentRepository, IUserTopicService topicService)
        {
            _commentRepository = commentRepository;
            _topicService = topicService;
        }

        public async Task CreateCommentAsync(CommentRequestModel commentRequestModel, string userId, CancellationToken cancellationToken)
        {
            var comment = commentRequestModel.Adapt<Comment>();

            var topicExists = await _topicService.ExistsTopic(comment.TopicId, cancellationToken).ConfigureAwait(false);
            if (!topicExists)
                throw new TopicNotFoundException();

            comment.UserId = userId;

            await _commentRepository
                .CreateCommentAsync(comment, cancellationToken)
                .ConfigureAwait(false);
        }
        public async Task DeleteCommentAsync(int id, ClaimsPrincipal user, CancellationToken cancellationToken)
        {
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(userId == null)
            {
                throw new UserNotFoundException();
            }

            var canDeleteCommentOwner = true;
            var canDeleteTopicOwner = true;

            var exist = await _commentRepository
                 .Exists(id, cancellationToken)
                 .ConfigureAwait(false);

            if (!exist)
                throw new CommentNotFoundException();

            if(!user.IsInRole("Admin"))
            {
                canDeleteCommentOwner = await _commentRepository
                  .CanDelete(id, userId!, cancellationToken)
                  .ConfigureAwait(false);

                canDeleteTopicOwner = await _topicService
                  .CanDelete(id, userId!, cancellationToken)
                  .ConfigureAwait(false);
            }

            if (!canDeleteCommentOwner && !canDeleteTopicOwner)
                throw new AccessToDeleteCommentException();

            await _commentRepository
                .DeleteCommentAsync(id, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
