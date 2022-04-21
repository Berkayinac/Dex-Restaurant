using Business.Abstract;
using Business.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.PasswordReminder
{
    public partial class PasswordReminder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        IAuthService _authService = new AuthManager();

        IUserService _userService = new UserManager();

        protected void Btn_PasswordReminder_Click(object sender, EventArgs e)
        {
            var result =_authService.UserExists(tbx_Email.Text);
            if (!result.Success)
            {
                lbl_PasswordReminder.Text = result.Message;
            }
             
             Response.Redirect("~/PasswordReminder/Question.aspx?Email=" + tbx_Email.Text);
            //Response.Redirect("~/PasswordReminder/Question.aspx/" + tbx_Email.Text);
        }
    }
}