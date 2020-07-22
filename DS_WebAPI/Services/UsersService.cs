using System.Collections.Generic;
using System.Threading.Tasks;
using DS_WebAPI.ControllerModels.UserModels;
using DS_WebAPI.Data;
using DS_WebAPI.Interfaces;
using DS_WebAPI.SharedResources;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SistemeTeShperndara.Models;

namespace DS_WebAPI.Services
{
    public class UsersService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public UsersService(AppDbContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        // public async Task<User> Authorize(AuthenticationModel model)
        // {
        //     var result = await signInManager.PasswordSignInAsync(model.Username, model.Password);
        // 
        // 
        //     var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == model.Username && x.Password == model.Password);
        // 
        //     if (user != null)
        //     {
        //         // Generate Token
        //         user.Token = TokenProvider.GenerateToken(user.Username, user.Id.ToString());
        //         return user;
        //     }
        //     else
        //     {
        //         return null;
        //     }
        // }

        public Task<User> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<User> Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> Update(User newT)
        {
            throw new System.NotImplementedException();
        }
    }
}
