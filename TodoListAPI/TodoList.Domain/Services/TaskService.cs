using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Services.Interfaces;

namespace TodoList.Domain.Services
{
    public class TaskService : ITaskService
    {
        public Task CompleteTask(Guid taskId)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> CreateTask(string title, string description, DateTime dueDate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTask(Guid taskId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Task>> GetOverdueTasks()
        {
            throw new NotImplementedException();
        }

        public Task UpdateTask(string title, string description, DateTime dueDate)
        {
            throw new NotImplementedException();
        }
    }
}
