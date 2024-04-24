using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Subtasks;

namespace ToDo.Persistence.Configurations
{
    public class SubtaskConfiguration : IEntityTypeConfiguration<Subtask>
    {
        public void Configure(EntityTypeBuilder<Subtask> builder)
        {
            builder.Property(subtask => subtask.Title).IsRequired().HasMaxLength(100);

            builder.Property(subtask => subtask.ToDoItemId).IsRequired();

            builder.Property(subtask => subtask.CreatedAt).IsRequired();

            builder.Property(subtask => subtask.ModifiedAt).IsRequired();

            builder.Property(subtask => subtask.IsDeleted).IsRequired();

            builder.HasQueryFilter(subtask => !subtask.IsDeleted);
        }
    }
}
