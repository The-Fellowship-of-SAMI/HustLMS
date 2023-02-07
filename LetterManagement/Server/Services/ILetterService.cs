using LetterManagement.Server.Dtos;
using LetterManagement.Shared.Models;
namespace LetterManagement.Server.Services;

public interface ILetterService : ICrud<Letter>
{
    public Task<string> GetState(Letter letter);


    public Task<Letter> GetLetter(Guid letterId);

    public Task<IEnumerable<Letter>> GetAllLettersByStudentId(int studentId);

    public Task<IEnumerable<Letter>> GetAllLettersByManagerId(Guid managerId);

    public Task<IEnumerable<Letter>> GetAllLettersByDepartmentId(Guid departmentId);

    public Task<Letter?> CreateWithDto(CreateLetterDto letterDto);
}