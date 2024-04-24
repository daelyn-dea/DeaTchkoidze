using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ToDo.Domain.BaseEntities;
using ToDo.Persistence.Context;

namespace ToDo.Infrastructure
{
    public class BaseRepository<T> where T : BaseEntity
    {
        protected readonly ToDoContext _context;

        protected readonly DbSet<T> _dbSet;

        public BaseRepository(ToDoContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync(CancellationToken token)
        {
            return await _dbSet.ToListAsync(token);
        }

        public async Task<T> GetAsync(CancellationToken token, params object[] keys)
        {
            return await _dbSet.FindAsync(keys, token);
        }
        public async Task<List<T>> GetManyAsync(Expression<Func<T, bool>> func, CancellationToken token)
        {
            return await _dbSet.Where(func).ToListAsync(token);
        }
        public async Task CreateAsync(T entity, CancellationToken token)
        {
            var bla = await _dbSet.AddAsync(entity, token);

            await _context.SaveChangesAsync(token);
        }

        public async Task UpdateAsync(T entity, CancellationToken token)
        {
            if (entity == null)
                return;

             _dbSet.Update(entity);

            await _context.SaveChangesAsync(token);
        }

        public  async Task DeleteAsync(int id, CancellationToken token)
        {
            var entity = await GetAsync(token, id);
            if (entity == null)
            {
                throw new InvalidOperationException("entity not Found");
            }

            entity.IsDeleted = true;

            _dbSet.Update(entity);

            await _context.SaveChangesAsync(token);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken token)
        {
            return await _dbSet.AnyAsync(predicate, token);
        }
    }
}
