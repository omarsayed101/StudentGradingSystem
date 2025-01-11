using StudentGradingSystem.Application.Interfaces;
using StudentGradingSystem.Context;

namespace StudentGradingSystem.Application.Repository
{
    public class StudnetRepository : CommonRepository<Domain.Models.Student>, IStudentRepository
    {
        public StudnetRepository(ApplicationContext appContext) : base(appContext)
        {

        }


    }
}
