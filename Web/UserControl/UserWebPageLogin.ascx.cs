using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.UserControl
{
    public partial class UserWebPageLogin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (HttpContext.Current.Session["UserName"] == null)
                {
                    Literal1.Text = "<a href=" + "'/Login/Login'" + " class=" + "'book-a-table-btn scrollto d-none d-lg-flex'" + ">" + "Login" + "</a>";
                }

                else
                {
                    Literal1.Text ="Welcome," + " " + HttpContext.Current.Session["UserName"].ToString();
                }
            }
        }

        protected void Lnk_Logout_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["UserName"] = null;
            HttpContext.Current.Session["Authorities"] = null;
            HttpContext.Current.Session["Email"] = null;
            HttpContext.Current.Session["Question"] = null;
            HttpContext.Current.Session["QuestionAnswer"] = null;

            Response.Redirect("~/WebPage");
        }
    }
}