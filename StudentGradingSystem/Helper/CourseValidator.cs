using FluentValidation;
using StudentGradingSystem.DTos;
using StudentGradingSystem.Models;

namespace StudentGradingSystem.Helper
{
    public class CourseValidator:AbstractValidator<CourseDto>
    {
        public CourseValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Course Name Can't Be Empty");
        }
    }
}
