using StudentGradingSystem.Context;
using StudentGradingSystem.Models;

namespace StudentGradingSystem.Repository
{
    public class StudnetRepository:CommonRepository<Student> , IStudentRepository
    {
        public StudnetRepository(ApplicationContext appContext):base(appContext)
        {
            
        }


    }
}
