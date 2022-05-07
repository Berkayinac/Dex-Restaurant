using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Ninject;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class SecurityQuestionsController : ApiController
    {
        ISecurityQuestionService _securityQuestionService;
        public SecurityQuestionsController()
        {
            _securityQuestionService = InstanceFactory.GetInstance<ISecurityQuestionService>();
        }

        [HttpGet]
        public List<SecurityQuestion> GetAll()
        {
            var result = _securityQuestionService.GetAll();
            if (result.Success)
            {
                return result.Data;
            }
            return null;
        }

        [HttpGet]
        public SecurityQuestion GetById(int id)
        {
            var result = _securityQuestionService.GetById(id);
            if (result.Success)
            {
                return result.Data;
            }
            return null;
        }

        [HttpPost]
        public string Add(SecurityQuestion securityQuestion)
        {
            var result = _securityQuestionService.Add(securityQuestion);
            if (result.Success)
            {
                return result.Message;
            }
            return result.Message;
        }

        [HttpPost]
        public string Delete(SecurityQuestion securityQuestion)
        {
            var result = _securityQuestionService.Delete(securityQuestion);
            if (result.Success)
            {
                return result.Message;
            }
            return result.Message;
        }

        [HttpPost]
        public string Update(SecurityQuestion securityQuestion)
        {
            var result = _securityQuestionService.Update(securityQuestion);
            if (result.Success)
            {
                return result.Message;
            }
            return result.Message;
        }
    }
}