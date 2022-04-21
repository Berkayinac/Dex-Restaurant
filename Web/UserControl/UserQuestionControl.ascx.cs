using Business.Abstract;
using Business.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.UserControl
{
    public partial class UserQuestionControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var userEmail = Request.QueryString["email"];

                Session["Email"] = userEmail;

                var userQuestion = _userService.GetUserSecurityQuestion(userEmail);

                if (!userQuestion.Success)
                {
                    lbl_PasswordReminder.Text = "kullanıcının güvenlik sorusu bulunamadı.";
                    Response.Redirect("~/Register/Register.aspx");
                }

                lbl_userEmail.Text = userEmail;
                lbl_userQuestion.Text = userQuestion.Data.SecurityQuestion;
            }
        }

        IUserService _userService = new UserManager();

        protected void Btn_userQuestion_Click(object sender, EventArgs e)
        {
            var userEmail = Request.QueryString["email"];

            var userQuestion = _userService.GetUserSecurityQuestion(userEmail);

            var result = tbx_UserQuestionAnswer.Text;

            if (result == userQuestion.Data.SecurityQuestionAnswer)
            {
                Response.Redirect("~/PasswordReminder/PasswordChange.aspx?email=" + userEmail);
            }
            lbl_PasswordReminder.Text = "Tekrar Deneyiniz.";


        }
    }
}