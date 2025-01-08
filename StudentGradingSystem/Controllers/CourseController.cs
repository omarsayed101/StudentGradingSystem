using System.Text;
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
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository courseRepo;

        public CourseController(ICourseRepository courseRepo)
        {
            this.courseRepo = courseRepo;
        }

        [HttpGet("GetAllCourses")]
        public async Task<IActionResult> GetAllCourses()
        {
            return Ok(courseRepo.GetAllAsync());
        }

        [HttpPost("CreateCourse")]
        public async Task<IActionResult> CreateCourse([FromBody] CourseDto coursedto)
        {
            try
            {
                var validator = new CourseValidator();
               var result = validator.Validate(coursedto);

                if (result.IsValid)
                {
                    var Course = new Course()
                    {
                        Name = coursedto.Name,

                    };
                    await courseRepo.Add(Course);

                    return Ok(Course);
                }
                else
                {
                    string returnedstring = "";
                    foreach (var error in result.Errors)
                    {
                        returnedstring += error;
                    }
                    throw new Exception(returnedstring);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
          
         
        }

        [HttpPost("UpdateCourse/{Id}")]
        public async Task<IActionResult> UpdateStudent([FromBody] CourseDto coursedto, int Id)
        {
            try
            {
                var validator = new CourseValidator();
                var result = validator.Validate(coursedto);

                if (result.IsValid)
                {
                    var course = await courseRepo.GetByIdAsync(Id);

                    course.Name = coursedto.Name;

                    await courseRepo.Update(course);
                    return Ok(course);
                }
                else
                {
                    string returnedstring = "";
                    foreach (var error in result.Errors)
                    {
                        returnedstring += error;
                    }
                    throw new Exception(returnedstring);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        

        }

        [HttpDelete("DeleteCourse/{Id}")]
        public async Task<IActionResult> DeleteDeleteStudent(int Id)
        {
            var Course = await courseRepo.GetByIdAsync(Id);

            await courseRepo.Delete(Id);

            return Ok(Course);
        }
    }
}
