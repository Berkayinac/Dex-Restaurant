using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Entities.Concrete;
using Core.Utilities.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SecurityQuestionManager : ISecurityQuestionService
    {
        private ISecurityQuestionDal _securityQuestionDal;
        public SecurityQuestionManager(ISecurityQuestionDal securityQuestionDal)
        {
            _securityQuestionDal = securityQuestionDal;
        }

        public IResult Add(SecurityQuestion securityQuestion)
        {
            ValidationTool.Validate(new SecurityQuestionValidator(), securityQuestion);

            _securityQuestionDal.Add(securityQuestion);
            return new SuccessResult();
        }

        public IResult Delete(SecurityQuestion securityQuestion)
        {
            _securityQuestionDal.Delete(securityQuestion);
            return new SuccessResult();
        }

        public IDataResult<List<SecurityQuestion>> GetAll()
        {
            return new SuccessDataResult<List<SecurityQuestion>>(_securityQuestionDal.GetAll());
        }

        public IDataResult<SecurityQuestion> GetById(int id)
        {
            return new SuccessDataResult<SecurityQuestion>(_securityQuestionDal.Get(s=>s.Id == id));
        }

        public IDataResult<SecurityQuestion> GetByQuestion(string question)
        {
            return new SuccessDataResult<SecurityQuestion>(_securityQuestionDal.Get(s => s.Question == question));
        }

        public IResult Update(SecurityQuestion securityQuestion)
        {
            ValidationTool.Validate(new SecurityQuestionValidator(), securityQuestion);

            _securityQuestionDal.Update(securityQuestion);
            return new SuccessResult();
        }
    }
}
