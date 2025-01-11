using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTos.CourseDTos;
using StudentGradingSystem.Application.Student.Command.DTos;

namespace StudentGradingSystem.Application.Features.Course.Command.Create
{
    public class CreateCommand 
    {
        public string Name { get; set; }
        public CreateCommand(string Name)
        {
                this.Name = Name;
        }

       
    }
}
