using System.Linq.Expressions;
using DTos.StudentDto;
using DTos.StudentDTos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentGradingSystem.Application.Features.Course.Command.Create;
using StudentGradingSystem.Application.Features.Course.Query;
using StudentGradingSystem.Application.Features.Student.Command;
using StudentGradingSystem.Application.Features.Student.Command.Delete;
using StudentGradingSystem.Application.Features.Student.Command.Update;
using StudentGradingSystem.Application.Features.Student.Query;
using StudentGradingSystem.Application.Student.Command;


namespace StudentGradingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(CreateStudentCommandHandler createStudentCommandHandler,
        UpdateStudentCommandHandler updateStudentCommandHandler,
        DeleteStudentCommandHandler deleteStudentCommandHandler,
        GetAllStudentsQueryHandler getAllStudentQueryHandler,
        GetStudentQueryHandler getStudentQueryHandler) : ControllerBase
    {
        private readonly CreateStudentCommandHandler _createStudentCommandHandler = createStudentCommandHandler;
        private readonly UpdateStudentCommandHandler _updateStudentCommandHandler = updateStudentCommandHandler;
        private readonly DeleteStudentCommandHandler _deleteStudentCommandHandler = deleteStudentCommandHandler;
        private readonly GetAllStudentsQueryHandler _getAllStudentQueryHandler = getAllStudentQueryHandler;
        private readonly GetStudentQueryHandler _getStudentQueryHandler = getStudentQueryHandler;

        [HttpGet("getallstudents")]
        public async Task<IActionResult> GetAllStudents()
        {
            return Ok(await _getAllStudentQueryHandler.Handle());
        }


        [HttpGet("getstudentbyId/{Id}")]
        public async Task<IActionResult> GetStudents(int Id)
        {
            return Ok(await _getStudentQueryHandler.Handle(Id));
        }

   

        [HttpPost("createstudent")]
        public async Task<IActionResult> CreateStudent([FromBody]StudentDto studentdto)
        {
            var command = new CreateStudentCommand(studentdto.FirstName, studentdto.LastName, studentdto.DateofBirth, studentdto.Email, studentdto.Phone);
          return   Ok(await _createStudentCommandHandler.Handle(command));
    
        }

        [HttpPost("updatestudent")]
        public async Task<IActionResult> UpdateStudent([FromBody]UpdateStudentDto studentdto)
        {
            var command = new UpdateStudentCommand(studentdto.Id,studentdto.FirstName, studentdto.LastName, studentdto.DateofBirth, studentdto.Email, studentdto.Phone);
            return Ok(await _updateStudentCommandHandler.Handle(command));
        }

        [HttpDelete("deletestudent/{Id}")]
        public async Task<IActionResult> DeleteStudent(int Id)
        {
            
            return Ok(await _deleteStudentCommandHandler.Handle(Id));
        }

    }
}
