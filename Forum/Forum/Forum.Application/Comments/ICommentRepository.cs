// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Domain.Comments;

namespace Forum.Application.Comments
{
    public interface ICommentRepository
    {
        Task CreateCommentAsync(Comment comment, CancellationToken cancellationToken);
        Task DeleteCommentAsync(int id, CancellationToken cancellationToken);
        Task<bool> CanDelete(int id, string userId, CancellationToken cancellationToken);
        Task<bool> Exists(int id, CancellationToken cancellationToken);
    }
}
