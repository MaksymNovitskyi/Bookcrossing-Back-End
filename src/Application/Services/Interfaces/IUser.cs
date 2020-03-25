﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using Domain.Entities;
namespace Application.Services.Interfaces
{
    public interface IUser
    {
        Task<UserDto> VerifyUserCredentials(LoginDto loginModel);
        Task<bool> Add(RegisterDto register);


    }
}
