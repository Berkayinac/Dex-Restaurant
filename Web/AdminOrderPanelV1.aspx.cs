using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class AdminOrderPanelV1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetAll();
        }

        public void GetAll()
        {
            GridView1.DataSource = _orderService.GetAll().Data;
            GridView1.DataBind();
        }

        IOrderService _orderService = new OrderManager();

        protected void LnkBtn_Update_Command(object sender, CommandEventArgs e)
        {
            var orderId = Convert.ToInt32(e.CommandArgument);
            var orderToUpdate = _orderService.GetById(orderId).Data;

            tbx_UpdateId.Text = Convert.ToString(orderToUpdate.Id);
            tbx_UpdateProductId.Text = Convert.ToString(orderToUpdate.ProductId);
            tbx_UpdateCustomerID.Text = Convert.ToString(orderToUpdate.CustomerID);

            GetAll();
        }

        protected void LnkBtn_Delete_Command(object sender, CommandEventArgs e)
        {
            var orderId = Convert.ToInt32(e.CommandArgument);
            var orderToDelete = _orderService.GetById(orderId).Data;

            Delete(orderToDelete);

            GetAll();
        }

        public void Delete(Order order)
        {
            _orderService.Delete(order);
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.Id = Convert.ToInt32(tbx_UpdateId.Text);
            order.ProductId = Convert.ToInt32(tbx_UpdateProductId.Text);
            order.CustomerID = Convert.ToInt32(tbx_UpdateCustomerID.Text);

            _orderService.Update(order);
            GetAll();
        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            Order order = new Order();

            order.ProductId = Convert.ToInt32(tbx_AddProductId.Text);
            order.CustomerID = Convert.ToInt32(tbx_AddCustomerID.Text);

            _orderService.Add(order);
            GetAll();
        }
    }
}