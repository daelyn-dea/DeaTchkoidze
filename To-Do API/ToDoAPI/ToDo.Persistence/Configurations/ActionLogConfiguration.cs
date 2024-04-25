using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.ActionLogs;

namespace ToDo.Persistence.Configurations
{
    internal class ActionLogConfiguration : IEntityTypeConfiguration<ActionLog>
    {
        public void Configure(EntityTypeBuilder<ActionLog> builder)
        {
            // Table name
            builder.ToTable("ActionLogs");

            // Primary key
            builder.HasKey(x => x.Id);

            // Date
            builder.Property(x => x.Date).IsRequired();

            // ItemType
            builder.Property(x => x.ItemType).IsRequired().HasMaxLength(100);

            // ItemId
            builder.Property(x => x.ItemId).IsRequired();

            // OperationType
            builder.Property(x => x.OperationType).IsRequired();

            // ColumnName (if applicable)
            builder.Property(x => x.ColumnName).HasMaxLength(100);

            // OldValue (if applicable)
            builder.Property(x => x.OldValue).HasMaxLength(255);

            // NewValue (if applicable)
            builder.Property(x => x.NewValue).HasMaxLength(255);
        }

    }
}
