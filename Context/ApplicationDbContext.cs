using Microsoft.EntityFrameworkCore;
using TaskManagementApplication.Models;

namespace TaskManagementApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }  // Add this
    }
}
