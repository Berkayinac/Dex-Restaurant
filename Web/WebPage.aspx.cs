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
        protected void Page_Load(object sender, EventArgs e)
        {
            GetAll();
        }

        public void GetAll()
        {
            GridView1.DataSource = _productService.GetAllByDto().Data;
            GridView1.DataBind();
        }

        IProductService _productService = new ProductManager();
        ICategoryService _categoryService = new CategoryManager();

        public List<ProductDto> GetAllProductDtos()
        {
            return _productService.GetAllByDto().Data;
        }

        public List<Category> GetAllCategories()
        {
            return _categoryService.GetAll().Data;
        }

        protected void Lnk_AddToCart_Command(object sender, CommandEventArgs e)
        {
            var productId = Convert.ToInt32(e.CommandArgument);
            var productToDelete = _productService.GetById(productId).Data;

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        protected void Lnk_Cart_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Cart.aspx");
        }
    }
}