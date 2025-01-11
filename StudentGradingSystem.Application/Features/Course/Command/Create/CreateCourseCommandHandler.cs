using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using StudentGradingSystem.Application.Features.Course.Query;
using StudentGradingSystem.Application.Features.Course.Validator;
using StudentGradingSystem.Application.Interfaces;
using StudentGradingSystem.Application.Student.Command.DTos;

namespace StudentGradingSystem.Application.Features.Course.Command.Create
{
    public class CreateCourseCommandHandler : ICommandHandler<CreateCommand, Domain.Models.Course>
    {
        private readonly ICourseRepository _courserepo;

        public CreateCourseCommandHandler(ICourseRepository courserepo)
        {
            _courserepo = courserepo;
        }
        public async Task<Domain.Models.Course> Handle(CreateCommand command)
        {
            try
            {
                var validator = new CreaeteCourseValidator();
                var result = validator.Validate(command);
                if (result.IsValid)
                {
                    var course = new Domain.Models.Course()
                    {
                        Name = command.Name,
                    };
                    await _courserepo.Add(course);

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
