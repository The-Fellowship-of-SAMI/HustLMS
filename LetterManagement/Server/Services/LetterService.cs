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

    public async Task<IEnumerable<Letter>> GetAll()
    {
        return await this._context.Letters.
            Include(x => x.LetterAdditionalFields).
            Include(x=>x.Student).
            Include(x=>x.Managers).
            Include(x=>x.LetterAdditionalFields).
            Include(x=>x.Template).
            ThenInclude(x=>x!.Departments).
            AsSplitQuery().
            Include(x=>x.Departments).

            ToListAsync();
    }

    public async Task<Letter> Create(Letter letter)
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
        await using var transactionLetterDepartment = await _context.Database.BeginTransactionAsync();
        
        var departments = await _context.Departments.Where(x => letterDto.DepartmentsId.Contains(x.Id)).ToListAsync();

        try
        {
            var letter = new Letter()
            {
                Template = template,
                Student = student,
                LetterAdditionalFields = letterDto.LetterAdditionalFields,
                Departments = departments
            };
            foreach (var department in departments)
            {
                department.Letters.Add(letter);
            }
            await _context.Letters.AddAsync(letter);
            await _context.SaveChangesAsync();
            await transactionLetterDepartment.CommitAsync();
            return letter;
        }
        catch
        {
            // ignored
        }

        return new Letter();
    }

    public async Task<bool> UpdateLetterNoteDto(UpdateLetterNoteDto updateLetterNoteDto)
    {
        var letter = await this._context.Letters.SingleOrDefaultAsync(x => x.Id == updateLetterNoteDto.LetterId);
        if (letter is null) return false;
        letter.NoteToStudent = updateLetterNoteDto.NoteToStudent;
        await this._context.SaveChangesAsync();
        return true;
    }

    public Task<Letter> Update(Guid id, Letter tNew)
    {
        throw new NotImplementedException();
    }

    public async Task<Letter> Delete(Letter t)
    {
        this._context.Letters.Remove(t);
        await this._context.SaveChangesAsync();
        return t;
    }

    public async Task<string> GetState(Letter letter)
    {
        var let = await this._context.Letters.
            Include(x => x.State).
            SingleOrDefaultAsync(x => x.Id == letter.Id);
        if (let is null)
            return "Không rõ";
        return let.State;
    }

    public async Task<IEnumerable<Letter>> GetAllLettersByStudentId(int studentId)
    {
        var letters = await this._context.Letters.
            Where(x => x.Student!.StudentId == studentId).
            Include(x => x.LetterAdditionalFields).
            Include(x=>x.Managers).
            Include(x=>x.Template).
            ThenInclude(x=>x!.Departments).
            Include(x => x.Managers).
            AsSplitQuery().
            Include(x=>x.Departments).

            ToListAsync();
        return letters;
    }

    public async Task<IEnumerable<Letter>> GetAllLettersByManagerId(Guid managerId)
    {
        var manager = await this._context.Manager.SingleOrDefaultAsync(x => x.Id == managerId);
        if (manager is null) return new List<Letter>();
        var letters = await this._context.Letters.
            Where(x => x.Managers.Contains(manager)).
            Include(x => x.LetterAdditionalFields).
            Include(x=>x.Student).
            ThenInclude(x=>x!.School).
            Include(x=>x.Template).
            ThenInclude(x=>x!.Departments).
            AsSplitQuery().
            Include(x=>x.Departments).

            ToListAsync();
        return letters;
    }

    public async Task<IEnumerable<Letter>> GetAllLettersByDepartmentId(Guid departmentId)
    {
        var department = await this._context.Departments.SingleOrDefaultAsync(x => x.Id == departmentId);
        if (department is null)
        {
            return new List<Letter>();
        }
        var letters = await this._context.Letters.
            Where(x => x.Departments.Contains(department)).
            Include(x => x.LetterAdditionalFields).
            Include(x=>x.Student).
            ThenInclude(x=>x!.School).
            Include(x=>x.Template).
            ThenInclude(x=>x!.Departments).
            AsSplitQuery().
            Include(x=>x.Departments).

            ToListAsync();
        return letters;    
    }

    public async Task<Letter> GetLetter(Guid letterId)
    {
        var letter = await this._context.Letters.
            Include(x => x.LetterAdditionalFields).
            Include(x=>x.Student).
            ThenInclude(x=>x!.School).
            Include(x=>x.Template).
            ThenInclude(x=>x!.Departments).
            Include(x=>x.Template!.AdditionalFields).
            AsSplitQuery().
            Include(x=>x.Departments).
            SingleOrDefaultAsync(x => x.Id == letterId);
        if (letter is not null) return letter;
        return new Letter();
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
