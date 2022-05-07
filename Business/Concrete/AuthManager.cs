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
        private IUserService _userService;
        private IUserAuthorityService _userAuthorityService;
        private ISecurityQuestionService _securityQuestionService;
        public AuthManager(IUserService userService, IUserAuthorityService userAuthorityService, ISecurityQuestionService securityQuestionService)
        {
            _userService = userService;
            _userAuthorityService = userAuthorityService;
            _securityQuestionService = securityQuestionService;
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
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Email = userForRegisterDto.Email,
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
            // burası düzeltilecek.
            var userExist = _userService.GetByMail(email);
            if (userExist == null)
            {
                return new ErrorResult(Messages.UserAlreadyExist);
            }
            return new SuccessResult();
        }

        public IDataResult<User> UserCheck(UserSecurityQuestionDto userSecurityQuestionDto, UserNewPasswordDto userNewPasswordDto)
        {
            var userToCheck = _userService.GetByMail(userSecurityQuestionDto.UserEmail).Data;
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            BusinessRules.Run(
                SecurityAnswer(userToCheck, userSecurityQuestionDto.SecurityQuestionAnswer),
                PasswordMatch(userNewPasswordDto));

            userToCheck.Password = userNewPasswordDto.Password;

            _userService.Update(userToCheck);

            return new SuccessDataResult<User>(userToCheck);
        }
        public IResult AddUserAuthority(UserAuthority userAuthority)
        {
            _userAuthorityService.Add(userAuthority);
            return new SuccessResult();
        }

        public IDataResult<string> GetAuthorities(UserAuthoritiesDto userAuthoritiesDto)
        {
            var result = "";
            if (userAuthoritiesDto.Authorities == null)
            {
                return new ErrorDataResult<string>();
            }
            foreach (var authority in userAuthoritiesDto.Authorities)
            {
                result += authority.AuthorityName +",";
            }
            return new SuccessDataResult<string>(result,Messages.AuthorityGeted);
        }

        public IDataResult<string> UserAuthorityRoute(string authorities)
        {
            if (authorities.Contains("Admin"))
            {
                return new SuccessDataResult<string>("~/AdminWebPage", Messages.AuthorityGeted);
            }
            return new ErrorDataResult<string>("~/WebPage", Messages.AuthorityGeted);
        }


        public IResult CheckUserAuthority(string authorities)
        {
            if (authorities.Contains("Admin"))
            {
                return new SuccessResult();
            }
            return new ErrorResult();
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

        
    }
}
