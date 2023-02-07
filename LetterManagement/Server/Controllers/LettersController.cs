using LetterManagement.Server.Dtos;
using LetterManagement.Server.Services;
using LetterManagement.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LetterManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LettersController : ControllerBase
    {
        private readonly ILetterService _letterService;

        public LettersController(ILetterService letterService)
        {
            this._letterService = letterService;
        }
        

        [HttpGet("{letterId}")]
        public Task<Letter> GetLetter(string letterId)
        {
            return this._letterService.GetLetter(new Guid(letterId));
        }

        [HttpGet("student/{studentId}")]
        public Task<IEnumerable<Letter>> GetAllLettersByStudentId(int studentId)
        {
            return this._letterService.GetAllLettersByStudentId(studentId);
        }


        [HttpGet("manager/{managerId}")]
        public Task<IEnumerable<Letter>> GetAllLettersByManagerId(string managerId)
        {
            return this._letterService.GetAllLettersByManagerId(new Guid(managerId));
        }


        [HttpGet("department/{departmentId}")]
        public Task<IEnumerable<Letter>> GetAllLettersByDepartmentId(string departmentId)
        {
            return this._letterService.GetAllLettersByDepartmentId(new Guid(departmentId));
        }

        [HttpPost]
        public async Task<ActionResult<Letter>> CreateLetterWithDto(CreateLetterDto letterDto)
        {
            var letter = await this._letterService.CreateWithDto(letterDto);

            if (letter is null) return BadRequest();

            return letter;
        }
    }
}
