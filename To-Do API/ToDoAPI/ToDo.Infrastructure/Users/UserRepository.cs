using Microsoft.EntityFrameworkCore;
using ToDo.Application.Users;
using ToDo.Domain.Users;
using ToDo.Persistence.Context;

namespace ToDo.Infrastructure.Users
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ToDoContext context) : base(context)
        {
        }

        public async Task<User> GetAsync( int id, CancellationToken cancellationToken)
        {
            return await base.GetAsync(cancellationToken, id).ConfigureAwait(false);
        }

        public async Task<User> GetByUsername( string username, CancellationToken cancellationToken)
        {
            return await _dbSet.SingleOrDefaultAsync(user => user.Username == username, cancellationToken);
        }

        public async Task<bool> Exists(int id, CancellationToken cancellationToken)
        {
            return await AnyAsync(user => user.Id == id, cancellationToken).ConfigureAwait(false);
        }
    }
}
