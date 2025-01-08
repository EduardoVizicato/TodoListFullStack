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
        Task<IEnumerable<TaskModel>> GetTasks();
        Task<TaskModel> CreateTask(TaskModel taskModel);
        Task<TaskModel> UpdateTask(Guid taskId, TaskModel taskModel);
        Task<bool> CompleteTask(Guid taskId);
        Task<bool> DeleteTask(Guid taskId);
        Task<List<TaskModel>> GetOverdueTasks();
        Task<TaskModel> GetTaskById(Guid taskId);
    }
}
