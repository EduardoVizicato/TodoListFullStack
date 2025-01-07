using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Domain.Repositories
{
    public interface ITaskRepository
    {
        Task<Task> GetTaskByIdAsync(Guid id);
        Task<IEnumerable<Task>> GetAllTasksAsync();
        Task AddTaskAsync(Task task);
        Task DeleteTaskAsync(Guid id);
        Task UpdateTaskAsync(Task task);
    }
}
