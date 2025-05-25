using System;

namespace TaskManagementApplication.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }  // Hashed password
        public string Role { get; set; } = "User"; // Default to "User", can also be "Admin"
    }
}
