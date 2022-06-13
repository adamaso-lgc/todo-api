using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Common;

namespace Todo.Domain.Entities
{
    public class TodoItem : Entity
    {
        public string Title { get; set; }
        public bool Done { get; set; }
        public DateTime LimitDate { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
