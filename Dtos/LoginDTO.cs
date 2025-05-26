using System.Security.Claims;
using TaskManagementApplication.Models;

namespace TaskManagementApplication.Dtos
{
    public class LoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
