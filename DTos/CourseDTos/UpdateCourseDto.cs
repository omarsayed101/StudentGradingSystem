using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentGradingSystem.Application.Student.Command.DTos;

namespace DTos.CourseDTos
{
    public class UpdateCourseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

    }
}
