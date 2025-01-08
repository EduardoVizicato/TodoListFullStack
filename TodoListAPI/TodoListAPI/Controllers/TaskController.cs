using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Identity.Client;
using TodoList.Domain.Models;
using TodoList.Domain.Repositories;
using TodoList.Domain.Services.Interfaces;
using TodoListAPI.DTOs;

namespace TodoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController(ITaskService taskService, ILogger<TaskController> logger) : ControllerBase
    {
        private readonly ITaskService _taskService = taskService;
        private readonly ILogger<TaskController> _logger = logger;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _taskService.GetTasks();
            if (!data.Any())
            {
                return NoContent();
            }

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskAsync([FromBody] TaskCreateDTO taskCreateDTO)
        {
            if (taskCreateDTO == null)
            {
                return BadRequest();
            }

            try
            {
                var taskModel = new TaskModel
                {
                    Title = taskCreateDTO.Title,
                    Description = taskCreateDTO.Description,
                    DueDate = taskCreateDTO.DueDate,
                };

                var createdTask = await _taskService.CreateTask(taskModel);

                var taskDTO = new TaskDTO
                {
                    Id = createdTask.Id,
                    Title = createdTask.Title,
                    Description = createdTask.Description,
                    Status = createdTask.Status,
                    DueDate = createdTask.DueDate,
                };

                return CreatedAtAction(nameof(GetTaskById), new { id = taskDTO.Id }, taskDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while creating task: ({ex.Message})");
                return StatusCode(500);
            }
        }

        [HttpGet("overdue")]
        public async Task<IActionResult> GetOverDueTasksAsync()
        {
            var data = await _taskService.GetOverdueTasks();
            if (!data.Any())
            {
                return NoContent();
            }

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(Guid id)
        {
            var data = await _taskService.GetTaskById(id);
            if(data == null)
            {
                return NoContent();
            }

            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTask(Guid id, [FromBody] TaskUpdateDTO taskUpdateDTO)
        {
            if (taskUpdateDTO == null)
            {
                return BadRequest();
            }
            try
            {
                var taskModel = new TaskModel
                {
                    Id = id,
                    Title = taskUpdateDTO.Title,
                    Description = taskUpdateDTO.Description,
                    Status = taskUpdateDTO.Status,
                    DueDate = taskUpdateDTO.DueDate,
                };

                var updateTask = await _taskService.UpdateTask(id, taskModel);

                var taskDTO = new TaskUpdateDTO
                {
                    Title = updateTask.Title,
                    Description = updateTask.Description,
                    Status = updateTask.Status,
                    DueDate = updateTask.DueDate,
                };

                return Ok(taskDTO);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating task{ex.Message}");
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var deleted = await _taskService.DeleteTask(id);
            if (deleted == null)
            {
                return BadRequest();
            }
            return Ok(deleted);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> CompleteTask(Guid id)
        {
            var completed = await _taskService.CompleteTask(id);
            if (completed == null)
            {
                return BadRequest();
            }
            return Ok(completed);
        }

    }

}
