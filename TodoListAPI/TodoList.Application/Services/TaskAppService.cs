using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Application.DTOs;
using TodoList.Application.Interfaces;
using TodoList.Domain.Models;
using TodoList.Domain.Repositories;
using TodoList.Domain.Services.Interfaces;

namespace TodoList.Application.Services
{
    public class TaskAppService : ITaskAppService
    {
        private readonly ITaskService _taskService;
        private readonly ITaskRepository _taskRepository;
        private readonly ILogger<TaskAppService> _logger;
        public TaskAppService(ITaskService taskService,ITaskRepository taskRepository, ILogger<TaskAppService> logger)
        {
            _taskService = taskService;
            _taskRepository = taskRepository;
            _logger = logger;
        }
        public async Task<bool> CompleteTask(Guid taskId)
        {
            return await _taskService.CompleteTask(taskId);
        }

        public async Task<TaskDTO> CreateTask(TaskModel taskModel)
        {
            var task = new TaskModel
            {
                Id = Guid.NewGuid(),
                Title = taskModel.Title,
                Description = taskModel.Description,
                DueDate = taskModel.DueDate,
                Status = TaskModelStatus.Todo,
                CreatedDate = DateTime.UtcNow,
            };

            await _taskService.CreateTask(task);

            return new TaskDTO
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Status = task.Status,
            };
        }

        public Task<bool> DeleteTask(Guid taskId)
        {
            return _taskService.DeleteTask(taskId);
        }

        public Task<List<TaskDTO>> GetOverdueTasks()
        {
            
        }

        public Task<TaskDTO> GetTaskById(Guid taskId)
        {
            
        }

        public Task<IEnumerable<TaskDTO>> GetTasks()
        {
            throw new NotImplementedException();
        }

        public Task<TaskDTO> UpdateTask(Guid taskId, TaskModel taskModel)
        {
            throw new NotImplementedException();
        }
    }
}
