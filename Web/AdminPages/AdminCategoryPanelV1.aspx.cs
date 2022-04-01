using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.AdminPages
{
    public partial class AdminCategoryPanelV1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetAll();
        }

        public void GetAll()
        {
            GridView1.DataSource = _categoryService.GetAll().Data;
            GridView1.DataBind();
        }

        ICategoryService _categoryService = new CategoryManager();

        protected void LnkBtn_Update_Command(object sender, CommandEventArgs e)
        {
            var categoryId = Convert.ToInt32(e.CommandArgument);
            var categoryToUpdate = _categoryService.GetById(categoryId).Data;

            tbx_UpdateId.Text = Convert.ToString(categoryToUpdate.Id);
            tbx_UpdateName.Text = Convert.ToString(categoryToUpdate.Name);

            GetAll();
        }

        protected void LnkBtn_Delete_Command(object sender, CommandEventArgs e)
        {
            var categoryId = Convert.ToInt32(e.CommandArgument);
            var categoryToDelete = _categoryService.GetById(categoryId).Data;

            Delete(categoryToDelete);

            GetAll();
        }

        public void Delete(Category category)
        {
            _categoryService.Delete(category);
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.Id = Convert.ToInt32(tbx_UpdateId.Text);
            category.Name = tbx_UpdateName.Text;

            _categoryService.Update(category);
            GetAll();
        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.Name = tbx_AddName.Text;

            _categoryService.Add(category);
            GetAll();
        }
    }
}