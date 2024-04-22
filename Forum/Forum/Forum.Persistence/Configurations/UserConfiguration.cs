using Forum.Domain.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Forum.Persistence.Configurations
{
	internal class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasIndex(user => user.UserName).IsUnique();

			builder.HasIndex(user => user.Email).IsUnique(); //for search

			builder.Property(user => user.Email).HasMaxLength(100).IsRequired();

			builder.Property(user => user.UserName).IsRequired().HasMaxLength(50);

			builder.Property(user => user.PasswordHash).IsRequired();

			builder.Property(user => user.Name).HasMaxLength(50);

			builder.Property(user => user.LastName).HasMaxLength(50);

			builder.Property(user => user.IsBlocked).IsRequired().HasDefaultValue(false);

            builder.Ignore(user => user.LockoutEnabled);
            builder.Ignore(user => user.PhoneNumberConfirmed);
            builder.Ignore(user => user.ConcurrencyStamp);
            builder.Ignore(user => user.AccessFailedCount);
            builder.Ignore(user => user.LockoutEnd);
            builder.Ignore(user => user.SecurityStamp);
            builder.Ignore(user => user.TwoFactorEnabled);
            builder.Ignore(user => user.PhoneNumber);

            builder.Ignore(user => user.AccessFailedCount);

            builder.HasMany(u => u.Topics)
				   .WithOne(t => t.User)
				   .HasForeignKey(t => t.UserId).OnDelete(DeleteBehavior.Restrict);

			builder.HasMany(u => u.Comments)
				   .WithOne(c => c.User)
				   .HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.Restrict);
		}
	}
}
