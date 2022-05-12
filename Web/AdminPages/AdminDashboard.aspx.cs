using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Ninject;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.AdminPages
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        IProductService _productService;
        ICustomerService _customerService;
        ICategoryService _categoryService;
        IOrderService _orderService;
        public AdminDashboard()
        {
            _productService = InstanceFactory.GetInstance<IProductService>();
            _customerService = InstanceFactory.GetInstance<ICustomerService>();
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();
            _orderService = InstanceFactory.GetInstance<IOrderService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_Categories.Text = Convert.ToString(CategoriesCount());
            lbl_Customers.Text = Convert.ToString(CustomersCount());
            lbl_Orders.Text = Convert.ToString(OrdersCount());
            lbl_Products.Text = Convert.ToString(ProductsCount());
        }

        // PersentMethods
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

        // CountMethods

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


        // GetAllMethods
        public List<Product> ProductsGetAll()
        {
            return _productService.GetAll().Data;
        }
        public List<Category> CategoriesGetAll()
        {
            return _categoryService.GetAll().Data;
        }
    }
}