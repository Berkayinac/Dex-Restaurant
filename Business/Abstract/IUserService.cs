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
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetByMail(string email);
        IDataResult<User> GetById(int userId);
        IDataResult<List<AuthorityDto>> GetAuthorities(User user);
        IDataResult<UserSecurityQuestionDto> GetUserSecurityQuestion(string email);
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        
    }
}
