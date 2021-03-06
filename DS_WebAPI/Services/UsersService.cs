﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DS_WebAPI.ControllerModels.UserModels;
using DS_WebAPI.Data;
using DS_WebAPI.Interfaces;
using DS_WebAPI.SharedResources;
using Microsoft.EntityFrameworkCore;
using SistemeTeShperndara.Models;

namespace DS_WebAPI.Services
{
    public class UsersService : IUsersRepository<User>
    {
        private readonly AppDbContext _context;

        public UsersService(AppDbContext context)
        {
            _context = context;
        }

        public Task<User> Add(User t)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> Authorize(AuthenticationModel model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == model.Username && x.Password == model.Password);

            if (user != null)
            {
                user.Token = TokenProvider.GenerateToken(user.Username, user.Id.ToString());
                user.LastLogin = DateTime.UtcNow;
                _context.Entry(await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id)).CurrentValues.SetValues(user);
                await _context.SaveChangesAsync();
                return user;
            }
            else
            {
                return null;
            }
        }

        #region
        //public async Task<User> Authorize(AuthenticationModel model)
        //{
        //    var result = await signInManager.PasswordSignInAsync(model.Username, model.Password);


        //    var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == model.Username && x.Password == model.Password);

        //    if (user != null)
        //    {
        //        // Generate Token
        //        user.Token = TokenProvider.GenerateToken(user.Username, user.Id.ToString());
        //        return user;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        #endregion

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

        public Task<User> Update(int id, User newT)
        {
            throw new System.NotImplementedException();
        }
    }
}
