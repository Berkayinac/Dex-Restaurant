﻿using Business.Abstract;
using Business.Concrete;
using Core.Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Login
{
    public partial class Login : System.Web.UI.Page
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

            var result = _authService.Login(userForLoginDto);

            if (result.Success)
            {
                lbl_Login.Text= result.Message;
            }
            lbl_Login.Text = result.Message;
        }
    }
}