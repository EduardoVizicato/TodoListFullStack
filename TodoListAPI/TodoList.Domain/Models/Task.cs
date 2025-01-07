using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Domain.Models
{
    public class Task
    {
        public Guid id { get; set; } = Guid.NewGuid();
        public string title { get; set; }
        public string description { get; set; }
        public TaskStatus status { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
