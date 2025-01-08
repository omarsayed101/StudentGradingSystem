using StudentGradingSystem.Context;
using StudentGradingSystem.Models;

namespace StudentGradingSystem.Repository
{
    public class CourseRepostiroy:CommonRepository<Course>,ICourseRepository
    {

        public CourseRepostiroy(ApplicationContext appContext):base(appContext) 
        {
        }
    }
}
