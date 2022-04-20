using Business.Abstract;
using Business.Concrete;
using Core.Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.AdminPages
{
    public partial class AdminUserPanelV1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetAll();
        }

        public void GetAll()
        {
            GridView1.DataSource = _userService.GetAll().Data;
            GridView1.DataBind();
        }

        IUserService _userService = new UserManager();

        protected void LnkBtn_Delete_Command(object sender, CommandEventArgs e)
        {
            var userId = Convert.ToInt32(e.CommandArgument);
            var userToDelete = _userService.GetById(userId).Data;

            _userService.Delete(userToDelete);

            GetAll();
        }
    }
}