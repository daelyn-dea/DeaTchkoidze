using Microsoft.EntityFrameworkCore;
using ToDo.Domain.BaseEntities;
using ToDo.Domain.Subtasks;
using ToDo.Domain.ToDos;
using ToDo.Domain.Users;

namespace ToDo.Persistence.Context
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ToDoItem> ToDoItem { get; set; }
        public DbSet<Subtask> Subtask { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ToDoContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
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
    }
}
