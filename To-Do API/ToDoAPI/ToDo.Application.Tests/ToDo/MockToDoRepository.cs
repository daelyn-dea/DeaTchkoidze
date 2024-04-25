using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.ToDos;
using ToDo.Domain.ToDos;

namespace ToDo.Application.Tests.ToDo
{
	public class MockToDoRepository : IToDoRepository
	{
		public Task CreateAsync(ToDoItem todo, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(int id, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<bool> ExistsByUserIsAndIs(int userId, int id, CancellationToken cancellationToken)
		{
			if(userId == 1 && id == 1)
				return Task.FromResult(true);
			return Task.FromResult(false);
		}

		public Task<List<ToDoItem>> GetAllAsyncByOwnerId(int ownerId, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<ToDoItem> GetAsyncBeId(int id, int userId, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<List<ToDoItem>> GetAsyncByStatus(Status status, int userId, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsyncCompletionDate(int id, DateTime date, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsyncStatus(int id, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsyncTitle(int id, string title, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
