using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Common;

namespace Todo.Domain.Entities
{
    public class TodoList : Entity
    {
        public TodoList()
        {
            Items = new List<TodoItem>();
        }

        public string Title { get; set; }

        public string Color { get; set; }

        public IList<TodoItem> Items { get; set; }
    }
}
