using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentGradingSystem.Application.Interfaces;

namespace StudentGradingSystem.Application.Features.Student.Command.Update
{
    public class UpdateStudentCommand
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateOnly DateofBirth { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public UpdateStudentCommand(int Id, string firstName, string lastName, DateOnly dateOfbirth, string email, string phone)
        {
            this.Id = Id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateofBirth = dateOfbirth;
            this.DateofBirth = dateOfbirth;
            this.Email = email;
            this.Phone = phone;

        }
    }
}