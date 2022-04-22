using Business.Abstract;
using Business.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.UserControl
{
    public partial class UserPasswordChangeControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        IUserService _userService = new UserManager();
        protected void Btn_PasswordChange_Click(object sender, EventArgs e)
        {
            var userEmail = Request.QueryString["email"];

            var deneme = Request.QueryString;

            var user = _userService.GetByMail(userEmail);

            if (!user.Success)
            {
                lbl_PasswordReminder.Text = "Kullanıcı bulunamadı";
            }

            if (tbx_NewPassword.Text != tbx_PasswordVerify.Text)
            {
                lbl_PasswordReminder.Text = "Parola Eşleşmedi";
            }

            user.Data.Password = tbx_NewPassword.Text;

            _userService.Update(user.Data);

            Response.Redirect("~/Login/Login.aspx");
        }
    }
}


//< !--Response.Redirect kullanarak url oalrak gönderilen veriyi çek  -->