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
    public class ProductsController : ApiController
    {
        IProductService _productService;
        public ProductsController()
        {
            _productService = InstanceFactory.GetInstance<IProductService>();
        }

        [HttpGet]
        public List<Product> GetAll()
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                return result.Data;
            }
            return null;
        }

        [HttpGet]
        public Product GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return result.Data;
            }
            return null;
        }

        [HttpPost]
        public string Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
               return result.Message;
            }
            return result.Message;
        }

        [HttpPost]
        public string Delete(Product product)
        {
            var result = _productService.Delete(product);
            if (result.Success)
            {
                return result.Message;
            }
            return result.Message;
        }

        [HttpPost]
        public string Update(Product product)
        {
            var result = _productService.Update(product);
            if (result.Success)
            {
                return result.Message;
            }
            return result.Message;
        }
    }
}