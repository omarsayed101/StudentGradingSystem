
using Microsoft.EntityFrameworkCore;
using StudentGradingSystem.Context;
using StudentGradingSystem.Repository;

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
