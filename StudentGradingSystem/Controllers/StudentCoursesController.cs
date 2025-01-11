using DTos.StudentCoursesDTos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentGradingSystem.Application.Features.StudnetCourses.Command.Create;
using StudentGradingSystem.Application.Features.StudnetCourses.Query;

namespace StudentGradingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCoursesController(StudnetCoursesCreateCommandHandler studnetCoursesCreateCommandhandler,
        GetHieghestGradesQueryHandler getHieghestGradesQueryHandler,
        GetHiestgradesInEachCourseQueryHandler getHiestgradesInEachCourseQueryHandler) : ControllerBase
    {
        private readonly StudnetCoursesCreateCommandHandler _studnetCoursesCreateCommandhandler = studnetCoursesCreateCommandhandler;
        private readonly GetHieghestGradesQueryHandler _getHieghestGradesQueryHandler = getHieghestGradesQueryHandler;
        private readonly GetHiestgradesInEachCourseQueryHandler _getHiestgradesInEachCourseQueryHandler = getHiestgradesInEachCourseQueryHandler;

        [HttpPost("create studnet  courses")]
        public async Task<IActionResult> CreateStudnetCourse([FromBody]CreateStudnetCoursesDto createStudnetCoursesDto)
        {
            var command = new StudnetCoursesCreateCommand(createStudnetCoursesDto.StudentId, createStudnetCoursesDto.CourseId, createStudnetCoursesDto.Grade);

            return Ok(await _studnetCoursesCreateCommandhandler.Handle(command));
        }

        [HttpGet("gethieghestgrades")]

        public async Task<IActionResult> GethieghstGrades()
        {
            return Ok(await _getHieghestGradesQueryHandler.Handle());
        }

        [HttpGet("gethieghestgradesPerCourse/{Id}")]

        public async Task<IActionResult> GethieghstGradesPerCourse(int Id)
        {
            return Ok(await _getHiestgradesInEachCourseQueryHandler.Handle(Id));
        }
    }

}
