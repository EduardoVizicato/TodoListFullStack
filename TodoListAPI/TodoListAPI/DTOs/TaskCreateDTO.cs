namespace TodoListAPI.DTOs
{
    public class TaskCreateDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
