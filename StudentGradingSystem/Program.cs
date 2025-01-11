
using Microsoft.EntityFrameworkCore;
using StudentGradingSystem.Application.Features.Course.Command;
using StudentGradingSystem.Application.Features.Course.Command.Create;
using StudentGradingSystem.Application.Features.Course.Command.Delete;
using StudentGradingSystem.Application.Features.Course.Command.Update;
using StudentGradingSystem.Application.Features.Course.Query;
using StudentGradingSystem.Application.Features.Student.Command;
using StudentGradingSystem.Application.Features.Student.Command.Delete;
using StudentGradingSystem.Application.Features.Student.Command.Update;
using StudentGradingSystem.Application.Features.Student.Query;
using StudentGradingSystem.Application.Features.StudnetCourses.Command.Create;
using StudentGradingSystem.Application.Features.StudnetCourses.Query;
using StudentGradingSystem.Application.Interfaces;
using StudentGradingSystem.Application.Repository;
using StudentGradingSystem.Context;

namespace StudentGradingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connstring = builder.Configuration.GetConnectionString("Default");

            builder.Services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseMySql(connstring, ServerVersion.AutoDetect(connstring));
            });


            builder.Services.AddScoped(typeof(IStudentRepository), typeof(StudnetRepository));
            builder.Services.AddScoped(typeof(ICourseRepository), typeof(CourseRepostiroy));
            builder.Services.AddScoped(typeof(IStudentCoursesRepository), typeof(StudentCourseRepository));

            builder.Services.AddScoped(typeof(CreateCourseCommandHandler));
            builder.Services.AddScoped(typeof(UpdateCourseCommandHandler));
            builder.Services.AddScoped(typeof(DeleteCourseCommandHandler));
            builder.Services.AddScoped(typeof(GetAllCoursesQueryHandler));
            builder.Services.AddScoped(typeof(GetCourseQueryHandler));
            
            builder.Services.AddScoped(typeof(CreateStudentCommandHandler));
            builder.Services.AddScoped(typeof(UpdateStudentCommandHandler));
            builder.Services.AddScoped(typeof(DeleteStudentCommandHandler));
            builder.Services.AddScoped(typeof(GetAllStudentsQueryHandler));
            builder.Services.AddScoped(typeof(GetStudentQueryHandler));

            builder.Services.AddScoped(typeof(StudnetCoursesCreateCommandHandler));
            builder.Services.AddScoped(typeof(GetHieghestGradesQueryHandler));
            builder.Services.AddScoped(typeof(GetHiestgradesInEachCourseQueryHandler));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
