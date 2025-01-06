using Microsoft.EntityFrameworkCore;
using StudentGradingSystem.Models;

namespace StudentGradingSystem.Context
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options) 
        {
                
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentCourse>().HasKey(sc=>new {sc.StudentId , sc.CourseId });

      

             modelBuilder.Entity<Student>().HasData(

             new Student
             {
                 Id = 1,
                 FirstName = "Ahmed",
                 LastName = "Mohamed",
                 DateofBirth = new DateOnly(2005, 5, 20),
                 Email = "Ahmed@gmail.com",
                 Phone = "01234567891"
             },

              new Student
              {
                  Id = 2,
                  FirstName = "Ali",
                  LastName = "Mahmoud",
                  DateofBirth = new DateOnly(2004, 10, 15),
                  Email = "AliMahmoud@gmail.com",
             
                  Phone = "01234567891"
              }

              );

            modelBuilder.Entity<Course>().HasData(
          
                new Course { Id = 1, Name="C++" },
                new Course { Id = 2, Name="Python" }
            );

            modelBuilder.Entity<StudentCourse>().HasData(

             new StudentCourse { StudentId = 1, CourseId=2 , Grade = 90 },
             new StudentCourse { StudentId = 2, CourseId=1 , Grade = 75 }
             );
        }
    }
}
