using Business.Abstract;
using Business.Concrete;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class AdminAuthorityPanelV1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetAll();
        }

        public void GetAll()
        {
            GridView1.DataSource = _authorityService.GetAll().Data;
            GridView1.DataBind();
        }

        IAuthorityService _authorityService = new AuthorityManager();

        protected void LnkBtn_Update_Command(object sender, CommandEventArgs e)
        {
            var authorityId = Convert.ToInt32(e.CommandArgument);
            var authorityToUpdate = _authorityService.GetById(authorityId).Data;

            tbx_UpdateId.Text = Convert.ToString(authorityToUpdate.Id);
            tbx_UpdateName.Text = Convert.ToString(authorityToUpdate.Name);

            GetAll();
        }

        protected void LnkBtn_Delete_Command(object sender, CommandEventArgs e)
        {
            var authorityId = Convert.ToInt32(e.CommandArgument);
            var authorityToUpdate = _authorityService.GetById(authorityId).Data;

            Delete(authorityToUpdate);

            GetAll();
        }

        public void Delete(Authority authority)
        {
            _authorityService.Delete(authority);
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            Authority authority = new Authority();
            authority.Id = Convert.ToInt32(tbx_UpdateId.Text);
            authority.Name = tbx_UpdateName.Text;

            _authorityService.Update(authority);
            GetAll();
        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            Authority authority = new Authority();
            authority.Name = tbx_AddName.Text;

            _authorityService.Add(authority);
            GetAll();
        }
    }
}