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
    public class RestaurantMenusController : ApiController
    {
        IRestaurantMenuService _restaurantMenuService;
        public RestaurantMenusController()
        {
            _restaurantMenuService = new RestaurantMenuManager();
        }

        [HttpGet]
        public List<RestaurantMenu> GetAll()
        {
            var result = _restaurantMenuService.GetAll();
            if (result.Success)
            {
                return result.Data;
            }
            return null;
        }

        [HttpGet]
        public RestaurantMenu GetById(int id)
        {
            var result = _restaurantMenuService.GetById(id);
            if (result.Success)
            {
                return result.Data;
            }
            return null;
        }

        [HttpPost]
        public string Add(RestaurantMenu restaurantMenu)
        {
            var result = _restaurantMenuService.Add(restaurantMenu);
            if (result.Success)
            {
                return result.Message;
            }
            return result.Message;
        }

        [HttpPost]
        public string Delete(RestaurantMenu restaurantMenu)
        {
            var result = _restaurantMenuService.Delete(restaurantMenu);
            if (result.Success)
            {
                return result.Message;
            }
            return result.Message;
        }

        [HttpPost]
        public string Update(RestaurantMenu restaurantMenu)
        {
            var result = _restaurantMenuService.Update(restaurantMenu);
            if (result.Success)
            {
                return result.Message;
            }
            return result.Message;
        }
    }
}