using System.Linq.Expressions;
using Forum.Domain;
using Forum.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Forum.Infrastructures
{
    public class BaseRepository<T> where T : class, IBaseEntity
    {
        protected readonly ForumContext _context = default!;

        protected readonly DbSet<T> _dbSet = default!;

        public BaseRepository(ForumContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync(CancellationToken token)
        {
            return await _dbSet.ToListAsync(token).ConfigureAwait(false);
        }
        public async Task<T?> GetAsync(CancellationToken token, params object[] key)
        {
            var entity = await _dbSet.FindAsync(key, token).ConfigureAwait(false);
            return entity;
        }

        public async Task CreateAsync(T entity, CancellationToken token)
        {
            await _dbSet.AddAsync(entity, token).ConfigureAwait(false);

            await _context.SaveChangesAsync(token).ConfigureAwait(false);
        }

        public async Task UpdateAsync(T entity, CancellationToken token)
        {
            if (entity == null)
                return;

            _dbSet.Update(entity);

            await _context.SaveChangesAsync(token).ConfigureAwait(false);
        }

        public Task<bool> AnyAsync( Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return _dbSet.AnyAsync(predicate, cancellationToken);
        }
    }
}
