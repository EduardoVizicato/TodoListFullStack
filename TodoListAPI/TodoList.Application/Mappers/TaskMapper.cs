using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Application.DTOs;
using TodoList.Domain.Models;

namespace TodoList.Application.Mappers
{
    public class TaskMapper
    {
        public static TaskDTO ToDTO(TaskModel taskModel)
        {
            return new TaskDTO()
            {
                Id = taskModel.Id,
                Title = taskModel.Title,
                Description = taskModel.Description,
                Status = taskModel.Status,
                DueDate = taskModel.DueDate,
            };
        }

        public static TaskModel ToTaskModelUpdate(TaskUpdateDTO taskUpdateDTO)
        {
            return new TaskModel()
            {
                Title = taskUpdateDTO.Title,
                Description = taskUpdateDTO.Description,
                Status = taskUpdateDTO.Status,
                DueDate = taskUpdateDTO.DueDate,
            };
        }

        public static TaskModel TaskModelCreate(TaskCreateDTO taskCreateDTO)
        {
            return new TaskModel()
            {
                Title = taskCreateDTO.Title,
                Description = taskCreateDTO.Description,
                DueDate= taskCreateDTO.DueDate,
            };
        }
    } 
}
