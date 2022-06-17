using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Mapping;
using Todo.Application.Utilities;
using Todo.Infra.Database.Context;

namespace Todo.Application.UnitTests
{
    public class TestBase
    {
        private DbContextOptions<TodoContext> _dbContextOptions;
        protected TodoContext Context;
        protected static IMapper Mapper;

        [OneTimeSetUp]
        public void BeforeEachTest()
        {
            // Build DbContextOptions
            _dbContextOptions = new DbContextOptionsBuilder<TodoContext>()
                .UseInMemoryDatabase(databaseName: "TestTodo")
                .Options;
 
            Context = new TodoContext(_dbContextOptions);

        }

        public TestBase()
        {
            if (Mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                Mapper = mapper;
            }
        }
    }
}
