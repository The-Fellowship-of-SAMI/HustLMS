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
        public async Task<ActionResult<IEnumerable<StudentDto>>> Get()
        {
            return  Ok(await this._studentService.get());
        }
    }
}
