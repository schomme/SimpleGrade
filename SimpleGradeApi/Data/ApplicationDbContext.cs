using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleGrade.Models;

namespace SimpleGrade.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Group> Groups { get; set; }

        public DbSet<Student> Students { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}