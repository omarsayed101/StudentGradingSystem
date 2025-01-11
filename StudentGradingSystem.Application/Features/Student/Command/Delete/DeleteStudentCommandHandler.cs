using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentGradingSystem.Application.Interfaces;

namespace StudentGradingSystem.Application.Features.Student.Command.Delete
{
    public class DeleteStudentCommandHandler(IStudentRepository studentrepo) : ICommandHandler<int, Domain.Models.Student>
    {
        private readonly IStudentRepository _studentrepo = studentrepo;

        public async Task<Domain.Models.Student> Handle(int Id)
        {
            var student = await studentrepo.GetByIdAsync(Id);

            await studentrepo.Delete(Id);

            return student;
        }
    }
}
