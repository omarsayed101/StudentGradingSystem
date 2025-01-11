using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using StudentGradingSystem.Application.Features.Course.Validator;
using StudentGradingSystem.Application.Features.Student.Validator;
using StudentGradingSystem.Application.Interfaces;

namespace StudentGradingSystem.Application.Features.Student.Command.Update
{
    public class UpdateStudentCommandHandler(IStudentRepository studentrepo) : ICommandHandler<UpdateStudentCommand, Domain.Models.Student>
    {
        private readonly IStudentRepository _studentrepo = studentrepo;

        public async Task<Domain.Models.Student> Handle(UpdateStudentCommand command)
        {
            if (command.Id == 0)
                throw new Exception("Invalid Id ");

            try
            {
                var validator = new UpdateStudentValidator();
                var result = validator.Validate(command);

                if (result.IsValid)
                {
                    var student = await _studentrepo.GetByIdAsync(command.Id);

                    if (student == null)
                        throw new Exception("Studnet Not Found");

                    student.FirstName = command.FirstName;
                    student.LastName = command.LastName;
                    student.DateofBirth = command.DateofBirth;
                    student.Email = command.Email;
                    student.Phone = command.Phone;

                    await _studentrepo.Update(student);
                    return student;

                }
                else
                {
                    string resultstring = "";
                    foreach (var error in result.Errors)
                    {
                        resultstring += error;
                    }
                    throw new Exception(resultstring);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
