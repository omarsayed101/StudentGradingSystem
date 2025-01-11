using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentGradingSystem.Application.Interfaces;

namespace StudentGradingSystem.Application.Features.Course.Query
{
    public class GetAllCoursesQueryHandler(ICourseRepository courserepo):IGetAllQueryHandler<IEnumerable<Domain.Models.Course>>
    {
        private readonly ICourseRepository _courserepo = courserepo;

        public async Task<IEnumerable<Domain.Models.Course>> Handle()
        {
           return await _courserepo.GetAllAsync();
        }
    }
}
