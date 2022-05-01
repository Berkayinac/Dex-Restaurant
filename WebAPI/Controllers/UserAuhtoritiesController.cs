using Business.Abstract;
using Business.Concrete;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class UserAuhtoritiesController : ApiController
    {
        IUserAuthorityService _userAuthorityService;
        public UserAuhtoritiesController()
        {
            _userAuthorityService = new UserAuthorityManager();
        }

        [HttpGet]
        public List<UserAuthority> GetAll()
        {
            var result = _userAuthorityService.GetAll();
            if (result.Success)
            {
                return result.Data;
            }
            return null;
        }

        [HttpGet]
        public UserAuthority GetById(int id)
        {
            var result = _userAuthorityService.GetById(id);
            if (result.Success)
            {
                return result.Data;
            }
            return null;
        }

        [HttpPost]
        public string Add(UserAuthority userAuthority)
        {
            var result = _userAuthorityService.Add(userAuthority);
            if (result.Success)
            {
                return result.Message;
            }
            return result.Message;
        }

        [HttpPost]
        public string Delete(UserAuthority userAuthority)
        {
            var result = _userAuthorityService.Delete(userAuthority);
            if (result.Success)
            {
                return result.Message;
            }
            return result.Message;
        }

        [HttpPost]
        public string Update(UserAuthority userAuthority)
        {
            var result = _userAuthorityService.Update(userAuthority);
            if (result.Success)
            {
                return result.Message;
            }
            return result.Message;
        }
    }
}