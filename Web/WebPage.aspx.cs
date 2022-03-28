using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class WebPage : System.Web.UI.Page
    {
        IProductService _productService = new ProductManager();
        ICategoryService _categoryService = new CategoryManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public List<Product> GetAllProducts()
        {
            return _productService.GetAll().Data;
        }

        public List<ProductDto> GetAllProductDtos()
        {
            return _productService.GetAllByDto().Data;
        }

        public List<Category> GetAllCategories()
        {
            return _categoryService.GetAll().Data;
        }
    }
}