using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTos.CourseDTos;

namespace StudentGradingSystem.Application.Features.Course.Command.Update
{
    public class UpdateCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UpdateCommand(int Id ,string Name)
        {
                this.Id = Id;
            this.Name = Name;
        }
    }
}
