using Business.Abstract;
using Business.Concrete;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class AuthController : ApiController
    {
        IAuthService _authService;
        public AuthController()
        {
            _authService = new AuthManager();
        }

        [HttpPost]
        public User Register(UserForRegisterDto userForRegisterDto, UserSecurityQuestionDto userSecurityQuestionDto)
        {
           var result = _authService.Register(userForRegisterDto, userSecurityQuestionDto);
            if (result.Success)
            {
                return result.Data;
            }
            return null;
        }

        [HttpPost]
        public User Login(UserForLoginDto userForLoginDto)
        {
            var result = _authService.Login(userForLoginDto);
            if (result.Success)
            {
                return result.Data;
            }
            return null;
        }
    }
}