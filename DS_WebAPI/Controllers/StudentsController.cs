using DS_WebAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SistemeTeShperndara.Models;

namespace DS_WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsRepository<Student> _context;

        public StudentsController(IStudentsRepository<Student> context)
        {
            _context = context;
        }
    }
}
