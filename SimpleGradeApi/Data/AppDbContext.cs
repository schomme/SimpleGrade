using Microsoft.EntityFrameworkCore;
using SimpleGrade.Base.Model;
using SimpleGrade.Base.Model.Connection;
using SimpleGrade.Base.Model.Person;

namespace SimpleGradeApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<ClassGroup> Classes { get; set; }
        public DbSet<SubjectGroup> Subjects { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Connection> Connections { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
    }
}
