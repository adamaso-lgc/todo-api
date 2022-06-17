using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Application.UseCases.Todo
{
    public class TodoViewModel
    {
        public string Title { get; set; }
        public bool Done { get; set; }
        public DateTime LimitDate { get; set; }
        public User User { get; set; }
    }
}
