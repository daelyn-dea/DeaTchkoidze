using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Forum.Domain.Comments;

namespace Forum.Persistence.Configurations
{
	internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
	{
		public void Configure(EntityTypeBuilder<Comment> builder)
		{
			builder.Property(comment => comment.Title).IsRequired().HasMaxLength(200);

			builder.Property(comment => comment.UserId).IsRequired();

			builder.Property(comment => comment.TopicId).IsRequired();

			builder.Property(comment => comment.CreatedAt).IsRequired();

			builder.Property(comment => comment.UpdatedAt).IsRequired();

            builder.Property(comment => comment.IsDeleted).IsRequired();

        }
	}
}
