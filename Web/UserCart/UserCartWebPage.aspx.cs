﻿using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.UserCart
{
    public partial class UserCartWebPage : System.Web.UI.Page
    {
        IProductService _productService;
        ICategoryService _categoryService;
        ICartService _cartService;
        IUserService _userService;
        IOrderService _orderService;
        ICustomerService _customerService;

        public UserCartWebPage()
        {
            _categoryService = new CategoryManager();
            _productService = new ProductManager();
            _cartService = new CartManager();
            _userService = new UserManager();
            _orderService = new OrderManager();
            _customerService = new CustomerManager();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAll();
            GetCarts();
        }

        public void GetAll()
        {
            GridView1.DataSource = GetCarts();
            GridView1.DataBind();

            lbl_TotalPrice.Text = "TotalPrice: " +TotalPrice().ToString() +"$";
        }

        public List<CartDto> GetCarts()
        {
            if (Session["UserId"] != null)
            {
                var userId = Convert.ToInt32(Session["UserId"]);
                var user = _userService.GetById(userId).Data;
                var result = _cartService.GetAllDtos(user);
                if (result.Success)
                {
                    return result.Data;
                }
            }
            return null;
        }

        public decimal TotalPrice()
        {
            decimal price = 0;
            foreach (var cartItem in GetCarts())
            {
               price += cartItem.ProductUnitPrice * cartItem.Quantity;
            }
            return price;
        }


        public List<ProductDto> GetAllProductDtos()
        {
            return _productService.GetAllByDto().Data;
        }

        public List<Category> GetAllCategories()
        {
            return _categoryService.GetAll().Data;
        }

        protected void Lnk_Cart_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Cart");
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        protected void Lnk_DeleteToCart_Command(object sender, CommandEventArgs e)
        {
            var productId = Convert.ToInt32(e.CommandArgument);

            Cart cart = new Cart();
            cart.ProductId = productId;
            cart.UserId = Convert.ToInt32(Session["UserId"]);
            cart.Quantity = 1;

            _cartService.CartDelete(cart);
            Response.Redirect("~/Cart");
        }

        protected void Lnk_Order_Click(object sender, EventArgs e)
        {
            var userCarts = GetCarts();
            var userId = Convert.ToInt32(Session["UserId"]);
            foreach (var cartItem in userCarts)
            {
                Order order = new Order
                {
                    ProductId = cartItem.ProductId,
                    CustomerId = _customerService.GetByUserId(userId).Data.Id,
                    Quantity = cartItem.Quantity
                };
                _orderService.Add(order);

                var product = _productService.GetById(cartItem.ProductId).Data;
                product.UnitsInStock -= cartItem.Quantity;
                _productService.Update(product);

                var cart = _cartService.GetById(cartItem.CartId).Data;
                _cartService.Delete(cart);
            }
            Response.Redirect("~/WebPage");
        }
    }
}