using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IAuthService //jwt için yekilere bakma 
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password); //sisteme kayıt olanilmeli
        IDataResult<User> Login(UserForLoginDto userForLoginDto);  //giriş yapabilmeli
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
