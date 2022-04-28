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

namespace Web.UserControl
{
    public partial class AdminControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Authorities"] == null)
            {
                Response.Redirect("~/WebPage");
            }

            else
            {
                var userAuthorities = Session["Authorities"].ToString();
                var authorities = userAuthorities.Split(',');

                if (authorities.Contains("Admin"))
                {
                    var href = "<a href=";
                    var myLink = "'/Admin/Dashboard'" + " ";
                    var myCssClass = "class=" + "'book-a-table-btn scrollto d-none d-lg-flex'>";
                    var myName = "Admin";
                    var hrefclose = "</a>";
                    myLiteral.Text = href + myLink + myCssClass + myName + hrefclose;
                    var lol = myLiteral.Text;
                }
                else
                {
                    Response.Redirect("~    /WebPage");
                }
            }
            
        }
    }
}