using AutoMapper;
using LetterManagement.Shared.Models;
using StudentDto = LetterManagement.Server.Dtos.StudentDto;

namespace LetterManagement.Server.MapperProfiles;


public class StudentProfile : Profile
{
    public StudentProfile()
    {
        CreateMap<Student, StudentDto>();
        CreateMap<StudentDto, Student>();
    }
}