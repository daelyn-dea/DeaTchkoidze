// Copyright (C) TBC Bank. All Rights Reserved.

using System.Security.Claims;
using Forum.Application.Comments.RequestModels;

namespace Forum.Application.Comments.Services
{
    public interface ICommentService
    {
        Task CreateCommentAsync(CommentRequestModel comment, ClaimsPrincipal claims, CancellationToken cancellationToken);
        Task DeleteCommentAsync(int id, ClaimsPrincipal user, CancellationToken cancellationToken);
    }
}
