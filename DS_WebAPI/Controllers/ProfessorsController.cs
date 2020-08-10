using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DS_WebAPI.Dtos;
using DS_WebAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemeTeShperndara.Models;

namespace DS_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfessorsController : ControllerBase
    {
        private readonly IProfessorsRepository<Professor> _context;
        private readonly IMapper _mapper;

        public ProfessorsController(IProfessorsRepository<Professor> context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet(Name = "GetProfessors")]
        public async Task<IActionResult> GetProfessorsAsync()
        {
            var professorItems = await _context.GetAll();
            return Ok(_mapper.Map<IEnumerable<ReadProfessorDto>>(professorItems));
        }
    }
}
