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
        return await this._context.Letters.Include(x => x.LetterAdditionalFields).ToListAsync();
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
        throw new NotImplementedException();
    }

    public async Task<string> GetState(Letter letter)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Letter>> GetAllLetterByStudentId(int studentId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Letter>> GetAllLetterByManagerId(Guid managerId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Letter>> GetAllLetterByDepartmentId(Guid departmentId)
    {
        throw new NotImplementedException();
    }
}