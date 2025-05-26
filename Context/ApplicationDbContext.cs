using Microsoft.EntityFrameworkCore;
using TaskManagementApplication.Models;
using TaskManagementApplication.Data;

namespace TaskManagementApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<TaskList> Tasks { get; set; }

        public DbSet<User> Users { get; set; }
    }
}