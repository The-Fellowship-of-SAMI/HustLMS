using LetterManagement.Shared.Models;

namespace LetterManagement.Server.Services
{
    public interface ILetterTemplateService : ICrud<LetterTemplate>
    {
        public Task<LetterTemplate> GetById(Guid letterId);
    }
}
