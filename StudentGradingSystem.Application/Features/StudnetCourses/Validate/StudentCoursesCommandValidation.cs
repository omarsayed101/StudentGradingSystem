using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using StudentGradingSystem.Application.Features.StudnetCourses.Command.Create;

namespace StudentGradingSystem.Application.Features.StudnetCourses.Validate
{
    public class StudentCoursesCommandValidation:AbstractValidator<StudnetCoursesCreateCommand>
    {
        public StudentCoursesCommandValidation()
        {
                RuleFor(x=>x.StudnetId).NotNull().NotEmpty().WithMessage("Studnet Id can't be empty");
                RuleFor(x=>x.CourseId).NotNull().NotEmpty().WithMessage("Course Id can't be empty");
                RuleFor(x=>x.Grade).NotNull().NotEmpty().WithMessage("Grade can't be empty");
                RuleFor(x=>x.Grade).InclusiveBetween(0,100).WithMessage("Grade must be less than 100");
        }
    }
}
