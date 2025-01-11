using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentGradingSystem.Application.Interfaces;

namespace StudentGradingSystem.Application.Features.Student.Query
{
    public class GetStudentQueryHandler(IStudentRepository studentrepo) : IGetQueryHandler<int, Domain.Models.Student>
    {
        private readonly IStudentRepository _studentrepo = studentrepo;

        public  async Task<Domain.Models.Student> Handle(int Id)
        {
            var student = await _studentrepo.GetByIdAsync(Id );

            if (student == null)
                throw new Exception("Student Not Found");

            return student;

        }
    }
}
