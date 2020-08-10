using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DS_WebAPI.Dtos;
using DS_WebAPI.ErrorHandling;
using DS_WebAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemeTeShperndara.Models;

namespace DS_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExamsController : ControllerBase
    {
        private readonly IExamsRepository<Exam> _context;
        private readonly IMapper _mapper;

        public ExamsController(IExamsRepository<Exam> context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetExams")]
        public async Task<IActionResult> GetExamsAsync()
        {
            var examItems = await _context.GetAll();
            return Ok(_mapper.Map<IEnumerable<ReadExamDto>>(examItems));
        }

        [HttpPost(Name = "AddExam")]
        public async Task<IActionResult> AddExamAsync(AddExamDto addExamDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var examModel = _mapper.Map<Exam>(addExamDto);
                    await _context.Add(examModel);

                    var readExamDto = _mapper.Map<ReadExamDto>(examModel);

                    return Ok("Provimi u regjistrua me sukses");
                }
                catch (Exception ex)
                {
                    return BadRequest(new DataError("Insetimi deshtoi " + ex.Message));
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
