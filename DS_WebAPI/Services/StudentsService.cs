using System.Collections.Generic;
using System.Threading.Tasks;
using DS_WebAPI.Data;
using DS_WebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using SistemeTeShperndara.Models;

namespace DS_WebAPI.Services
{
    public class StudentsService : IStudentsRepository<Student>
    {
        private readonly AppDbContext _context;

        public StudentsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Student> Get(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _context.Students.ToListAsync();
        }

        public Task<Student> Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Student> Update(Student newT)
        {
            throw new System.NotImplementedException();
        }
    }
}
