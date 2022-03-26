using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthorityManager : IAuthorityService
    {
        private IAuthorityDal _authorityDal;

        public AuthorityManager()
        {
            _authorityDal = new EfAuthorityDal();
        }

        public IResult Add(Authority authority)
        {
            _authorityDal.Add(authority);
            return new SuccessResult(Messages.AuthorityAdded);
        }

        public IResult Delete(Authority authority)
        {
            _authorityDal.Delete(authority);
            return new SuccessResult(Messages.AuthorityDeleted);
        }

        public IDataResult<List<Authority>> GetAll()
        {
            var result = _authorityDal.GetAll();
            if (result == null)
            {
                return new ErrorDataResult<List<Authority>>();
            }
            return new SuccessDataResult<List<Authority>>(result, Messages.AuthoritiesListed);
        }

        public IDataResult<Authority> GetById(int id)
        {
            var result = _authorityDal.Get(a => a.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<Authority>();
            }
            return new SuccessDataResult<Authority>(result, Messages.AuthorityGeted);
        }

        public IResult Update(Authority authority)
        {
            _authorityDal.Update(authority);
            return new SuccessResult(Messages.AuthorityUpdated);
        }
    }
}
