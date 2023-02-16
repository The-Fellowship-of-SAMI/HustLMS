using LetterManagement.Server.Dtos;
using LetterManagement.Server.Services;
using LetterManagement.Shared.Dtos;
using LetterManagement.Shared.Models;
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
        public async Task<IEnumerable<Letter>> GetAllLettersByManagerId(string managerId)
        {
            var letters = await this._letterService.GetAllLettersByManagerId(new Guid(managerId));

            // SortTools
            // SortTools.SortList(sortQueryString, letters.ToList());
            return letters;
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

        [HttpPut("noteToStudent")]
        public async Task<ActionResult<bool>> UpdateNoteToStudent([FromBody] UpdateLetterNoteDto letterNoteDto)
        {
            var updateResult = await this._letterService.UpdateLetterNoteDto(letterNoteDto);
            if (updateResult) return Ok(updateResult);
            else return NotFound(updateResult);
        }

        [HttpPut("state")]
        public async Task<ActionResult> UpdateState([FromBody] LetterStateDto letterStateDto)
        {
            var updateResult = await this._letterService.UpdateLetterState(letterStateDto);
            if (updateResult) return Ok(updateResult);
            else return NotFound(updateResult);
        }
    }
}
