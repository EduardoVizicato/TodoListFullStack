using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Models;

namespace TodoList.Application.DTOs
{
    public class TaskUpdateDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskModelStatus Status { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
