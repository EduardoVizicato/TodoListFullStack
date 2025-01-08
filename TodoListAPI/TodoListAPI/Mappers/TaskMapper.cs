using TodoList.Domain.Models;
using TodoListAPI.DTOs;

namespace TodoListAPI.Mappers
{
    public class TaskMapper
    {
        public static void MapToTaskDTO(TaskModel taskModel, TaskDTO taskDTO)
        {
            taskDTO.Id = taskModel.Id;
            taskDTO.Title = taskModel.Title;
            taskDTO.Description = taskModel.Description;
            taskDTO.Status = taskModel.Status;
            taskDTO.DueDate = taskModel.DueDate;

        }

        public static void MapToTaskCreateDTO(TaskCreateDTO taskCreateDTO, TaskModel taskModel)
        {
            taskCreateDTO.Title = taskModel.Title;
            taskCreateDTO.Description = taskModel.Description;
            taskCreateDTO.DueDate = taskModel.DueDate;
        }

        public static void MapToTaskUpdateDTO(TaskUpdateDTO taskUpdateDTO, TaskModel taskModel)
        {
            taskUpdateDTO.Title = taskModel.Title;
            taskUpdateDTO.Description = taskModel.Description;
            taskUpdateDTO.Status = taskModel.Status;
            taskUpdateDTO.DueDate = taskModel.DueDate;
        }
    }
}
