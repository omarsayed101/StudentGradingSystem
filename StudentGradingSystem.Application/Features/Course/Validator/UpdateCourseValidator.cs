using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using StudentGradingSystem.Application.Features.Course.Command.Update;

namespace StudentGradingSystem.Application.Features.Course.Validator
{
    public class UpdateCourseValidator:AbstractValidator<UpdateCommand>
    {
        public UpdateCourseValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Course Id is required");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Course Name is required");
        }
    }
}
