using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserAuthorityService
    {
        IDataResult<List<UserAuthority>> GetAll();
        IDataResult<UserAuthority> GetById(int id);
        IResult Add(UserAuthority userAuthority);
        IResult Update(UserAuthority userAuthority);
        IResult Delete(UserAuthority userAuthority);
    }
}
