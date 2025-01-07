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

namespace TodoList.Domain.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }
        public async Task CompleteTask(Guid taskId)
        {
            var taskModel = await _repository.GetTaskByIdAsync(taskId);
            if (taskModel == null) 
            {
                throw new KeyNotFoundException("Essa tarefa não existe");
            }

            if (taskModel.Status == TaskModelStatus.Completed) 
            {
                throw new InvalidOperationException("A tarefa ja está completa");
            }

            taskModel.Status = TaskModelStatus.Completed;
            await _repository.UpdateTaskAsync(taskModel);
        }

        public async Task<Guid> CreateTask(string title, string description, DateTime? dueDate)
        {
            if (string.IsNullOrEmpty(title)) 
            {
                throw new ArgumentNullException("Coloque o título da tarefa"); 
            }

            if(dueDate.HasValue && dueDate.Value < DateTime.UtcNow)
            {
                throw new ArgumentException("A data não pode estar no passado, coloque a data de hoje ou dos dias seguintes");
            }

            var task = new TaskModel
            {
                Id = Guid.NewGuid(),
                Title = title,
                Description = description,
                DueDate = dueDate,
                Status = Models.TaskModelStatus.ToDo,
                CreatedDate = DateTime.UtcNow,
            };

            await _repository.AddTaskAsync(task);
            return task.Id;
        }

        public async Task DeleteTask(Guid taskId)
        {
            var taskModel = await _repository.GetTaskByIdAsync(taskId);

            if (taskModel == null) 
            {
                throw new ArgumentNullException("A tarefa não existe");
            }

            await _repository.DeleteTaskAsync(taskId);
        }

        public async Task<List<TaskModel>> GetOverdueTasks()
        {
            var taskList = await _repository.GetAllTasksAsync();

            return taskList.Where(taskModel => taskModel.DueDate.HasValue && taskModel.DueDate.Value < DateTime.UtcNow).ToList();
        }

        public async Task UpdateTask(Guid taskId, string title, string description, DateTime dueDate, TaskModelStatus status)
        {
            var taskModel = await _repository.GetTaskByIdAsync(taskId);

            if (taskModel == null) 
            {
                throw new ArgumentNullException("A tarefa não existe");
            }

            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException("Coloque o título da tarefa");
            }

            taskModel.Title = title;
            taskModel.Description = description;
            taskModel.DueDate = dueDate;
            taskModel.Status = status;

            await _repository.UpdateTaskAsync(taskModel);
        }
    }
}
