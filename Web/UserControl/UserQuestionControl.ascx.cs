using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
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
                var userEmail = Session["Email"].ToString();
                var userSecurityQuestionDto = _userService.GetUserSecurityQuestion(userEmail);

                if (!userSecurityQuestionDto.Success)
                {
                    lbl_PasswordReminder.Text = userSecurityQuestionDto.Message;
                    Response.Redirect("~/Register/Register.aspx");
                }

                Session["Question"] = userSecurityQuestionDto.Data.SecurityQuestion;

                lbl_userEmail.Text = userEmail;
                lbl_userQuestion.Text = userSecurityQuestionDto.Data.SecurityQuestion;
            }
        }

        IUserService _userService = new UserManager();

        protected void Btn_userQuestion_Click(object sender, EventArgs e)
        {
            var userEmail = Session["Email"].ToString();
            var userSecurityQuestionDto = _userService.GetUserSecurityQuestion(userEmail);

            var userQuestionAnswer = tbx_UserQuestionAnswer.Text;

            if (userQuestionAnswer == userSecurityQuestionDto.Data.SecurityQuestionAnswer)
            {
                Session["QuestionAnswer"] = userQuestionAnswer;
                Response.Redirect("~/PasswordReminder/PasswordChange.aspx");
            }
            lbl_PasswordReminder.Text = "Tekrar Deneyiniz.";
        }
    }
}