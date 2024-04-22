// Copyright (C) TBC Bank. All Rights Reserved.

using System.Linq.Expressions;

namespace Forum.Infrastructure.BaseRepository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(CancellationToken token);
        Task<T?> GetAsync(CancellationToken token, params object[] key);
        Task CreateAsync(T entity, CancellationToken token);
        Task UpdateAsync(T entity, CancellationToken token);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
    }
}
