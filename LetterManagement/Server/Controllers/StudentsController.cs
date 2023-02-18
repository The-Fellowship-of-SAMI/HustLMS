using LetterManagement.Server.Services;
using LetterManagement.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using StudentDto = LetterManagement.Server.Dtos.StudentDto;

namespace LetterManagement.Server.Controllers
{

    [ApiController]
    [Route("api/{controller}")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetAll()
        {
            return  Ok(await this._studentService.GetAll());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(string id)
        {
            var student = await this._studentService.GetStudentById(new Guid(id));
            if (student is not null) return Ok(student);
            return NotFound();
        }
    }
}
