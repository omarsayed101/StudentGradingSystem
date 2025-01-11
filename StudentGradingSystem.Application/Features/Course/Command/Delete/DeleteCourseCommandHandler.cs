using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentGradingSystem.Application.Interfaces;

namespace StudentGradingSystem.Application.Features.Course.Command.Delete
{
    public class DeleteCourseCommandHandler(ICourseRepository courserepo) : ICommandHandler<int, Domain.Models.Course>
    {

        private readonly ICourseRepository _courserepo = courserepo;



        public async Task<Domain.Models.Course> Handle(int Id)
        {
            var course = await courserepo.GetByIdAsync(Id);

            await courserepo.Delete(Id);

            return course;
        }
    }
}
