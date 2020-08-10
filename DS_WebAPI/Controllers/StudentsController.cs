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
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsRepository<Student> _context;
        private readonly IMapper _mapper;

        public StudentsController(IStudentsRepository<Student> context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet(Name = "GetStudents")]
        public async Task<IActionResult> GetStudentsAsync()
        {
            //return await _context.GetAll();
            var studentItems = await _context.GetAll();
            return Ok(_mapper.Map<IEnumerable<ReadStudentDto>>(studentItems));
        }

        [HttpGet("{id:int}", Name = "GetSingleStudentAsync")]
        public async Task<IActionResult> GetSingleStudentAsync([FromRoute] int id)
        {
            var item = await _context.Get(id);
            if (item == null)
                return NotFound(new DataError("Student not found"));

            return Ok(_mapper.Map<ReadStudentDto>(item));
        }

        [HttpPost("Add", Name = "AddStudent")]
        public async Task<IActionResult> AddStudentAsync(AddStudentDto addStudentDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var studentModel = _mapper.Map<Student>(addStudentDto);
                    await _context.Add(studentModel);

                    var readStudentDto = _mapper.Map<ReadStudentDto>(studentModel);

                    return Ok("Studenti eshte regjistruar me sukses!");
                }
                catch (Exception ex)
                {
                    return BadRequest(new DataError("Regjistrimi deshtoi " + ex.Message));
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id:int}", Name = "UpdateStudent")]
        public async Task<IActionResult> UpdateStudentAsync(int id, Student student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(id, student);
                    return Ok("Studenti eshte edituar me sukses!");
                }
                catch (Exception ex)
                {
                    return BadRequest(new DataError("Editimi deshtoi " + ex.Message));
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id:int}", Name = "DeleteStudent")]
        public async Task<IActionResult> DeleteStudentAsync([FromRoute] int id)
        {
            try
            {
                var student = await _context.Get(id);

                student.Exams.Clear();

                await _context.Remove(id);

                return Ok("Studenti eshte fshire me sukses!");
            }
            catch (Exception ex)
            {
                return BadRequest(new DataError("Fshirja deshtoi " + ex.Message));
            }

        }
    }
}
