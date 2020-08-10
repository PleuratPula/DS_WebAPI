using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DS_WebAPI.Data;
using DS_WebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using SistemeTeShperndara.Models;

namespace DS_WebAPI.Services
{
    public class SubjectsService : ISubjectsRepository<Subject>
    {
        private readonly AppDbContext _context;

        public SubjectsService(AppDbContext context)
        {
            _context = context;
        }

        public Task<Subject> Add(Subject t)
        {
            throw new NotImplementedException();
        }

        public Task<Subject> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Subject>> GetAll()
        {
            return await _context.Subjects.ToListAsync();
        }

        public Task<Subject> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Subject> Update(int id, Subject newT)
        {
            throw new NotImplementedException();
        }
    }
}
