using FluentValidation;
using StudentGradingSystem.Application.Features.Course.Command.Create;
using StudentGradingSystem.Application.Student.Command.DTos;
namespace StudentGradingSystem.Application.Features.Course.Validator
{
    public class CreaeteCourseValidator : AbstractValidator<CreateCommand>
    {
        public CreaeteCourseValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Course Name Can't Be Empty");
        }
    }
}
