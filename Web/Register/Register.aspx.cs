using Business.Abstract;
using Business.Concrete;
using Core.Entities.Concrete;
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
            if (!IsPostBack)
            {
                drp_SecurityQuestions.DataSource = GetAllQuestions();
                drp_SecurityQuestions.DataBind();
            }
        }

        private List<ListItem> GetAllQuestions()
        {
            var securityQuestions = _securityQuestionService.GetAll().Data;

            List<ListItem> list = new List<ListItem>();

            foreach (var question in securityQuestions)
            {
                ListItem item = new ListItem();
                item.Text = question.Question;
                item.Value = Convert.ToString(question.Id);

                list.Add(item);
            }

            return list;
        }

        IAuthService _authService = new AuthManager();

        ISecurityQuestionService _securityQuestionService = new SecurityQuestionManager();



        protected void Btn_Register_Click(object sender, EventArgs e)
        {
            UserForRegisterDto userForRegisterDto = new UserForRegisterDto();

            userForRegisterDto.FirstName = tbx_FirstName.Text;
            userForRegisterDto.LastName = tbx_LastName.Text;
            userForRegisterDto.Email = tbx_Email.Text;
            userForRegisterDto.Password = tbx_Password.Text;

            UserSecurityQuestionDto userSecurityQuestionDto = new UserSecurityQuestionDto();

            userSecurityQuestionDto.SecurityQuestion = drp_SecurityQuestions.SelectedItem.Text;
            userSecurityQuestionDto.SecurityQuestionAnswer = tbx_SecurityQuestionAnswer.Text;

            var result = _authService.Register(userForRegisterDto, userSecurityQuestionDto);

            UserAuthority userAuthority = new UserAuthority
            {
                UserId = result.Data.Id,
                AuthorityId = 1
            };

            _authService.AddUserAuthority(userAuthority);

            lbl_Register.Text = result.Message;

            if (result.Success)
            {
                lbl_Register.Text = result.Message;
                Response.Redirect("/Login/Login.aspx");
            }

            lbl_Register.Text = result.Message;
        }
    }
}