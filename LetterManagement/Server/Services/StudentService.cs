using AutoMapper;
using LetterManagement.Server.Dtos;
using LetterManagement.Server.Models;
using LetterManagement.Server.Repositories;
using Microsoft.EntityFrameworkCore;

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

    public async Task<IEnumerable<StudentDto>> get()
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

    public Task<StudentDto> update(StudentDto tOld, StudentDto tNew)
    {
        var studentOld = _mapper.Map<Student>(tOld);
        var studentNew = _mapper.Map<Student>(tNew);
        throw new NotImplementedException();
    }

    public Task<StudentDto> delete(StudentDto t)
    {
        throw new NotImplementedException();
    }
}