using LetterManagement.Server.Dtos;
using LetterManagement.Server.Services;
using Microsoft.AspNetCore.Mvc;

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
            return  Ok(await this._studentService.getAll());
        }
    }
}
