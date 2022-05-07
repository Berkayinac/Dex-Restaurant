using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Ninject;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class CustomersController : ApiController
    {
        ICustomerService _customerService;
        public CustomersController()
        {
            _customerService = InstanceFactory.GetInstance<ICustomerService>();
        }

        [HttpGet]
        public List<Customer> GetAll()
        {
            var result = _customerService.GetAll();
            if (result.Success)
            {
                return result.Data;
            }
            return null;
        }

        [HttpGet]
        public Customer GetById(int id)
        {
            var result = _customerService.GetById(id);
            if (result.Success)
            {
                return result.Data;
            }
            return null;
        }

        [HttpPost]
        public string Add(Customer customer)
        {
            var result = _customerService.Add(customer);
            if (result.Success)
            {
                return result.Message;
            }
            return result.Message;
        }

        [HttpPost]
        public string Delete(Customer customer)
        {
            var result = _customerService.Delete(customer);
            if (result.Success)
            {
                return result.Message;
            }
            return result.Message;
        }

        [HttpPost]
        public string Update(Customer customer)
        {
            var result = _customerService.Update(customer);
            if (result.Success)
            {
                return result.Message;
            }
            return result.Message;
        }
    }
}