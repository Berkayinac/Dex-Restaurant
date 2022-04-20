using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
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
    public class UserAuthorityManager : IUserAuthorityService
    {
        private IUserAuthorityDal _userAuthorityDal;
        public UserAuthorityManager()
        {
            _userAuthorityDal = new EfUserAuthorityDal();
        }

        public IResult Add(UserAuthority userAuthority)
        {
            _userAuthorityDal.Add(userAuthority);
            return new SuccessResult(Messages.UserAuthorityAdded);
        }

        public IResult Delete(UserAuthority userAuthority)
        {
            _userAuthorityDal.Delete(userAuthority);
            return new SuccessResult(Messages.UserAuthorityDeleted);
        }

        public IDataResult<List<UserAuthority>> GetAll()
        {
            var result = _userAuthorityDal.GetAll();
            if (result == null)
            {
                return new ErrorDataResult<List<UserAuthority>>();
            }
            return new SuccessDataResult<List<UserAuthority>>(result, Messages.UserAuthoritiesListed);
        }

        public IDataResult<UserAuthority> GetById(int id)
        {
            var result = _userAuthorityDal.Get(c => c.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<UserAuthority>();
            }
            return new SuccessDataResult<UserAuthority>(result, Messages.UserAuthorityGeted);
        }

        public IDataResult<UserAuthoritiesDto> GetUserAndUserAuthorities(User user, List<AuthorityDto> authorities)
        {
            UserAuthoritiesDto userAuthoritiesDto = new UserAuthoritiesDto();
            userAuthoritiesDto.User = user;
            userAuthoritiesDto.Authorities = authorities;

            if (userAuthoritiesDto.User == null || userAuthoritiesDto.Authorities == null)
            {
                return new ErrorDataResult<UserAuthoritiesDto>(Messages.UserOrAuthortiesAreNull);
            }
            return new SuccessDataResult<UserAuthoritiesDto>(userAuthoritiesDto);
        }

        public IResult Update(UserAuthority userAuthority)
        {
            _userAuthorityDal.Update(userAuthority);
            return new SuccessResult(Messages.UserAuthorityUpdated);
        }
    }
}
