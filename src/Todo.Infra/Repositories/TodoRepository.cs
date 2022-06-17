using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Repositories;
using Todo.Domain.Entities;
using Todo.Infra.Database.Context;

namespace Todo.Infra.Repositories
{
    public class TodoRepository : RepositoryBase<TodoItem>, ITodoRepository
    {
        public TodoRepository(TodoContext dbContext) : base(dbContext)
        {
        }
    }
}
