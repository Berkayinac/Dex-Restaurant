using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Ninject;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
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
    public partial class UserRegisterControl : System.Web.UI.UserControl
    {
        IAuthService _authService;
        ICustomerService _customerService;
        ISecurityQuestionService _securityQuestionService;

        public UserRegisterControl()
        {
            _authService = InstanceFactory.GetInstance<IAuthService>();
            _securityQuestionService = InstanceFactory.GetInstance<ISecurityQuestionService>();
            _customerService = InstanceFactory.GetInstance<ICustomerService>();
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
                ListItem item = new ListItem
                {
                    Text = question.Question,
                    Value = Convert.ToString(question.Id)
                };

                list.Add(item);
            }
            return list;
        }

        protected void Btn_Register_Click(object sender, EventArgs e)
        {
            UserForRegisterDto userForRegisterDto = new UserForRegisterDto
            {
                FirstName = tbx_FirstName.Text,
                LastName = tbx_LastName.Text,
                Email = tbx_Email.Text,
                Password = tbx_Password.Text
            };

            UserSecurityQuestionDto userSecurityQuestionDto = new UserSecurityQuestionDto
            {
                SecurityQuestion = drp_SecurityQuestions.SelectedItem.Text,
                SecurityQuestionAnswer = tbx_SecurityQuestionAnswer.Text
            };

            var result = _authService.Register(userForRegisterDto, userSecurityQuestionDto);
            if (!result.Success)
            {
                lbl_Register.Text = result.Message;
                Thread.Sleep(3000);
                Response.Redirect("~/Register");
            }

            UserAuthority userAuthority = new UserAuthority
            {
                AuthorityId = 1,
                UserId = result.Data.Id
            };

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

            Response.Redirect("~/Login");
        }
    }
}