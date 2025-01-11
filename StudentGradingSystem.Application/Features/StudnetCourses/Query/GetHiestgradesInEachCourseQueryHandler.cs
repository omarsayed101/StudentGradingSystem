﻿using System;
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

            var studentcourse = await _studentCoursesRepository.GetAllWithFilterAndIncludesAsync(includes, b => b.CourseId == Id);

            var studentCoursesOrdered = await _studentCoursesRepository.OrderBy(studentcourse , s => s.Grade , isAscending : false);

            var studentCourseReturndto = new List<StudnetCourseReturnDto>();

            foreach (var item in studentCoursesOrdered)
            {
                studentCourseReturndto.Add(new StudnetCourseReturnDto()
                {
                    StdName = $"{item.Student.FirstName} {item.Student.LastName}",
                    CrsdName = item.Course.Name,
                    Grade = item.Grade
                });
            }


            return studentCourseReturndto.Take(3);
        }
    }
}