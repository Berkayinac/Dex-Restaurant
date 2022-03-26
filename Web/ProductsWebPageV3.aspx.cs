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
    public partial class ProductsWebPageV3 : System.Web.UI.Page
    {

        IProductService _productService = new ProductManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public List<Product> GetAll()
        {
            return _productService.GetAll().Data;
        }

    }
}