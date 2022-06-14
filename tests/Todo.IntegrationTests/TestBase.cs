using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Infra.Database.Context;

namespace Todo.IntegrationTests
{
    public class TestBase
    {
        protected DbContextOptions<TodoContext> _dbContextOptions;
        protected TodoContext _context;

        [SetUp]
        public void SetUp()
        {
            _dbContextOptions = new DbContextOptionsBuilder<TodoContext>()
               .UseInMemoryDatabase(databaseName: "TestTodo")
               .Options;
            _context = new TodoContext(_dbContextOptions);
        }
    }
}
