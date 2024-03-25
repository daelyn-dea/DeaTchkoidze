using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.ToDos;

namespace ToDo.Persistence.Configurations
{
    public class ToDoItemConfiguration : IEntityTypeConfiguration<ToDoItem>
    {
        public void Configure(EntityTypeBuilder<ToDoItem> builder)
        {
            builder.Property(toDoItem => toDoItem.Title).IsRequired().HasMaxLength(100);

            builder.Property(toDoItem => toDoItem.Status).IsRequired();

            builder.Property(toDoItem => toDoItem.CreatedAt).IsRequired();

            builder.Property(toDoItem => toDoItem.ModifiedAt).IsRequired();

            builder.HasQueryFilter(toDoItem => toDoItem.Status != Status.Deleted && !toDoItem.IsDeleted);

            builder.HasMany(x => x.Subtasks).WithOne(x => x.ToDoItem)
                      .HasForeignKey(x => x.ToDoItemId);
        }
    }
}
