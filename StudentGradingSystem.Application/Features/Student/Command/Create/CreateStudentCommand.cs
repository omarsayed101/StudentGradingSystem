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

        //public async Task<Domain.Models.Student> CreteStudent(StudentDto studentDto)
        //{
        //    try
        //    {
        //        var validator = new StudentValidator();
        //        var result = validator.Validate(studentDto);
        //        if (result.IsValid)
        //        {
        //            var student = new Core.Models.Student()
        //            {
        //                FirstName = studentDto.FirstName,
        //                LastName = studentDto.LastName,
        //                DateofBirth = studentDto.DateofBirth,
        //                Email = studentDto.Email,
        //                Phone = studentDto.Phone,
        //            };
        //            await studentrepo.Add(student);

        //            return student;

        //        }
        //        else
        //        {
        //            string resultstring = "";
        //            foreach (var error in result.Errors)
        //            {
        //                resultstring += error;
        //            }
        //            throw new Exception(resultstring);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }
        //}

        //public async Task<Core.Models.Student> UpdateStudent(StudentDto studentDto, int Id)
        //{
        //    if (Id == 0)
        //        throw new Exception("Invalid Id ");

        //    try
        //    {
        //        var validator = new StudentValidator();
        //        var result = validator.Validate(studentDto);

        //        if (result.IsValid)
        //        {
        //            var student = await studentrepo.GetByIdAsync(Id);

        //            student.FirstName = studentDto.FirstName;
        //            student.LastName = studentDto.LastName;
        //            student.DateofBirth = studentDto.DateofBirth;
        //            student.Email = studentDto.Email;
        //            student.Phone = studentDto.Phone;




        //            await studentrepo.Update(student);
        //            return student;

        //        }
        //        else
        //        {
        //            string resultstring = "";
        //            foreach (var error in result.Errors)
        //            {
        //                resultstring += error;
        //            }
        //            throw new Exception(resultstring);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }

        //}

        //public async Task<Core.Models.Student> DeleteStudent(int Id)
        //{
        //    var student = await studentrepo.GetByIdAsync(Id);

        //    await studentrepo.Delete(Id);

        //    return student;
        //}
    }
}
