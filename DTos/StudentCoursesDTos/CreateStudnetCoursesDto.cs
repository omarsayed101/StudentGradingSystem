using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTos.StudentCoursesDTos
{
    public class CreateStudnetCoursesDto
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public int Grade { get; set; }
    }
}
