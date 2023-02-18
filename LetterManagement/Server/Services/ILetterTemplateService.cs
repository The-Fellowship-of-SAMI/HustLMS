using LetterManagement.Shared.Dtos;
using LetterManagement.Shared.Models;

namespace LetterManagement.Server.Services
{
    public interface ILetterTemplateService : ICrud<LetterTemplate>
    {
        public Task<LetterTemplate> GetById(Guid letterId);

        public Task CreateLetterTemplate(CreateLetterTemplateDto createLetterTemplateDto);
    }
}
