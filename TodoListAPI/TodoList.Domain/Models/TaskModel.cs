using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Domain.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskModelStatus Status { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
