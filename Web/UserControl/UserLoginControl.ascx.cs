﻿using Business.Abstract;
using Business.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.UserControl
{
    public partial class UserLoginControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        IAuthService _authService = new AuthManager();

        protected void Btn_Login_Click(object sender, EventArgs e)
        {
            UserForLoginDto userForLoginDto = new UserForLoginDto();
            userForLoginDto.Email = tbx_Email.Text;
            userForLoginDto.Password = tbx_Password.Text;

            var userLogin = _authService.Login(userForLoginDto);

            if (userLogin.Success)
            {
                var userAuthorities = _authService.GetUserAuthority(userLogin.Data).Data;
                string authorities = "";

                foreach (var authority in userAuthorities.Authorities)
                {
                    authorities += authority.AuthorityName + ",";
                }

                Session["Authorities"] = authorities;
                Response.Redirect("/WebPage.aspx");
            }
            lbl_Login.Text = userLogin.Message;
        }

        protected void Btn_PasswordReminder_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PasswordReminder/PasswordReminder.aspx");
        }

    }
}