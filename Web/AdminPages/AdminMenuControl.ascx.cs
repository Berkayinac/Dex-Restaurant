using Business.Abstract;
using Business.Concrete;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Web.AdminPages
{
    public partial class AdminMenuControl : System.Web.UI.UserControl
    {
        IAuthService authService = new AuthManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            var authority = Session["Authority"];

            var userAuthorities = authority.ToString();

            var authorities = userAuthorities.Split(',');

            if (authorities.Contains("Admin"))
            {
                for (int i = 0; i < authorities.Length; i++)
                {
                    AdminMenuManager adminMenuManager = new AdminMenuManager();

                    var menus = adminMenuManager.GetAll().Data;

                    string myMenu = "";

                    foreach (var menu in menus)
                    {
                        myMenu += "<li>";
                        myMenu += "<a href = " + "" + menu.Name + " ><i class='fa fa-table'></i> " + " " + menu.Name + "</a>";
                        myMenu += "</li>";
                    }
                    Literal1.Text = myMenu;
                }
            } 
        }
    }
}