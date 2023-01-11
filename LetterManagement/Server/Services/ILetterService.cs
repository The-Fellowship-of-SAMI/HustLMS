using LetterManagement.Server.Models;

namespace LetterManagement.Server.Services;

public interface ILetterService : ICrud<Letter>
{
    public Task<string> GetState(Letter letter);

    public Task<IEnumerable<Letter>> GetAllLetterByStudentId(int studentId);

    public Task<IEnumerable<Letter>> GetAllLetterByManagerId(Guid managerId);

    public Task<IEnumerable<Letter>> GetAllLetterByDepartmentId(Guid departmentId);
}