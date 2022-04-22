using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, UserSecurityQuestionDto userSecurityQuestionDto);
        IResult UserExists(string email);
        IDataResult<UserAuthoritiesDto> GetUserAuthority(User user);
        IDataResult<User> UserCheck(UserSecurityQuestionDto userSecurityQuestionDto, UserNewPasswordDto userNewPasswordDto);
        IResult AddUserAuthority(UserAuthority userAuthority);
    }
}
