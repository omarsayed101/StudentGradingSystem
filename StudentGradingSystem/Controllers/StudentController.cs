using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentGradingSystem.DTos;
using StudentGradingSystem.Helper;
using StudentGradingSystem.Models;
using StudentGradingSystem.Repository;

namespace StudentGradingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository studentRepo;

        public StudentController(IStudentRepository studentRepo)
        {
            this.studentRepo = studentRepo;
        }

        [HttpGet("GetAllStudents")]
        public async Task<IActionResult> GetAllStudents()
        {
            return Ok(studentRepo.GetAllAsync());
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAllStudentsWithFilteration(int Id)
        {
            return Ok(studentRepo.GetAllWithFilterAsync(s => s.Id == Id));
        }

        [HttpGet("GetAllStudentsOrderdbyName")]
        public async Task<IActionResult> GetAllStudentsOrderdbyName()
        {
            var students = await studentRepo.GetAllAsync();
            return Ok(studentRepo.OrderBy(students,s=>s.DateofBirth));

        }

        [HttpPost("CreateStudent")]
        public async Task<IActionResult> CreateStudent([FromBody]StudentDto studentdto)
        {
            try
            {
                var validator = new StudentValidator();
                var result = validator.Validate(studentdto);
                if (result.IsValid)
                {
                    var student = new Student()
                    {
                        FirstName = studentdto.FirstName,
                        LastName = studentdto.LastName,
                        DateofBirth = studentdto.DateofBirth,
                        Email = studentdto.Email,
                        Phone = studentdto.Phone,
                    };
                    await studentRepo.Add(student);

                    return Ok(student);
                }
                else
                {
                    string resultstring = "";
                    foreach (var error in result.Errors)
                    {
                        resultstring += error; 
                    }
                    throw new Exception(resultstring);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
    
        }

        [HttpPost("UpdateStudent/{Id}")]
        public async Task<IActionResult> UpdateStudent([FromBody]StudentDto studentdto , int Id)
        {
            try
            {
                var validator = new StudentValidator();
                var result = validator.Validate(studentdto);

                if (result.IsValid)
                {
                    var student = await studentRepo.GetByIdAsync(Id);

                    student.FirstName = studentdto.FirstName;
                    student.LastName = studentdto.LastName;
                    student.DateofBirth = studentdto.DateofBirth;
                    student.Email = studentdto.Email;
                    student.Phone = studentdto.Phone;




                    await studentRepo.Update(student);
                    return Ok(student);

                }
                else
                {
                    string resultstring = "";
                    foreach (var error in result.Errors)
                    {
                        resultstring += error;
                    }
                    throw new Exception(resultstring);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

       

        }

        [HttpDelete("DeleteStudent/{Id}")]
        public async Task<IActionResult> DeleteDeleteStudent(int Id)
        {
            var student = await studentRepo.GetByIdAsync(Id);

            await studentRepo.Delete(Id);

            return Ok(student);
        }

    }
}
