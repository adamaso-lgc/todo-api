using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.UseCases.TodoLists.CreateTodoList;
using Todo.Infra.Repositories;
using static Todo.Application.UseCases.TodoLists.CreateTodoList.CreateTodoListCommand;

namespace Todo.Application.UnitTests.TodoLists
{
    [TestFixture]
    public class CreateTodoListTest : TestBase
    {
        private TodoListRepository _todoListRepository;

        [SetUp]
        public void SetUp()
        {
            _todoListRepository = new TodoListRepository(Context);
        }

        [Test]
        public async Task CreateTodoList_WhenCreate_ReturnTodoListId()
        {
            // arrange
            var command = new CreateTodoListCommand()
            {
                Title = "Teste",
                Color = "red"
            };

            var handler = new CreateTodoListCommandHandler(_todoListRepository, Mapper);

            // act
            var result = await handler.Handle(command, CancellationToken.None);

            // assert
            Assert.That(command.Title, Is.EqualTo(Context.TodoLists.First().Title));
            Assert.That(result, Is.EqualTo(Context.TodoLists.First().Id));
        }
    }
}
