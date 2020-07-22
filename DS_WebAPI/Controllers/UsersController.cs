using System.Threading.Tasks;
using DS_WebAPI.ControllerModels.UserModels;
using DS_WebAPI.ErrorHandling;
using DS_WebAPI.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using SistemeTeShperndara.Models;

namespace DS_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public UsersController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(CreateUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new DataError("Model is not valid"));
            }

            var result = await userManager.CreateAsync(new User { UserName = model.Username }, model.Password);
            if (result.Succeeded)
            {
                return Ok(new
                {
                    Status = "Ok"
                });
            }
            else
            {
                // todo return result.errors
                return BadRequest(result.Errors);
            }
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate(AuthenticationModel model)
        {

            var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            if (result.Succeeded)
            {
                return SignIn(User, JwtBearerDefaults.AuthenticationScheme);
            } 
            else
            {
                return Unauthorized();
            }
        }
    }
}
