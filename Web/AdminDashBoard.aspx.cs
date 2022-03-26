using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class AdminDashBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_Categories.Text = Convert.ToString(CategoriesCount());
            lbl_Customers.Text = Convert.ToString(CustomersCount());
            lbl_Orders.Text = Convert.ToString(OrdersCount());
            lbl_Products.Text = Convert.ToString(ProductsCount());
        }

        IProductService _productService = new ProductManager();
        IUserService _userService = new UserManager();
        ICustomerService _customerService = new CustomerManager();
        ICategoryService _categoryService = new CategoryManager();
        IOrderService _orderService = new OrderManager();

        
        // Persents
        public double ProductsPersent()
        {
            double result = _productService.GetAll().Data.Count / 10.0;
            return result;
        }

        public double OrdersPersent()
        {
            double result =  _orderService.GetAll().Data.Count / 10.0;
            return result;
        }
        public double CategoriesPersent()
        {
            double result = _categoryService.GetAll().Data.Count / 10.0;
            return result;
        }
        public double CustomersPersent()
        {
            double result = _customerService.GetAll().Data.Count / 10.0;
            return result;
        }

        // Counts

        public int ProductsCount()
        {
            return _productService.GetAll().Data.Count;
        }

        public int CategoriesCount()
        {
            return _categoryService.GetAll().Data.Count;
        }

        public int CustomersCount()
        {
            return _customerService.GetAll().Data.Count;
        }

        public int OrdersCount()
        {
            return _orderService.GetAll().Data.Count;
        }


        // GetAlls
        public List<Product> ProductsGetAll()
        {
            return _productService.GetAll().Data;
        }
        public List<Category> CategoriesGetAll()
        {
            return _categoryService.GetAll().Data;
        }

        //public int UsersGetAll()
        //{
        //   return _userService.GetAll().Data.Count;
        //}

        //public int CustomersGetAll()
        //{
        //   return _customerService.GetAll().Data.Count;
        //}



        
    }
}