using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradingSystem.Application.Features.StudnetCourses.Command.Create
{
    public class StudnetCoursesCreateCommand
    {
        public int StudnetId { get; set; }
        public int CourseId { get; set; }

        public int Grade { get; set; }

        public StudnetCoursesCreateCommand(int stId, int crsId, int grade)
        {
            StudnetId = stId;
            CourseId = crsId;
            Grade = grade;
        }
    }
}
