using AutoMapper;
using LetterManagement.Shared.Models;

using LetterManagement.Server.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LetterManagement.Server.Services
{
    public class LetterTemplateService : ILetterTemplateService
    {
        private readonly DataContext _context;

        public LetterTemplateService(DataContext  context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LetterTemplate>> getAll()
        {
            return await this._context.LetterTemplates.
                Include(x=>x.AdditionalFields).
                Include(x=>x.Department).
                Include(x => x.ConfirmationsTemplate).
                ToListAsync();
        }

        public async Task<LetterTemplate> GetById(Guid letterId)
        {
            var emptyLetterTemplate = new LetterTemplate();

            var letterTemplate = await this._context.LetterTemplates.
                Include(x=>x.AdditionalFields).
                Include(x=>x.Department).
                Include(x=>x.ConfirmationsTemplate).
                SingleOrDefaultAsync(x => x.Id == letterId);
            if (letterTemplate is not null) return letterTemplate;
            return emptyLetterTemplate;
        }
        public async Task<LetterTemplate> create(LetterTemplate letterTemplate)
        {
            await this._context.LetterTemplates.AddAsync(letterTemplate);
            var result = await this._context.SaveChangesAsync() > 0;

            if (!result) throw new BadHttpRequestException("Unable to save to database");

            return letterTemplate;
        }

        public async Task<LetterTemplate> update(Guid id, LetterTemplate letterTemplate)
        {

            this._context.LetterTemplates.Update(letterTemplate);
            await this._context.SaveChangesAsync();
            return letterTemplate;
        }

        public async Task<LetterTemplate> delete(LetterTemplate t)
        {
            throw new NotImplementedException();
        }
    }
}
