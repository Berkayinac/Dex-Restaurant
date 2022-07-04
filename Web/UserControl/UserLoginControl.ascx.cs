using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Ninject;
using Core.Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.UserControl
{
    public partial class UserLoginControl : UserAuthoritiesCheck
    {
        IAuthService _authService;
        public UserLoginControl()
        {
            _authService = InstanceFactory.GetInstance<IAuthService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Login_Click(object sender, EventArgs e)
        {
            UserForLoginDto userForLoginDto = new UserForLoginDto();
            userForLoginDto.Email = tbx_Email.Text;
            userForLoginDto.Password = tbx_Password.Text;

            var userLogin = _authService.Login(userForLoginDto);

            if (!userLogin.Success)
            {
                lbl_Login.Text = userLogin.Message;
                Thread.Sleep(3000);
                Response.Redirect("~/Login");
            }

            var userAuthoritiesDto = _authService.GetUserAuthority(userLogin.Data).Data;

            HttpContext.Current.Session["UserName"] = userAuthoritiesDto.User.FirstName + " " + userAuthoritiesDto.User.LastName;
            HttpContext.Current.Session["UserId"] = userAuthoritiesDto.User.Id;

            HttpContext.Current.Session["UserAuthoritiesDto"] = userAuthoritiesDto;

            UserAuthorityRoute(userAuthoritiesDto.Authorities);
        }

        protected void Btn_PasswordReminder_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PasswordReminder");
        }

        protected void Btn_Register_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Register");
        }
    }
}