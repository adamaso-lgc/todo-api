using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Aplication.UseCases.Users;

namespace Todo.Aplication.UseCases.Todo.CreateTodo
{
    public class CreateTodoCommand
    {
        public string Title { get; set; }
        public DateTime LimitDate { get; set; }
    }
}
