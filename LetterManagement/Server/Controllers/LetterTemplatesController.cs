using LetterManagement.Server.Services;
using LetterManagement.Shared.Dtos;
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
            return await this._letterTemplateService.GetAll();
        }

        // GET api/<LetterTemplatesController>/5
        [HttpGet("{id}")]
        public async Task<LetterTemplate> Get(string id)
        {
            return await this._letterTemplateService.GetById(new Guid(id));
        }

        // POST api/<LetterTemplatesController>
        [HttpPost]
        public async void Post([FromBody] CreateLetterTemplateDto template)
        {
             await this._letterTemplateService.CreateLetterTemplate(template);
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
