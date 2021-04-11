using Microsoft.EntityFrameworkCore;
using StudentApp.Core.Models;

namespace StudentApp.Models
{
    public class StudentContext :DbContext
    {

        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        {
        }
        public DbSet<Student> students { get; set; }
        public DbSet<Level> levels { get; set; }
        }
}
