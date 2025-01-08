using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Repositories;
using TodoList.Domain.Services.Interfaces;
using TodoList.Domain.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace TodoList.Domain.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;
        private readonly ILogger<TaskService> _logger;

        public TaskService(ITaskRepository repository, ILogger<TaskService> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<bool> CompleteTask(Guid taskId)
        {
            var taskToComplete = await _repository.GetTaskByIdAsync(taskId);
            if (taskToComplete == null) 
            {
                throw new KeyNotFoundException($"the task with Id {taskId} does not exist!");
            }

            if (taskToComplete.Status == TaskModelStatus.Completed) 
            {
                _logger.LogError($"Task with Id {taskId} is already completed!");
            }
            _logger.LogInformation("The task has been completed");
            taskToComplete.Status = TaskModelStatus.Completed;
            await _repository.UpdateTaskAsync(taskToComplete);
            return true;
        }

        public async Task<TaskModel> CreateTask(TaskModel taskModel)
        {
            if (string.IsNullOrEmpty(taskModel.Title)) 
            {
                _logger.LogWarning("Add a title to the task!"); 
            }

            if(taskModel.DueDate.HasValue && taskModel.DueDate.Value < DateTime.UtcNow)
            {
                _logger.LogWarning("The can not be in the past, add a valid date!");
            }

            var task = new TaskModel
            {
                Id = Guid.NewGuid(),
                Title = taskModel.Title,
                Description = taskModel.Description,
                DueDate = taskModel.DueDate,
                Status = TaskModelStatus.Status,
                CreatedDate = DateTime.UtcNow,
            };

            _logger.LogInformation("The task has been created");
            await _repository.AddTaskAsync(task);
            return task;
        }

        public async Task<bool> DeleteTask(Guid taskId)
        {
            var taskToDelete = await _repository.GetTaskByIdAsync(taskId);

            if (taskToDelete == null) 
            {
                _logger.LogError($"The task with Id {taskId}does not exist!");
            }

            await _repository.DeleteTaskAsync(taskId);
            return true;
        }

        public async Task<List<TaskModel>> GetOverdueTasks()
        {
            _logger.LogInformation("These are the Overdue Tasks");
            var taskList = await _repository.GetAllTasksAsync();
            return taskList.Where(taskModel => taskModel.DueDate.HasValue && taskModel.DueDate.Value < DateTime.UtcNow).ToList();
        }

        public async Task<TaskModel> GetTaskById(Guid taskId)
        {
            var tasksById = await _repository.GetTaskByIdAsync(taskId);
            if (tasksById == null)
            {
                _logger.LogError($"{taskId} does not exists");
            }

            return tasksById;
        }

        public async Task<IEnumerable<TaskModel>> GetTasks()
        {
            _logger.LogInformation("These are all the Tasks");
            var taskList = await _repository.GetAllTasksAsync();
            return taskList;
        }

        public async Task<TaskModel> UpdateTask(Guid taskId, TaskModel taskModel)
        {
            var taskToUpdate = await _repository.GetTaskByIdAsync(taskId);

            if (taskToUpdate == null) 
            {
                _logger.LogError($"The task with Id {taskId}does not exist!");
            }

            if (string.IsNullOrEmpty(taskModel.Title))
            {
                _logger.LogWarning("Add a title to the task!");
            }

            taskToUpdate.Title = taskModel.Title;
            taskToUpdate.Description = taskModel.Description;
            taskToUpdate.DueDate = taskModel.DueDate;
            taskToUpdate.Status = taskModel.Status;

            _logger.LogInformation($"Updating task with Id {taskToUpdate.Id}. Title changed from '{taskToUpdate.Title}' to '{taskModel.Title}'", taskToUpdate.Id);
            await _repository.UpdateTaskAsync(taskToUpdate);

            return taskToUpdate;
        }
    }
}
