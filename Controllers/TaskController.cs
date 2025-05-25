using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApplication.Context;
using TaskManagementApplication.Dtos;
using TaskManagementApplication.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskManagementApplication.Controllers
{
    //It Goes to the localhost port number that it is running on.
    //localhost:xxxx/api/controller.
    //In this case it would be 
    //localhost:xxxx/api/employees.
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext; //private field  
        public TaskController(ApplicationDbContext dbContext) // Using ApplicationDbCOntext from the Data
        {
            this.dbContext = dbContext; // Assigning the dbContext to the private field
        }

        //Reading All Tasks that User has created.

        [HttpGet]


        //An Action Method is a public method in an ASP.NET Core Controller
        //that responds to an HTTP request — like GET, POST, PUT, or DELETE.
        //IActionResult is an interface that allows you to return various kinds of HTTP responses from a controller action — making your controller
        //more flexible and RESTful.

        public IActionResult GetAllEmployees() //This Method Can help you connecct to the database and can help u return live data from the database.
        {
            // InOrder to Connect to the database we need sbcontext 
            //The Purpose of Injecting DbContext in Programcs was to Access the dbContext anywhere in the program.
            //Hence We are returning this to api we need to status ok.
            var allTasks = dbContext.Tasks.ToList();

            return Ok(allTasks);

        }

        [HttpPost]
        public IActionResult AddTasks(AddTask addtask) //This Method Can help you connecct to the database and can help u return live data from the database.
        {
            //InOrder to Connect to the database we need sbcontext 
            //The Purpose of Injecting DbContext in Programcs was to Access the dbContext anywhere in the program.
            //Hence We are returning this to api we need to status ok.
            var task = new TaskList
            {
                Title = addtask.Title,
                Description = addtask.Description,
                DueDate = addtask.DueDate,
                IsCompleted = addtask.IsCompleted
            };

            dbContext.Tasks.Add(task); // What we have is EmployeeDto but in add function it takes only entity 
                                       // So we need to convert dto into entity

            dbContext.SaveChanges(); // The actions that you want to make will be changed and saved.

            return Ok(task);
        }
    
    }
}
