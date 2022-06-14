using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.UseCases.Users;

namespace Todo.Application.UseCases.Todo.CreateTodo
{
    public class CreateTodoCommand
    {
        public string Title { get; set; }
        public DateTime LimitDate { get; set; }
    }
}
