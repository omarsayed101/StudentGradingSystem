using System.Text;
using DTos.CourseDTos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentGradingSystem.Application.Features.Course.Command.Create;
using StudentGradingSystem.Application.Features.Course.Command.Delete;
using StudentGradingSystem.Application.Features.Course.Command.Update;
using StudentGradingSystem.Application.Features.Course.Query;
using StudentGradingSystem.Application.Interfaces;
using StudentGradingSystem.Application.Student.Command.DTos;

namespace StudentGradingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController( CreateCourseCommandHandler createCommandHandler ,
         UpdateCourseCommandHandler updateCommandHandler,
         DeleteCourseCommandHandler deleteCommandHandler,
         GetAllCoursesQueryHandler getAllCoursesQuery,
         GetCourseQueryHandler getCourseByIdQuery) : ControllerBase
    {
        private readonly CreateCourseCommandHandler _createCommandHandler = createCommandHandler;
        private readonly UpdateCourseCommandHandler _updateCommandHandler = updateCommandHandler;
        private readonly DeleteCourseCommandHandler _deleteCommandHandler = deleteCommandHandler;
        private readonly GetAllCoursesQueryHandler _getAllCoursesQuery = getAllCoursesQuery;
        private readonly GetCourseQueryHandler _getCourseByIdQuery = getCourseByIdQuery;

        [HttpGet("getallcourses")]
        public async Task<IActionResult> GetAllCourses()
        {
            return Ok(await _getAllCoursesQuery.Handle());
        }
        

        [HttpGet("getcoursesbyId/{Id}")]
        public async Task<IActionResult> GetCoursebyId(int Id) 
        {
            return Ok(await _getCourseByIdQuery.Handle(Id));
        }

        [HttpPost("createcourse")]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseDto coursedto)
        {
            var command = new CreateCommand(coursedto.Name);
           return Ok(await _createCommandHandler.Handle(command));
         
        }

        [HttpPost("updatecourse")]
        public async Task<IActionResult> UpdateCourse([FromBody] UpdateCourseDto coursedto)
        {
            var command = new UpdateCommand(coursedto.Id,coursedto.Name);
           return Ok(await _updateCommandHandler.Handle(command));

        }

        [HttpDelete("deletecourse/{Id}")]
        public async Task<IActionResult> DeleteCourse(int Id)
        {
            return Ok(await _deleteCommandHandler.Handle(Id));
        }
    }
}
