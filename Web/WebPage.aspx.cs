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
        IProductService _productService;
        ICategoryService _categoryService;
        ICartService _cartService;
        IUserService _userService;
        public WebPage()
        {
            _categoryService = new CategoryManager();
            _productService = new ProductManager();
            _cartService = new CartManager();
            _userService = new UserManager();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAll();
        }

        public void GetAll()
        {
            Grd_ProductDtos.DataSource = _productService.GetAllByDto().Data;
            Grd_ProductDtos.DataBind();
        }

        public List<CartDto> GetCarts()
        {
            var userId = Session["UserId"];
            var user = _userService.GetById(Convert.ToInt32(userId)).Data;
            var result = _cartService.GetAllDtos(user);
            if (result.Success)
            {
                return result.Data;
            }
            return null;
        }


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
            var productToAddCart = _productService.GetById(productId).Data;

            Cart cart = new Cart();
            cart.ProductId = productId;
            cart.UserId = Convert.ToInt32(Session["UserId"]);

            _cartService.Add(cart);
        }

        protected void Lnk_Cart_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Cart.aspx");
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grd_ProductDtos.PageIndex = e.NewPageIndex;
            Grd_ProductDtos.DataBind();
        }
    }
}