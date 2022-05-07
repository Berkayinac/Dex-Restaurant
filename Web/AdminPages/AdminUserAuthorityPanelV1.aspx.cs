using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Ninject;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.AdminPages
{
    public partial class AdminUserAuthorityPanelV1 : System.Web.UI.Page
    {
        IUserAuthorityService _userAuthorityService;
        public AdminUserAuthorityPanelV1()
        {
            _userAuthorityService = InstanceFactory.GetInstance<IUserAuthorityService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAll();
        }

        public void GetAll()
        {
            GridView1.DataSource = _userAuthorityService.GetAll().Data;
            GridView1.DataBind();
        }
        protected void LnkBtn_Update_Command(object sender, CommandEventArgs e)
        {
            var userAuthorityId = Convert.ToInt32(e.CommandArgument);
            var userAuthorityToUpdate = _userAuthorityService.GetById(userAuthorityId).Data;

            tbx_UpdateId.Text = Convert.ToString(userAuthorityToUpdate.Id);
            tbx_UpdateUserId.Text = Convert.ToString(userAuthorityToUpdate.UserId);
            tbx_UpdateAuthorityId.Text = Convert.ToString(userAuthorityToUpdate.AuthorityId);

            GetAll();
        }

        protected void LnkBtn_Delete_Command(object sender, CommandEventArgs e)
        {
            var userAuthorityId = Convert.ToInt32(e.CommandArgument);
            var userAuthorityToDelete = _userAuthorityService.GetById(userAuthorityId).Data;

            Delete(userAuthorityToDelete);

            GetAll();
        }

        public void Delete(UserAuthority userAuthority)
        {
            _userAuthorityService.Delete(userAuthority);
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            UserAuthority userAuthority = new UserAuthority();
            userAuthority.Id = Convert.ToInt32(tbx_UpdateId.Text);
            userAuthority.UserId = Convert.ToInt32(tbx_UpdateUserId.Text);
            userAuthority.AuthorityId = Convert.ToInt32(tbx_UpdateAuthorityId.Text);

            _userAuthorityService.Update(userAuthority);
            GetAll();
        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            UserAuthority userAuthority = new UserAuthority();

            userAuthority.UserId = Convert.ToInt32(tbx_AddUserId.Text);
            userAuthority.AuthorityId = Convert.ToInt32(tbx_AddAuthorityId.Text);

            _userAuthorityService.Add(userAuthority);
            GetAll();
        }
    }
}