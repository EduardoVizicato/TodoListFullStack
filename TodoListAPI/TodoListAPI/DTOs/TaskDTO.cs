using TodoList.Domain.Models;

namespace TodoListAPI.DTOs
{
    public class TaskDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskModelStatus Status { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
