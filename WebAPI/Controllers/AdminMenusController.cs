using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class AdminMenusController : ApiController
    {
        IAdminMenuService _adminMenuService;
        public AdminMenusController()
        {
            _adminMenuService = new AdminMenuManager();
        }

        [HttpGet]
        public List<AdminMenu> GetAll()
        {
            var result = _adminMenuService.GetAll();
            if (result.Success)
            {
                return result.Data;
            }
            return null;
        }

        [HttpGet]
        public AdminMenu GetById(int id)
        {
            var result = _adminMenuService.GetById(id);
            if (result.Success)
            {
                return result.Data;
            }
            return null;
        }

        [HttpPost]
        public string Add(AdminMenu adminMenu)
        {
            var result = _adminMenuService.Add(adminMenu);
            if (result.Success)
            {
                return result.Message;
            }
            return result.Message;
        }

        [HttpPost]
        public string Delete(AdminMenu adminMenu)
        {
            var result = _adminMenuService.Delete(adminMenu);
            if (result.Success)
            {
                return result.Message;
            }
            return result.Message;
        }

        [HttpPost]
        public string Update(AdminMenu adminMenu)
        {
            var result = _adminMenuService.Update(adminMenu);
            if (result.Success)
            {
                return result.Message;
            }
            return result.Message;
        }
    }
}