using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Models;
using TodoList.Domain.Repositories;
using TodoList.Infrastructure.Data;

namespace TodoList.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private ApplicationDataContext _context;
        private ILogger<TaskRepository> _logger;
        public TaskRepository(ApplicationDataContext context, ILogger<TaskRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<TaskModel> AddTaskAsync(TaskModel task)
        {
            await _context.AddAsync(task);
            _logger.LogInformation($"task generated sucefully with Id {task.Id}");
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while saving task with Id {task.Id}");
            }
            return task;
        }

        public async Task<bool> DeleteTaskAsync(Guid id)
        {
            var taskToDelete = await GetTaskByIdAsync(id);
            if (taskToDelete == null) 
            {
                _logger.LogWarning($"Id ({id}) not found");
                return false;
            }

            _logger.LogInformation($"Task with {id} deleted successfully!");
            _context.Remove(taskToDelete);

            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch(Exception ex)
            {
                _logger.LogError("An error occurred while saving changes");
                return false;
            }
            
        }

        public async Task<IEnumerable<TaskModel>> GetAllTasksAsync()
        {
            _logger.LogInformation("Fetching all tasks");
            return await _context.Tasks.ToListAsync();
        }

        public async Task<TaskModel> GetTaskByIdAsync(Guid id)
        {
            if(id == null)
            {
                _logger.LogError($"Id {id} not found ");
            }
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<bool> UpdateTaskAsync(TaskModel task)
        {
            var taskToUpdate = await GetTaskByIdAsync(task.Id);

            if (taskToUpdate == null)
            {
                _logger.LogWarning($"Id {task.Id} not found");
                return false;
            }

            taskToUpdate.Title = task.Title;
            taskToUpdate.Description = task.Description;
            taskToUpdate.DueDate = task.DueDate;
            taskToUpdate.Status = task.Status;

            _context.Update(taskToUpdate);

            _logger.LogInformation($"Task with {task.Id} updated successfully!");
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while saving changes in database");
                return false;
            }

        }
    }
}
