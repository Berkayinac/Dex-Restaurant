using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Entities.Concrete;
using Core.Utilities.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
           var result = ValidationTool.Validate(new UserValidator(), user);

           if (!result.Success)
           {
                return new ErrorResult(result.Message);
           }

            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.GetAll();
            if (result == null)
            {
                return new ErrorDataResult<List<User>>();
            }
            return new SuccessDataResult<List<User>>(result, Messages.UsersListed);
        }

        public IDataResult<List<AuthorityDto>> GetAuthorities(User user)
        {
            var result = _userDal.GetAuthorities(user);
            if (result == null)
            {
                return new ErrorDataResult<List<AuthorityDto>>();
            }
            return new SuccessDataResult<List<AuthorityDto>>(result, Messages.AuthoritiesListed);
        }

        public IDataResult<User> GetById(int userId)
        {
            var result = _userDal.Get(u => u.Id == userId);
            if (result == null)
            {
                return new ErrorDataResult<User>(result);
            }
            return new SuccessDataResult<User>(result,Messages.UserGeted);
        }

        public IDataResult<User> GetByMail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);
            if (result == null)
            {
                return new ErrorDataResult<User>();
            }
            return new SuccessDataResult<User>(result, Messages.UserGeted);
        }

        public IDataResult<UserSecurityQuestionDto> GetUserSecurityQuestion(string email)
        {
            var user = GetByMail(email).Data;
            var result = _userDal.GetUserSecurityQuestion(user);
            if (result == null)
            {
                return new ErrorDataResult<UserSecurityQuestionDto>();
            }
            return new SuccessDataResult<UserSecurityQuestionDto>(result);
        }

        public IResult Update(User user)
        {
            var result = ValidationTool.Validate(new UserValidator(), user);

            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}