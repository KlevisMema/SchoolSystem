using Microsoft.EntityFrameworkCore;
using SchoolSystem.DAL.Models;

namespace SchoolSystem.DAL.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
