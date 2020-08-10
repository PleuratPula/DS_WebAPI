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
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectsRepository<Subject> _context;
        private readonly IMapper _mapper;

        public SubjectsController(ISubjectsRepository<Subject> context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet(Name = "GetSubjects")]
        public async Task<IActionResult> GetSubjectsAsync()
        {
            var subjectItems = await _context.GetAll();
            return Ok(_mapper.Map<IEnumerable<ReadSubjectDto>>(subjectItems));
        }
    }
}
