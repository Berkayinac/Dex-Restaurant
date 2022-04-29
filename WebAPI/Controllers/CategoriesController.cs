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
    public class CategoriesController : ApiController
    {
        ICategoryService _categoryService;
        public CategoriesController()
        {
            _categoryService = new CategoryManager();
        }

        [HttpGet]
        public List<Category> GetAll()
        {
            var result = _categoryService.GetAll();
            if (result.Success)
            {
                return result.Data;
            }
            return null;
        }

        [HttpGet]
        public Category GetById(int id)
        {
            var result = _categoryService.GetById(id);
            if (result.Success)
            {
                return result.Data;
            }
            return null;
        }

        [HttpPost]
        public string Add(Category category)
        {
            var result = _categoryService.Add(category);
            if (result.Success)
            {
                return result.Message;
            }
            return result.Message;
        }

        [HttpPost]
        public string Delete(Category category)
        {
            var result = _categoryService.Delete(category);
            if (result.Success)
            {
                return result.Message;
            }
            return result.Message;
        }

        [HttpPost]
        public string Update(Category category)
        {
            var result = _categoryService.Update(category);
            if (result.Success)
            {
                return result.Message;
            }
            return result.Message;
        }
    }
}