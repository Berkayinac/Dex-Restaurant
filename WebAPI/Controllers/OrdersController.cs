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
    public class OrdersController : ApiController
    {
        IOrderService _orderService;
        public OrdersController()
        {
            _orderService = new OrderManager();
        }

        [HttpGet]
        public List<Order> GetAll()
        {
            var result = _orderService.GetAll();
            if (result.Success)
            {
                return result.Data;
            }
            return null;
        }

        [HttpGet]
        public Order GetById(int id)
        {
            var result = _orderService.GetById(id);
            if (result.Success)
            {
                return result.Data;
            }
            return null;
        }

        [HttpPost]
        public string Add(Order order)
        {
            var result = _orderService.Add(order);
            if (result.Success)
            {
                return result.Message;
            }
            return result.Message;
        }

        [HttpPost]
        public string Delete(Order order)
        {
            var result = _orderService.Delete(order);
            if (result.Success)
            {
                return result.Message;
            }
            return result.Message;
        }

        [HttpPost]
        public string Update(Order order)
        {
            var result = _orderService.Update(order);
            if (result.Success)
            {
                return result.Message;
            }
            return result.Message;
        }
    }
}