using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DTos;
using DTos.StudentCoursesDTos;
using StudentGradingSystem.Application.Interfaces;

namespace StudentGradingSystem.Application.Features.StudnetCourses.Query
{
    public class GetTotalHieghestGradesQueryHandler(IStudentCoursesRepository studentCoursesRepository) : IGetAllQueryHandler<IEnumerable<TotalGradesDto>>
    {
        private readonly IStudentCoursesRepository _studentCoursesRepository = studentCoursesRepository;

        public async Task<IEnumerable<TotalGradesDto>> Handle()
        {
            var includes = new List<Expression<Func<Domain.Models.StudentCourse, object>>>()
            {
                sc=>sc.Student,
                sc=>sc.Course,
            };

            var totalGradDto = _studentCoursesRepository.GetAllWithFilterAndIncludesAsync(includes).Result.GroupBy(g => new { g.Student.FirstName, g.Student.LastName})
                .Select(group=>new TotalGradesDto 
                { StudnetName = $"{group.Key.FirstName} {group.Key.LastName}" , 
                    TotalGrade = group.Sum(sc=>sc.Grade) 
                }).OrderByDescending(sc=>sc.TotalGrade).ToList().Take(3);

            return  totalGradDto;
        }
    }
}
