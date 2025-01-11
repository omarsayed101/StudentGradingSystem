using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentGradingSystem.Application.Interfaces;

namespace StudentGradingSystem.Application.Features.Student.Query
{
    public class GetAllStudentsQueryHandler(IStudentRepository studentrepo) : IGetAllQueryHandler<IEnumerable<Domain.Models.Student>>
    {
        private readonly IStudentRepository _studentrepo = studentrepo;

        public async Task<IEnumerable<Domain.Models.Student>> Handle()
        {
            return await _studentrepo.GetAllAsync();
        }
    }
}
