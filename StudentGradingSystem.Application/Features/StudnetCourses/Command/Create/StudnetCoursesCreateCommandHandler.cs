using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentGradingSystem.Application.Features.StudnetCourses.Validate;
using StudentGradingSystem.Application.Interfaces;
using StudentGradingSystem.Domain.Models;

namespace StudentGradingSystem.Application.Features.StudnetCourses.Command.Create
{
    public class StudnetCoursesCreateCommandHandler(IStudentCoursesRepository studentCoursesRepo) : ICommandHandler<StudnetCoursesCreateCommand, StudentCourse>
    {
        private readonly IStudentCoursesRepository _studentCoursesRepo = studentCoursesRepo;

        public async Task<StudentCourse> Handle(StudnetCoursesCreateCommand command)
        {
            try
            {
                var validator = new StudentCoursesCommandValidation();
                var result = validator.Validate(command);

                if (result.IsValid)
                {
                    var studentCourses = new StudentCourse
                    {
                        StudentId = command.StudnetId,
                        CourseId = command.CourseId,
                        Grade = command.Grade
                    };

                    await _studentCoursesRepo.Add(studentCourses);

                    return studentCourses;
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
