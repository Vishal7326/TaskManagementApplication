namespace TaskManagementApplication.Dtos
{
    public class AddTask
    {
        public required string Title { get; set; } // Title of the task 

        public string? Description { get; set; } // Description of the task  

        public DateTime DueDate { get; set; } // Due date for the task

        public bool IsCompleted { get; set; } // Indicates if the task is completed 
    }
}
