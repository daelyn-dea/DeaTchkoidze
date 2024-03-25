using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Users;

namespace ToDo.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(user => user.Username).IsUnique();

            builder.Property(user => user.Username).IsRequired().HasMaxLength(50);

            builder.Property(user => user.PasswordHash).IsRequired();

            builder.Property(user => user.CreatedAt).IsRequired();

            builder.Property(user => user.ModifiedAt).IsRequired();

            builder.Property(user => user.IsDeleted).IsRequired();

            builder.HasMany(x => x.ToDoItems).WithOne(x => x.Owner)
            .HasForeignKey(x => x.OwnerId);
        }
    }
}
