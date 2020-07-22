using System.Threading.Tasks;
using DS_WebAPI.ControllerModels.UserModels;
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
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository<User> _context;

        public UsersController(IUsersRepository<User> context)
        {
            _context = context;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate(AuthenticationModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new DataError("Model is not valid"));
            }

            var user = await _context.Authorize(model);

            if (user != null)
                return Ok(user);
            else
                return NotFound();
        }
    }
}
