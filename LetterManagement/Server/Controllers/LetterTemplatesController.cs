using LetterManagement.Server.Services;
using LetterManagement.Shared.Models;

using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LetterManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LetterTemplatesController : ControllerBase
    {
        private readonly ILetterTemplateService _letterTemplateService;

        public LetterTemplatesController(ILetterTemplateService letterTemplateService)
        {
            _letterTemplateService = letterTemplateService;
        }
        // GET: api/<LetterTemplatesController>
        [HttpGet]
        public async Task<IEnumerable<LetterTemplate>> Get()
        {
            return await this._letterTemplateService.getAll();
        }

        // GET api/<LetterTemplatesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LetterTemplatesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LetterTemplatesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LetterTemplatesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
