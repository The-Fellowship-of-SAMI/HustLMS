using LetterManagement.Shared.Models;
using StudentDto = LetterManagement.Server.Dtos.StudentDto;

namespace LetterManagement.Server.Services;

public interface IStudentService : ICrud<StudentDto>
{
    public Task<Student?> GetStudentById(Guid id);
}