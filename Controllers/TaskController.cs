using Microsoft.AspNetCore.Mvc;
using TaskManagementApplication.Data;
using TaskManagementApplication.Dtos;
using TaskManagementApplication.Models;

namespace TaskManagementApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public TaskController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var allTasks = dbContext.Tasks.ToList();
            return Ok(allTasks);
        }

        [HttpPost]
        public IActionResult AddTasks(AddTask addtask)
        {
            var task = new TaskList
            {
                Title = addtask.Title,
                Description = addtask.Description,
                DueDate = addtask.DueDate,
                IsCompleted = addtask.IsCompleted
            };

            dbContext.Tasks.Add(task);
            dbContext.SaveChanges();

            return Ok(task);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateTheResult(Guid id, UpdateTask updatetask)
        {
            var TaskUpdate = dbContext.Tasks.Find(id);

            if (TaskUpdate == null)
            {
                return NotFound();
            }

            TaskUpdate.Title = updatetask.Title;
            TaskUpdate.Description = updatetask.Description;
            TaskUpdate.DueDate = updatetask.DueDate;
            TaskUpdate.IsCompleted = updatetask.IsCompleted;

            dbContext.SaveChanges();

            return Ok(TaskUpdate);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteTaskById(Guid id)
        {
            var DeleteTask = dbContext.Tasks.Find(id);

            if (DeleteTask is null)
            {
                return NotFound();
            }

            dbContext.Tasks.Remove(DeleteTask);
            dbContext.SaveChanges();

            return Ok(DeleteTask);
        }
    }
}
