using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using LetterManagement.Server.Repositories;
using LetterManagement.Shared.Models;
using Microsoft.EntityFrameworkCore;
using StudentDto = LetterManagement.Server.Dtos.StudentDto;

namespace LetterManagement.Server.Services;

public class StudentService : IStudentService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public StudentService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<StudentDto>> getAll()
    {
        var students = await _context.Students.ToListAsync();
        return _mapper.Map<IEnumerable<StudentDto>>(students);
    }

    public async Task<StudentDto> create(StudentDto t)
    {
        var student = _mapper.Map<Student>(t);
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();

        return t;
    }

    public async Task<StudentDto> update(Guid id, StudentDto studentDto)
    {
        var inDatabaseStudent = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

        if (inDatabaseStudent == null) return null;

        var student = _mapper.Map<StudentDto,Student>(studentDto, inDatabaseStudent);
        var result = await this._context.SaveChangesAsync() > 0;

        if (!result) throw new BadHttpRequestException("Unable to save to database");
        return studentDto;
    }

    public Task<StudentDto> delete(StudentDto t)
    {
        throw new NotImplementedException();
    }
}