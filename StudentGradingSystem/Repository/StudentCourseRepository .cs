using StudentGradingSystem.Context;
using StudentGradingSystem.Models;

namespace StudentGradingSystem.Repository
{
    public class StudentCourseRepository : CommonRepository<StudentCourse> ,IStudentCoursesRepository
    {
        public StudentCourseRepository(ApplicationContext appContext):base(appContext) 
        {
                
        }
    }
}
