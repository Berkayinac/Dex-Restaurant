using Business.Abstract;
using Business.Concrete;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.UserControl
{
    public partial class UserRegisterControl : System.Web.UI.UserControl
    {
        IAuthService _authService;
        ICustomerService _customerService;
        ISecurityQuestionService _securityQuestionService;

        public UserRegisterControl()
        {
            _authService = new AuthManager();
            _securityQuestionService = new SecurityQuestionManager();
            _customerService = new CustomerManager();
        }


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
            if (result.Success)
            {
                UserAuthority userAuthority = new UserAuthority();
                userAuthority.AuthorityId = 1;
                userAuthority.UserId = result.Data.Id;

                _authService.AddUserAuthority(userAuthority);

                Customer customer = new Customer
                {
                    UserId = result.Data.Id,
                    FirstName = tbx_FirstName.Text,
                    LastName = tbx_LastName.Text,
                    City = tbx_City.Text,
                    Address = tbx_Address.Text,
                    Phone = tbx_PhoneNumber.Text
                };

                _customerService.Add(customer);

                lbl_Register.Text = result.Message;
                Response.Redirect("/Login/Login");
            }

            lbl_Register.Text = result.Message;
        }
    }
}