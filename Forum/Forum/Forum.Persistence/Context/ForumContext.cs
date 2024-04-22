using Forum.Domain;
using Forum.Domain.Comments;
using Forum.Domain.Topics;
using Forum.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Forum.Persistence.Context
{
	public class ForumContext : IdentityDbContext<User>
	{
		public ForumContext(DbContextOptions<ForumContext> options) : base(options)
		{
		}
        public DbSet<User> User { get; set; } = default!;
        public DbSet<Comment> Comment { get; set; } = default!;
		public DbSet<Topic> Topic { get; set; } = default!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<User>().ToTable("User");

            modelBuilder.Ignore<IdentityUserToken<string>>();
            modelBuilder.Ignore<IdentityUserLogin<string>>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ForumContext).Assembly);
		}

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			foreach (var entry in base.ChangeTracker.Entries<IBaseEntity>()
				.Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
			{
				entry.Entity.UpdatedAt = DateTime.Now.ToUniversalTime();
				if (entry.State == EntityState.Added)
				{
					entry.Entity.CreatedAt = DateTime.Now.ToUniversalTime();
				}
			}
			return base.SaveChangesAsync(cancellationToken);
		}
	}
}
