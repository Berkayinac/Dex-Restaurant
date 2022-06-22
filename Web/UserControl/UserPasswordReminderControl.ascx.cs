using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Ninject;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.UserControl
{
    public partial class UserPasswordReminderControl : System.Web.UI.UserControl
    {
        IAuthService _authService;
        public UserPasswordReminderControl()
        {
            _authService = InstanceFactory.GetInstance<IAuthService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_PasswordReminder_Click(object sender, EventArgs e)
        {
            var result = _authService.UserExists(tbx_Email.Text);
            if (!result.Success)
            {
                lbl_PasswordReminder.Text = result.Message;
            }

            HttpContext.Current.Session["Email"] = tbx_Email.Text;

            //HttpContext.Current.Session["User"] = 

            Response.Redirect("~/Question");
        }
    }
}