using DTos.StudentDto;
using FluentValidation;
using StudentGradingSystem.Domain.Models;

namespace StudentGradingSystem.Application.Features.Student.Command
{
    public class CreateStudentValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().WithMessage("First Name Can't be Empty");
            RuleFor(x => x.LastName).NotNull().NotEmpty().WithMessage("Last Name Can't be Empty");
            RuleFor(x => x.DateofBirth).NotNull().NotEmpty().WithMessage("DOB  Can't be Empty");
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("Email Can't be Empty");
            RuleFor(x => x.Phone).NotNull().NotEmpty().WithMessage("Phone Can't be Empty");
        }
    }
}
