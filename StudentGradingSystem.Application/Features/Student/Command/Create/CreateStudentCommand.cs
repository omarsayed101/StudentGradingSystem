using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using StudentGradingSystem.Domain.Models;
using StudentGradingSystem.Application.Interfaces;
using DTos.StudentDto;
using System.ComponentModel.DataAnnotations;

namespace StudentGradingSystem.Application.Features.Student.Command
{
    public class CreateStudentCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateOnly DateofBirth { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public CreateStudentCommand(string firstName , string lastName , DateOnly dateOfbirth , string email , string phone)
        {
                this.FirstName = firstName; 
            this.LastName = lastName;       
            this.DateofBirth = dateOfbirth;
            this.DateofBirth  = dateOfbirth;
            this.Email = email; 
            this.Phone = phone;
        }


    }
}
