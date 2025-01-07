using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Domain.Services.Interfaces
{
    public interface ITaskService
    {
        Task<Guid> CreateTask(string title, string description, DateTime dueDate);
        Task UpdateTask(string title, string description, DateTime dueDate);
        Task CompleteTask(Guid taskId);
        Task DeleteTask(Guid taskId);
        Task<List<Task>> GetOverdueTasks();
    }
}
