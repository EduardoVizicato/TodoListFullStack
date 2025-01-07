using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Models;

namespace TodoList.Domain.Services.Interfaces
{
    public interface ITaskService
    {
        Task<Guid> CreateTask(string title, string description, DateTime? dueDate);
        Task UpdateTask(Guid taskId, string title, string description, DateTime dueDate, TaskModelStatus status);
        Task CompleteTask(Guid taskId);
        Task DeleteTask(Guid taskId);
        Task<List<TaskModel>> GetOverdueTasks();
    }
}
