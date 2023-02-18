using LetterManagement.Server.Repositories;
using LetterManagement.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace LetterManagement.Server.Services
{
    public class DepartmentService :IDepartmentService
    {
        private readonly DataContext _context;

        public DepartmentService(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Department>> GetAll()
        {
            return await this._context.Departments.ToListAsync();
        }

        public Task<Department> Create(Department tDto)
        {
            throw new NotImplementedException();
        }

        public Task<Department> Update(Guid id, Department tNew)
        {
            throw new NotImplementedException();
        }

        public Task<Department> Delete(Department t)
        {
            throw new NotImplementedException();
        }
    }
}
