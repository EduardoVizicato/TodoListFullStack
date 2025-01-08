using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Models;

namespace TodoList.Domain.Repositories
{
    public interface ITaskRepository
    {
        Task<TaskModel> GetTaskByIdAsync(Guid id);
        Task<IEnumerable<TaskModel>> GetAllTasksAsync();
        Task<TaskModel> AddTaskAsync(TaskModel ask);
        Task<bool> DeleteTaskAsync(Guid id);
        Task<bool> UpdateTaskAsync(TaskModel task);
    }
}
