// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Comments;
using Forum.Domain.Comments;
using Forum.Infrastructures;
using Forum.Persistence.Context;

namespace Forum.Infrastructure.Comments
{
    internal class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ForumContext context) : base(context)
        {
        }
        public async Task CreateCommentAsync(Comment comment, CancellationToken cancellationToken)
        {
            await CreateAsync(comment, cancellationToken).ConfigureAwait(false);
        }
        public async Task DeleteCommentAsync(int id, CancellationToken cancellationToken)
        {
            var comment = await GetAsync(cancellationToken, id).ConfigureAwait(false);
            comment!.IsDeleted = true;
            await UpdateAsync(comment, cancellationToken).ConfigureAwait(false);
        }
        public async Task<bool> Exists(int id, CancellationToken cancellationToken)
        {
            return await AnyAsync(x => x.Id == id, cancellationToken).ConfigureAwait(false);
        }

        public async Task<bool> CanDelete(int id, string userId, CancellationToken cancellationToken)
        {
            return await AnyAsync(x => x.Id == id && x.UserId == userId, cancellationToken).ConfigureAwait(false);
        }
    }
}
