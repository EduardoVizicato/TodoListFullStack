using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Application.DTOs;
using TodoList.Domain.Models;

namespace TodoList.Application.Interfaces
{
    public interface ITaskAppService
    {
        Task<IEnumerable<TaskDTO>> GetTasks();
        Task<TaskDTO> CreateTask(TaskModel taskModel);
        Task<TaskDTO> UpdateTask(Guid taskId, TaskModel taskModel);
        Task<bool> CompleteTask(Guid taskId);
        Task<bool> DeleteTask(Guid taskId);
        Task<List<TaskDTO>> GetOverdueTasks();
        Task<TaskDTO> GetTaskById(Guid taskId);
    }
}
