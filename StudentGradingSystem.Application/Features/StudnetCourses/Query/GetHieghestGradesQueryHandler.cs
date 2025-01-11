using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DTos.StudentCoursesDTos;
using StudentGradingSystem.Application.Interfaces;

namespace StudentGradingSystem.Application.Features.StudnetCourses.Query
{
    public class GetHieghestGradesQueryHandler(IStudentCoursesRepository studentCoursesRepo) : IGetAllQueryHandler<IEnumerable<StudnetCourseReturnDto>>
    {
        private readonly IStudentCoursesRepository _studentCoursesRepo = studentCoursesRepo;

        public async Task<IEnumerable<StudnetCourseReturnDto>> Handle()
        {
            var includes = new List<Expression<Func<Domain.Models.StudentCourse, object>>>()
            {
                sc=>sc.Course,
                sc=>sc.Student,

            };
            var studentcourse = await _studentCoursesRepo.GetAllWithFilterAndIncludesAsync(includes);

             var StudnetCoursesWithHieghstGrades= await _studentCoursesRepo.OrderBy(studentcourse , s=>s.Grade , isAscending: false);

            var returndto = new List<StudnetCourseReturnDto>();

            foreach (var item in StudnetCoursesWithHieghstGrades)
            {
                returndto.Add(new StudnetCourseReturnDto {
                    StdName = $"{item.Student.FirstName} {item.Student.LastName}",
                    CrsdName = item.Course.Name,
                    Grade = item.Grade
                });
            }

            return returndto;
        }
    }
}
