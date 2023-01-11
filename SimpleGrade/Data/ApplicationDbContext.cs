using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleGrade.Models;

namespace SimpleGrade.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<SchoolClass> Classes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}