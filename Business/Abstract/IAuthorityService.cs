using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthorityService
    {
        IDataResult<List<Authority>> GetAll();
        IDataResult<Authority> GetById(int id);
        IResult Add(Authority authority);
        IResult Update(Authority authority);
        IResult Delete(Authority authority);
    }
}
