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
    public partial class AdminControlWebPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        IProductService _productService = new ProductManager();
        ICategoryService _categoryService = new CategoryManager();

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

        protected void Btn_Add_to_Cart_Command(object sender, CommandEventArgs e)
        {

        }
    }
}