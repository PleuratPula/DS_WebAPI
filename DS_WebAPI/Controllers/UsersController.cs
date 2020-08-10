using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DS_WebAPI.ControllerModels.UserModels;
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
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository<User> _context;
        private readonly IMapper _mapper;

        //private readonly UserManager<User> userManager;
        //private readonly SignInManager<User> signInManager;

        public UsersController(IUsersRepository<User> context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            //this.signInManager = signInManager;
            //this.userManager = userManager;
        }

        [HttpGet("me")]
        public IActionResult CurrentUser()
        {
            var claims = User.Claims.ToDictionary(c => c.Type, c => c.Value);
            return Ok(claims);
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
                return Ok(_mapper.Map<ReadUserDto>(user));
            else
                return NotFound();
        }

        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<IActionResult> Create(CreateUserModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(new DataError("Model is not valid"));
        //    }

        //    var result = await userManager.CreateAsync(new User { UserName = model.Username }, model.Password);
        //    if (result.Succeeded)
        //    {
        //        return Ok(new
        //        {
        //            Status = "Ok"
        //        });
        //    }
        //    else
        //    {
        //        // todo return result.errors
        //        return BadRequest(result.Errors);
        //    }
        //}

        //[HttpPost("authenticate")]
        //[AllowAnonymous]
        //public async Task<IActionResult> Authenticate(AuthenticationModel model)
        //{
        //    var user = await userManager.FindByNameAsync(model.Username);
        //    if (user == null)
        //    {
        //        return Unauthorized();
        //    }

        //    var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
        //    await signInManager.SignInAsync(user, false);

        //    //var result = await signInManager.(model.Username, model.Password, false, false);
        //    if (result.Succeeded)
        //    {
        //        return Ok(new
        //        {
        //            token = TokenProvider.GenerateToken(user.UserName, user.Id)
        //        });
        //    }
        //    else
        //    {
        //        return Unauthorized();
        //    }
        //}
    }
}
