using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentGradingSystem.Application.Features.Course.Command.Create;
using StudentGradingSystem.Application.Features.Course.Validator;
using StudentGradingSystem.Application.Interfaces;
using StudentGradingSystem.Application.Student.Command.DTos;

namespace StudentGradingSystem.Application.Features.Course.Command.Update
{
    public class UpdateCourseCommandHandler(ICourseRepository courserepo) : ICommandHandler<UpdateCommand , Domain.Models.Course>
    {
        private readonly ICourseRepository _courserepo = courserepo;

        public async Task<Domain.Models.Course> Handle(UpdateCommand command)
        {
            if ( command.Id == 0)
                throw new Exception("Invalid Id ");

            try
            {
                var validator = new UpdateCourseValidator();
                var result = validator.Validate(command);

                if (result.IsValid)
                {
                    var course = await _courserepo.GetByIdAsync(command.Id);

                    if (course == null)
                        throw new Exception("Course Not Found");

                    course.Name = command.Name;
                    await courserepo.Update(course);
                    return course;

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
