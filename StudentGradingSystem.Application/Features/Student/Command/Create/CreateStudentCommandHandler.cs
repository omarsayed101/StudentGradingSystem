using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentGradingSystem.Application.Interfaces;

namespace StudentGradingSystem.Application.Features.Student.Command
{
    public class CreateStudentCommandHandler(IStudentRepository studnetrepo) : ICommandHandler<CreateStudentCommand, Domain.Models.Student>
    {
        private readonly IStudentRepository _studnetrepo = studnetrepo;

        public async Task<Domain.Models.Student> Handle(CreateStudentCommand command)
        {
            try
            {
                var validator = new CreateStudentValidator();
                var result = validator.Validate(command);
                if (result.IsValid)
                {
                    var student = new Domain.Models.Student()
                    {
                        FirstName = command.FirstName,
                        LastName = command.LastName,
                        DateofBirth = command.DateofBirth,
                        Email = command.Email,
                        Phone = command.Phone,

                    };

                    await _studnetrepo.Add(student);

                    return student;

                }
                else
                {
                    var messagetoreturn = "";
                    foreach (var error in result.Errors)
                    {
                        messagetoreturn += error;
                    }
                    throw new Exception(messagetoreturn);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
