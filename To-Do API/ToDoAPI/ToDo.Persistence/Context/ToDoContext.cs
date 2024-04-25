using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ToDo.Domain.ActionLogs;
using ToDo.Domain.BaseEntities;
using ToDo.Domain.Subtasks;
using ToDo.Domain.ToDos;
using ToDo.Domain.Users;

namespace ToDo.Persistence.Context
{
    public class ToDoContext : DbContext
    {
        public string CurrentCrudMethod { get; set; }
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
        }
        public DbSet<ActionLog> ActionLogs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ToDoItem> ToDoItem { get; set; }
        public DbSet<Subtask> Subtask { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ToDoContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //AuditEntities();
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.ModifiedAt = DateTime.Now.ToUniversalTime();
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.Now.ToUniversalTime();
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        //private void AuditEntities()
        //{
        //    //foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            //{
            //    if (entry.State == EntityState.Modified || entry.State == EntityState.Deleted)
            //    {
            //        var actionLog = new ActionLog
            //        {
            //            Date = DateTime.UtcNow,
            //            ItemType = entry.Entity.GetType().Name,
            //            ItemId = (int)entry.Property("Id").CurrentValue,
            //            OperationType = entry.State == EntityState.Deleted ? OperationTypes.Deleted : OperationTypes.Updated
            //        };

            //        if (entry.State == EntityState.Modified)
            //        {
            //            foreach (var property in entry.Properties)
            //            {
            //                if (property.Metadata.Name != "ModifiedAt" && property.IsModified)
            //                {
            //                    actionLog.ColumnName = property.Metadata.Name;
            //                    actionLog.OldValue = entry.OriginalValues?.ToString();
            //                    actionLog.NewValue = property.CurrentValue?.ToString();

            //                    ActionLogs.Add(actionLog);
            //                }
            //            }
            //        }
            //    }
            //}
            private void AuditEntities()
            {
                var modifiedEntries = ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);

                foreach (var entry in modifiedEntries)
                {

                    var actionLog = new ActionLog
                    {
                        Date = DateTime.UtcNow,
                        ItemType = entry.Entity.GetType().Name,
                        ItemId = Convert.ToInt32(entry.Property("Id").CurrentValue),
                        OperationType = GetOperationType()
                    };

                   // if (entry.State == EntityState.Modified)
                  //  {
                        // Log changes for modified or added entities
                        foreach (var property in entry.Properties)
                        {
                       //    if (property.IsModified && property.Metadata.Name != "ModifiedAt" || property.Add)
                       //{
                        actionLog.ColumnName = property.Metadata.Name;
                        actionLog.OldValue = entry.OriginalValues?[property.Metadata.Name].ToString() ?? string.Empty;
                            actionLog.NewValue = entry.CurrentValues?[property.Metadata.Name]?.ToString();
                            ActionLogs.Add(actionLog);
                            }
                        //}
                   // }
                }
            }

            private OperationTypes GetOperationType()
            {
                switch (CurrentCrudMethod)
                {
                    case "Added":
                        return OperationTypes.Created;
                    case "Modified":
                        return OperationTypes.Updated;
                    case "Deleted":
                        return OperationTypes.Deleted;
                    default:
                       return OperationTypes.Created;
            }
            }
        }
    }
