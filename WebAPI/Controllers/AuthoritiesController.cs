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
    public class AuthoritiesController : ApiController
    {
        IAuthorityService _auhtorityService;
        public AuthoritiesController()
        {
            _auhtorityService = InstanceFactory.GetInstance<IAuthorityService>();
        }

        [HttpGet]
        public List<Authority> GetAll()
        {
            var result = _auhtorityService.GetAll();
            if (result.Success)
            {
                return result.Data;
            }
            return null;
        }

        [HttpGet]
        public Authority GetById(int id)
        {
            var result = _auhtorityService.GetById(id);
            if (result.Success)
            {
                return result.Data;
            }
            return null;
        }

        [HttpPost]
        public string Add(Authority authority)
        {
            var result = _auhtorityService.Add(authority);
            if (result.Success)
            {
                return result.Message;
            }
            return result.Message;
        }

        [HttpPost]
        public string Delete(Authority authority)
        {
            var result = _auhtorityService.Delete(authority);
            if (result.Success)
            {
                return result.Message;
            }
            return result.Message;
        }

        [HttpPost]
        public string Update(Authority authority)
        {
            var result = _auhtorityService.Update(authority);
            if (result.Success)
            {
                return result.Message;
            }
            return result.Message;
        }
    }
}