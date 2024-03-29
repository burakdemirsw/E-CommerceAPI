﻿using GoogleAPI.Domain.Entities.User;
using GoogleAPI.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooleAPI.Application.Abstractions.IServices.IAuthentication
{
    public interface ITokenService
    {
        Task<Token> CreatePasswordResetToken(int minute, User user);

        Task<Token> CreateAccsessToken(int minute, User user);
        Task<string> CreateRefreshToken( );
     
    }
}
