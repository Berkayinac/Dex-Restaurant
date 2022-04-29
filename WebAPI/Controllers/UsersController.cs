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
    public class UsersController : ApiController
    {
        IUserService _userService;
        public UsersController()
        {
            _userService = new UserManager();
        }
        [HttpGet]
        public List<User> GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return result.Data;
            }
            return null;
        }

        [HttpGet]
        public User GetById(int id)
        {
            var result = _userService.GetById(id);
            if (result.Success)
            {
                return result.Data;
            }
            return null;
        }

        [HttpPost]
        public string Add(User user)
        {
            var result = _userService.Add(user);
            if (result.Success)
            {
                return result.Message;
            }
            return result.Message;
        }

        [HttpPost]
        public string Delete(User user)
        {
            var result = _userService.Delete(user);
            if (result.Success)
            {
                return result.Message;
            }
            return result.Message;
        }

        [HttpPost]
        public string Update(User user)
        {
            var result = _userService.Update(user);
            if (result.Success)
            {
                return result.Message;
            }
            return result.Message;
        }


    }
}