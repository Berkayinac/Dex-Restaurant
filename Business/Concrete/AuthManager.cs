using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        IUserAuthorityService _userAuthorityService;
        ISecurityQuestionService _securityQuestionService;

        public AuthManager()
        {
            _userService = new UserManager();
            _userAuthorityService = new UserAuthorityManager();
            _securityQuestionService = new SecurityQuestionManager();
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email).Data;
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (userToCheck.Password != userForLoginDto.Password)
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);

        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, UserSecurityQuestionDto userSecurityQuestionDto)
        {
            var userToCheck = _userService.GetByMail(userForRegisterDto.Email).Data;
            if (userToCheck != null)
            {
                return new ErrorDataResult<User>(Messages.UserAlreadyExist);
            }

            var question = _securityQuestionService.GetByQuestion(userSecurityQuestionDto.SecurityQuestion).Data;


            User user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Password = userForRegisterDto.Password,
                SecurityQuestionId = question.Id,
                SecurityQuestionAnswer = userSecurityQuestionDto.SecurityQuestionAnswer,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.SuccessfulRegister);
        }


        public IDataResult<UserAuthoritiesDto> GetUserAuthority(User user)
        {
            var authorities = _userService.GetAuthorities(user).Data;
            if (authorities == null)
            {
                return new ErrorDataResult<UserAuthoritiesDto>();
            }

            var result = _userAuthorityService.GetUserAndUserAuthorities(user, authorities);

            if (!result.Success)
            {
                return new ErrorDataResult<UserAuthoritiesDto>();
            }

            return new SuccessDataResult<UserAuthoritiesDto>(result.Data);
        }

        public IResult UserExists(string email)
        {
            var userExist = _userService.GetByMail(email);
            if (userExist == null)
            {
                return new ErrorResult(Messages.UserAlreadyExist);
            }
            return new SuccessResult();
        }

        public IDataResult<User> UserCheck(string email, UserSecurityQuestionDto userSecurityQuestionDto, UserNewPasswordDto userNewPasswordDto)
        {
            var userToCheck = _userService.GetByMail(email).Data;
            if (userToCheck != null)
            {
                return new ErrorDataResult<User>(Messages.UserAlreadyExist);
            }

            BusinessRules.Run(
                SecurityAnswer(userToCheck, userSecurityQuestionDto.SecurityQuestionAnswer),
                PasswordMatch(userNewPasswordDto));

            userToCheck.Password = userNewPasswordDto.Password;

            return new SuccessDataResult<User>(userToCheck);
        }

        private IResult SecurityAnswer(User user, string securityAnswer)
        {
            if (user.SecurityQuestionAnswer != securityAnswer)
            {
                return new ErrorResult(Messages.SecurityQuestionAnswerNotMatch);
            }
            return new SuccessResult();
        }

        private IResult PasswordMatch(UserNewPasswordDto userNewPasswordDto)
        {
            if (userNewPasswordDto.Password != userNewPasswordDto.PasswordVerify)
            {
                return new ErrorResult(Messages.PasswordError);
            }
            return new SuccessResult();
        }

        public IResult AddUserAuthority(UserAuthority userAuthority)
        {
            _userAuthorityService.Add(userAuthority);
            return new SuccessResult();
        }
    }
}
