using LetterManagement.Server.Dtos;
using LetterManagement.Shared.Models;

using LetterManagement.Server.Repositories;
using LetterManagement.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace LetterManagement.Server.Services;

public class LetterService : ILetterService
{
    private readonly DataContext _context;

    public LetterService(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Letter>> getAll()
    {
        return await this._context.Letters.
            Include(x => x.LetterAdditionalFields).
            Include(x=>x.Student).
            Include(x=>x.Template).
            ThenInclude(x=>x.AdditionalFields).
            AsSplitQuery().
            Include(x=>x.Manager).
            ThenInclude(x=>x.Department).
            ToListAsync();
    }

    public async Task<Letter> create(Letter letter)
    {
        // Validate

        await _context.Letters.AddAsync(letter);

        var result = await _context.SaveChangesAsync() > 0;
        return  result ? letter : new Letter();
    }

    public async Task<Letter?> CreateWithDto(CreateLetterDto letterDto)
    {
        var student = await _context.Students.SingleOrDefaultAsync(x => x.StudentId == letterDto.StudentId);
        if (letterDto.LetterTemplateId is null)
        {
            return null;
        }
        var template =
            await _context.LetterTemplates.SingleOrDefaultAsync(x => x.Id == new Guid(letterDto.LetterTemplateId));
        var letter = new Letter()
        {
            Template = template,
            Student = student,
            LetterAdditionalFields = letterDto.LetterAdditionalFields
        };
        Console.WriteLine(letterDto.LetterAdditionalFields[0]);
        await this._context.Letters.AddAsync(letter);
        var result = await _context.SaveChangesAsync() > 0;
        return result ? letter : null;
    }

    public async Task<bool> UpdateLetterNoteDto(UpdateLetterNoteDto updateLetterNoteDto)
    {
        var letter = await this._context.Letters.SingleOrDefaultAsync(x => x.Id == updateLetterNoteDto.LetterId);
        if (letter is null) return false;
        letter.NoteToStudent = updateLetterNoteDto.NoteToStudent;
        await this._context.SaveChangesAsync();
        return true;
    }

    public async Task<Letter> update(Guid id, Letter tNew)
    {
        throw new NotImplementedException();
    }

    public async Task<Letter> delete(Letter t)
    {
        this._context.Letters.Remove(t);
        await this._context.SaveChangesAsync();
        return t;
    }

    public async Task<string> GetState(Letter letter)
    {
        var let = await this._context.Letters.Include(x => x.State).SingleOrDefaultAsync(x => x.Id == letter.Id);
        return let.State;
    }

    public async Task<IEnumerable<Letter>> GetAllLettersByStudentId(int studentId)
    {
        var letters = await this._context.Letters.
            Where(x => x.Student.StudentId == studentId).
            Include(x => x.LetterAdditionalFields).
            Include(x=>x.Manager).
            Include(x=>x.Template).
            Include(x => x.Manager.Department).
            AsSplitQuery().
            ToListAsync();
        return letters;
    }

    public async Task<IEnumerable<Letter>> GetAllLettersByManagerId(Guid managerId)
    {
        var letters = await this._context.Letters.
            Where(x => x.Manager.Id == managerId).
            Include(x => x.LetterAdditionalFields).
            Include(x=>x.Student).
            Include(x=>x.Template).
            AsSplitQuery().
            Include(x=>x.Student.School).
            Include(x => x.Manager.Department).
            ToListAsync();
        return letters;
    }

    public async Task<IEnumerable<Letter>> GetAllLettersByDepartmentId(Guid departmentId)
    {
        var letters = await this._context.Letters.
            Where(x => x.Template.Department.Id == departmentId).
            Include(x => x.LetterAdditionalFields).
            Include(x=>x.Student).
            Include(x=>x.Manager).
            Include(x=>x.Template).
            AsSplitQuery().
            ToListAsync();
        return letters;    
    }

    public async Task<Letter> GetLetter(Guid letterId)
    {
        var letter = await this._context.Letters.
            Include(x => x.LetterAdditionalFields).
            AsSplitQuery().
            Include(x=>x.Student).
            Include(x => x.Manager).
            Include(x => x.Template).
            AsSplitQuery().
            Include(x => x.Student.School).
            AsSplitQuery().Include(x=>x.Template.AdditionalFields).
            SingleOrDefaultAsync(x => x.Id == letterId);
        if (letter is not null) return letter;
        return null;
    }

    public async Task<bool> UpdateLetterState(LetterStateDto letterStateDto)
    {
        var letter = await this._context.Letters.SingleOrDefaultAsync(x => x.Id == letterStateDto.LetterId);
        if (letter is null) return false;
        letter.ReceivedDate = letterStateDto.ReceivedDate;
        letter.FinishedDate = letterStateDto.FinishedDate;

        await this._context.SaveChangesAsync();
        return true;
    }
}
