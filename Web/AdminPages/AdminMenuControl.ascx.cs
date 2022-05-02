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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Authorities"] == null)
            {
                Response.Redirect("~/WebPage");
            }

            if (HttpContext.Current.Session["Authorities"] != null)
            {
                var userAuthorities = HttpContext.Current.Session["Authorities"].ToString();
                var authorities = userAuthorities.Split(',');

                if (!authorities.Contains("Admin"))
                {
                    Response.Redirect("~/WebPage");
                }

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