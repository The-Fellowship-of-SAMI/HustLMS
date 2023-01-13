using LetterManagement.Server.Models;
using LetterManagement.Server.Repositories;
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
            Include(x=>x.Manager).
            Include(x=>x.Template).
            ToListAsync();
    }

    public async Task<Letter> create(Letter letter)
    {
        // Validate

        await _context.Letters.AddAsync(letter);

        var result = await _context.SaveChangesAsync() > 0;
        return  result ? letter : new Letter();
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

    public async Task<IEnumerable<Letter>> GetAllLetterByStudentId(int studentId)
    {
        var lettters = await this._context.Letters.
            Where(x => x.Student.StudentId == studentId).
            Include(x => x.LetterAdditionalFields).
            Include(x=>x.Student).
            Include(x=>x.Manager).
            Include(x=>x.Template).
            .ToListAsync();
        return lettters;
    }

    public async Task<IEnumerable<Letter>> GetAllLetterByManagerId(Guid managerId)
    {
        var lettters = await this._context.Letters.Where(x => x.Manager.Id == managerId).ToListAsync();
        return lettters;
    }

    public async Task<IEnumerable<Letter>> GetAllLetterByDepartmentId(Guid departmentId)
    {
        var lettters = await this._context.Letters.Where(x => x.Template.Department.Id == departmentId).ToListAsync();
        return lettters;    
    }
}