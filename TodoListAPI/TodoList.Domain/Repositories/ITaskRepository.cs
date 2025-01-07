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
        Task AddTaskAsync(TaskModel ask);
        Task DeleteTaskAsync(Guid id);
        Task UpdateTaskAsync(TaskModel task);
    }
}
