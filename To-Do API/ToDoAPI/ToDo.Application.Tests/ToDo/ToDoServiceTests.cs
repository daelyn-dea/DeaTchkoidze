using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Exceptions;
using ToDo.Application.ToDos;

namespace ToDo.Application.Tests.ToDo
{
	public class ToDoServiceTests
	{
		private Mock<IToDoRepository> _repository;

        public ToDoServiceTests()
        {
			_repository = new Mock<IToDoRepository>();
        }
        [Fact]
		public async void GetAsync_WhenUserIdDoesNotExist_ShouldThrowToDoItemNotFoundException()
		{
			//arrange
			_repository
				.Setup(x => x.ExistsByUserIsAndIs(It.Is<int>(x => x == 5), It.IsAny<int>(), It.IsAny<CancellationToken>()))	
				.ReturnsAsync(true);

			var toDoService = new ToDoService(_repository.Object);

			//act 
			var action = () => toDoService.GetAsync(1,5,CancellationToken.None);

			//assert
			var exception = await action.Should().ThrowAsync<ToDoItemNotFoundException>();
			exception.Which.Message.Should().Be("ToDo not found");
		}
	}
}
