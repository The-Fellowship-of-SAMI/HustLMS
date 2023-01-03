using AutoMapper;
using LetterManagement.Server.Dtos;
using LetterManagement.Server.Models;

namespace LetterManagement.Server.MapperProfiles;


public class StudentProfile : Profile
{
    protected StudentProfile()
    {
        CreateMap<Student, StudentDto>();
        CreateMap<StudentDto, Student>();
    }
}