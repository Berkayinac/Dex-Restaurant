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
    public partial class AdminProductPanelV1 : System.Web.UI.Page
    {
        IProductService _productService;
        public AdminProductPanelV1()
        {
            _productService = InstanceFactory.GetInstance<IProductService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAll();
        }

        public void GetAll()
        {
            GridView1.DataSource = _productService.GetAll().Data;
            GridView1.DataBind();
        }

        protected void LnkBtn_Update_Command(object sender, CommandEventArgs e)
        {
            var productId = Convert.ToInt32(e.CommandArgument);
            var productToUpdate = _productService.GetById(productId).Data;

            tbx_UpdateId.Text = Convert.ToString(productToUpdate.Id);
            tbx_UpdateCategoryId.Text = Convert.ToString(productToUpdate.CategoryId);
            tbx_UpdateName.Text = productToUpdate.Name;
            tbx_UpdateUnitPrice.Text = Convert.ToString(productToUpdate.UnitPrice);
            tbx_UpdateUnitsInStock.Text = Convert.ToString(productToUpdate.UnitsInStock);

            GetAll();
        }

        protected void LnkBtn_Delete_Command(object sender, CommandEventArgs e)
        {
            var productId = Convert.ToInt32(e.CommandArgument);
            var productToDelete = _productService.GetById(productId).Data;

            Delete(productToDelete);

            GetAll();
        }

        public void Delete(Product product)
        {
            _productService.Delete(product);
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.Id = Convert.ToInt32(tbx_UpdateId.Text);
            product.CategoryId = Convert.ToInt32(tbx_UpdateCategoryId.Text);
            product.Name = tbx_UpdateName.Text;
            product.UnitPrice = Convert.ToDecimal(tbx_UpdateUnitPrice.Text);
            product.UnitsInStock = Convert.ToInt16(tbx_UpdateUnitsInStock.Text);

            _productService.Update(product);
            GetAll();
        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.CategoryId = Convert.ToInt32(tbx_AddCategoryId.Text);
            product.Name = tbx_AddName.Text;
            product.UnitPrice = Convert.ToDecimal(tbx_AddUnitPrice.Text);
            product.UnitsInStock = Convert.ToInt16(tbx_AddUnitsInStock.Text);

            _productService.Add(product);
            GetAll();
        }

    }
}