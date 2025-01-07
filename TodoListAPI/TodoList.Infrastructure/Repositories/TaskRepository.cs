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
        ApplicationDataContext _context;
        public TaskRepository(ApplicationDataContext context)
        {
            _context = context;   
        }

        public Task AddTaskAsync(TaskModel task)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTaskAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaskModel>> GetAllTasksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TaskModel> GetTaskByIdAsync(Guid id)
        {
            throw new NotImplementedException();
            //_context..FindAsync(id);
        }

        public Task UpdateTaskAsync(TaskModel task)
        {
            throw new NotImplementedException();
        }
    }
}
