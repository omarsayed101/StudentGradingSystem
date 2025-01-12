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
            var StudnetCoursesWithHieghstGradesdto =  _studentCoursesRepo.GetAllWithFilterAndIncludesAsync(includes).Result.OrderByDescending(s => s.Grade)
            .Select(sc => new StudnetCourseReturnDto
            {
                StdName = $"{sc.Student.FirstName} {sc.Student.LastName}",
                CrsName = sc.Course.Name,
                Grade = sc.Grade
            }).ToList();

       

            return StudnetCoursesWithHieghstGradesdto;
        }
    }
}
