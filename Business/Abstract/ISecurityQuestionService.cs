using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISecurityQuestionService 
    {
        IDataResult<List<SecurityQuestion>> GetAll();
        IDataResult<SecurityQuestion> GetById(int id);
        IDataResult<SecurityQuestion> GetByQuestion(string question);
        IResult Add(SecurityQuestion securityQuestion);
        IResult Update(SecurityQuestion securityQuestion);
        IResult Delete(SecurityQuestion securityQuestion);
    }
}
