using StudentGradingSystem.Application.Interfaces;
using StudentGradingSystem.Context;
using StudentGradingSystem.Domain.Models;

namespace StudentGradingSystem.Application.Repository
{
    public class StudentCourseRepository : CommonRepository<StudentCourse>, IStudentCoursesRepository
    {
        public StudentCourseRepository(ApplicationContext appContext) : base(appContext)
        {

        }
    }
}
