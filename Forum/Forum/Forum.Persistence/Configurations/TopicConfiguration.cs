using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Forum.Domain.Topics;

namespace Forum.Persistence.Configurations
{
	internal class TopicConfiguration : IEntityTypeConfiguration<Topic>
	{
		public void Configure(EntityTypeBuilder<Topic> builder)
		{
			builder.Property(topic => topic.Title).IsRequired().HasMaxLength(200);

			builder.Property(topic => topic.UserId).IsRequired();

            builder.Property(topic => topic.State).IsRequired();

			builder.Property(topic => topic.Status).IsRequired();

			builder.Property(comment => comment.UpdatedAt).IsRequired();

			builder.HasMany(t => t.Comments)
				  .WithOne(u => u.Topic)
				  .HasForeignKey(t => t.TopicId)
				  .IsRequired()
				  .OnDelete(DeleteBehavior.Restrict);
		}
	}
}
