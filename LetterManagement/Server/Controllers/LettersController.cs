using LetterManagement.Server.Models;
using LetterManagement.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LetterManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LettersController : ControllerBase
    {
        private readonly ILetterService letterService;

        public LettersController(ILetterService letterService)
        {
            this.letterService = letterService;
        }


        [HttpGet("{letterId}")]
        public Task<Letter> GetLetter(string letterId)
        {
            return this.letterService.GetLetter(new Guid(letterId));
        }

        [HttpGet("student/{studentId}")]
        public Task<IEnumerable<Letter>> GetAllLettersByStudentId(int studentId)
        {
            return this.letterService.GetAllLettersByStudentId(studentId);
        }


        [HttpGet("manager/{managerId}")]
        public Task<IEnumerable<Letter>> GetAllLettersByManagerId(string managerId)
        {
            return this.letterService.GetAllLettersByManagerId(new Guid(managerId));
        }


        [HttpGet("department/{departmentId}")]
        public Task<IEnumerable<Letter>> GetAllLettersByDepartmentId(string departmentId)
        {
            return this.letterService.GetAllLettersByDepartmentId(new Guid(departmentId));
        }
    }
}
