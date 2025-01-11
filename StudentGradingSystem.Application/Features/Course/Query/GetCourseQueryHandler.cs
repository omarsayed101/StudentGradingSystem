using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentGradingSystem.Application.Interfaces;

namespace StudentGradingSystem.Application.Features.Course.Query
{
    public class GetCourseQueryHandler(ICourseRepository courserepo):IGetQueryHandler<int , Domain.Models.Course>
    {
        private readonly ICourseRepository _courserepo = courserepo;

        public  async Task<Domain.Models.Course> Handle(int Id)
        {
            if (Id == 0)
                throw new Exception("Invalid Id");

            var course = await  _courserepo.GetByIdAsync(Id);
            if (course == null)
                throw new Exception("Course Not Found");


                return course;
        }
    }
}
