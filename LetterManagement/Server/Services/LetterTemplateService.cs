using LetterManagement.Shared.Models;

using LetterManagement.Server.Repositories;
using LetterManagement.Shared.Dtos;
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

        public async Task<IEnumerable<LetterTemplate>> GetAll()
        {
            return await this._context.LetterTemplates.
                Include(x=>x.AdditionalFields).
                Include(x=>x.Departments).
                Include(x => x.ConfirmationsTemplate).
                AsSplitQuery().
                ToListAsync();
        }

        public async Task<LetterTemplate> GetById(Guid letterId)
        {
            var emptyLetterTemplate = new LetterTemplate();

            var letterTemplate = await this._context.LetterTemplates.
                Include(x=>x.AdditionalFields).
                Include(x=>x.Departments).
                Include(x=>x.ConfirmationsTemplate).
                AsSplitQuery().
                SingleOrDefaultAsync(x => x.Id == letterId);
            if (letterTemplate is not null) return letterTemplate;
            return emptyLetterTemplate;
        }

        public async Task CreateLetterTemplate(CreateLetterTemplateDto createLetterTemplateDto)
        {
            var departmentGuid = createLetterTemplateDto.DepartmentIds.Select(x => Guid.Parse(x));
            var departments =
                    await this._context.Departments.Where(x => departmentGuid.Contains(x.Id)).ToListAsync();
            var letterTemplate = new LetterTemplate()
            {
                AdditionalFields = createLetterTemplateDto.AdditionalFields,
                Departments = departments,
                Receiver = createLetterTemplateDto.Receiver,
                CreatedAt = createLetterTemplateDto.CreatedAt,
                Description = createLetterTemplateDto.Description,
                Name = createLetterTemplateDto.Name,
                Footer = createLetterTemplateDto.Footer,
            };
            this._context.LetterTemplates.Add(letterTemplate);
            await this._context.SaveChangesAsync();
        }

        public async Task<LetterTemplate> Create(LetterTemplate letterTemplate)
        {
            try
            {
                await this._context.LetterTemplates.AddAsync(letterTemplate);
                var result = await this._context.SaveChangesAsync() > 0;

                if (!result) throw new Exception("Unable to save to database");

                return letterTemplate;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new LetterTemplate();
            }
        }
        public async Task<LetterTemplate> Update(Guid id, LetterTemplate letterTemplate)
        {

            this._context.LetterTemplates.Update(letterTemplate);
            await this._context.SaveChangesAsync();
            return letterTemplate;
        }

        public async Task<LetterTemplate> Delete(LetterTemplate t)
        {
            throw new NotImplementedException();
        }
    }
}
