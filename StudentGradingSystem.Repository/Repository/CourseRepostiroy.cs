using StudentGradingSystem.Application.Interfaces;
using StudentGradingSystem.Context;
using StudentGradingSystem.Domain.Models;

namespace StudentGradingSystem.Application.Repository
{
    public class CourseRepostiroy : CommonRepository<Course>, ICourseRepository
    {

        public CourseRepostiroy(ApplicationContext appContext) : base(appContext)
        {
        }
    }
}
