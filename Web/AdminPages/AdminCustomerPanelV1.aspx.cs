using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Ninject;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.AdminPages
{
    public partial class AdminCustomerPanelV1 : System.Web.UI.Page
    {
        ICustomerService _customerService;
        public AdminCustomerPanelV1()
        {
            _customerService = InstanceFactory.GetInstance<ICustomerService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAll();
        }

        public void GetAll()
        {
            GridView1.DataSource = _customerService.GetAll().Data;
            GridView1.DataBind();
        }
        protected void LnkBtn_Update_Command(object sender, CommandEventArgs e)
        {
            var customerId = Convert.ToInt32(e.CommandArgument);
            var customerToUpdate = _customerService.GetById(customerId).Data;

            tbx_UpdateId.Text = Convert.ToString(customerToUpdate.Id);
            tbx_UpdateUserId.Text = Convert.ToString(customerToUpdate.UserId);
            tbx_UpdateFirstName.Text = Convert.ToString(customerToUpdate.FirstName);
            tbx_UpdateLastName.Text = Convert.ToString(customerToUpdate.LastName);
            tbx_UpdateAddress.Text = Convert.ToString(customerToUpdate.Address);
            tbx_UpdateCity.Text = Convert.ToString(customerToUpdate.City);
            tbx_UpdatePhone.Text = Convert.ToString(customerToUpdate.Phone);

            GetAll();
        }

        protected void LnkBtn_Delete_Command(object sender, CommandEventArgs e)
        {
            var customerId = Convert.ToInt32(e.CommandArgument);
            var customerToDelete = _customerService.GetById(customerId).Data;

            _customerService.Delete(customerToDelete);
            GetAll();
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.Id = Convert.ToInt32(tbx_UpdateId.Text);
            customer.UserId = Convert.ToInt32(tbx_UpdateUserId.Text);
            customer.FirstName = tbx_UpdateFirstName.Text;
            customer.LastName = tbx_UpdateLastName.Text;
            customer.Address = tbx_UpdateAddress.Text;
            customer.City = tbx_UpdateCity.Text;
            customer.Phone = tbx_UpdatePhone.Text;

            _customerService.Update(customer);
            GetAll();
        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();

            customer.UserId = Convert.ToInt32(tbx_AddUserId.Text);
            customer.FirstName = tbx_AddFirstName.Text;
            customer.LastName = tbx_AddLastName.Text;
            customer.Address = tbx_AddAddress.Text;
            customer.City = tbx_AddCity.Text;
            customer.Phone = tbx_AddPhone.Text;

            _customerService.Add(customer);
            GetAll();
        }
    }
}