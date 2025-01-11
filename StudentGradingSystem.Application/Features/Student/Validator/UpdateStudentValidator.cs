 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using StudentGradingSystem.Application.Features.Course.Command.Update;
using StudentGradingSystem.Application.Features.Student.Command.Update;

namespace StudentGradingSystem.Application.Features.Student.Validator
{
    public class UpdateStudentValidator:AbstractValidator<UpdateStudentCommand>
    {
        public UpdateStudentValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Id must have value");
            RuleFor(x => x.FirstName).NotNull().NotEmpty().WithMessage("First Name Can't be Empty");
            RuleFor(x => x.LastName).NotNull().NotEmpty().WithMessage("Last Name Can't be Empty");
            RuleFor(x => x.DateofBirth).NotNull().NotEmpty().WithMessage("DOB  Can't be Empty");
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("Email Can't be Empty");
            RuleFor(x => x.Phone).NotNull().NotEmpty().WithMessage("Phone Can't be Empty");
        }
    }
}
