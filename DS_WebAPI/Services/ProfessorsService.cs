using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DS_WebAPI.Data;
using DS_WebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using SistemeTeShperndara.Models;

namespace DS_WebAPI.Services
{
    public class ProfessorsService : IProfessorsRepository<Professor>
    {
        private readonly AppDbContext _context;

        public ProfessorsService(AppDbContext context)
        {
            _context = context;
        }

        public Task<Professor> Add(Professor t)
        {
            throw new NotImplementedException();
        }

        public Task<Professor> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Professor>> GetAll()
        {
            return await _context.Professors.ToListAsync();
        }

        public Task<Professor> Remove(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Professor> Update(int id, Professor newT)
        {
            throw new NotImplementedException();
        }
    }
}
