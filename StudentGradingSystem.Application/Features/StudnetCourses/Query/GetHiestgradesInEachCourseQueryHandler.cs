using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DTos.StudentCoursesDTos;
using StudentGradingSystem.Application.Interfaces;
using StudentGradingSystem.Domain.Models;

namespace StudentGradingSystem.Application.Features.StudnetCourses.Query
{
    public class GetHiestgradesInEachCourseQueryHandler(IStudentCoursesRepository studentCoursesRepository , ICourseRepository courseRepository) : IGetQueryOrderedHandler<int ,IEnumerable<StudnetCourseReturnDto>>
    {
        private readonly IStudentCoursesRepository _studentCoursesRepository = studentCoursesRepository;
        private readonly ICourseRepository _courseRepository = courseRepository;

        public async Task<IEnumerable<StudnetCourseReturnDto>> Handle(int Id)
        {


            var includes = new List<Expression<Func<Domain.Models.StudentCourse, object>>>()
            {
                sc=>sc.Student,
                sc=>sc.Course,
            };

            var studenstudentCourseReturndtotcourse =  _studentCoursesRepository.GetAllWithFilterAndIncludesAsync(includes, c => c.CourseId == Id)
                .Result.OrderByDescending(sc=>sc.Grade)
                .Select(sc => new StudnetCourseReturnDto() 
              { StdName = $"{sc.Student.FirstName} {sc.Student.LastName}",
                CrsName = sc.Course.Name, 
                Grade = sc.Grade }).ToList().Take(3);

      

            return studenstudentCourseReturndtotcourse;
        }
    }
}
