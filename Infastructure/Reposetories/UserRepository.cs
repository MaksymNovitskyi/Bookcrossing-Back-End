﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.IRepositories;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infastructure.Reposetories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
       BookCrossingContext context_;

        public UserRepository(BookCrossingContext context) : base(context)
        {
            
        }
        public bool IsValidUser(User login)
        { 
            var loginResult= _context.Set<User>()
                .FirstOrDefault(u => u.Email == login.Email & u.Password == login.Password);
            return loginResult != null;
        }
    }
}
