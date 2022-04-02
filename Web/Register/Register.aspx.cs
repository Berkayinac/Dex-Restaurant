using Business.Abstract;
using Business.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Register
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        IAuthService _authService = new AuthManager();

        protected void Btn_Register_Click(object sender, EventArgs e)
        {
            UserForRegisterDto userForRegisterDto = new UserForRegisterDto();

            userForRegisterDto.FirstName = tbx_FirstName.Text;
            userForRegisterDto.LastName = tbx_LastName.Text;
            userForRegisterDto.Email = tbx_Email.Text;
            userForRegisterDto.Password = tbx_Password.Text;

            var result = _authService.Register(userForRegisterDto);

            if (result.Success)
            {
                lbl_Register.Text = result.Message;
            }

        }
    }
}