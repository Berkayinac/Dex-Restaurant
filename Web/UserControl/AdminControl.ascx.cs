using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Ninject;
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
    public partial class AdminControl : UserAuthoritiesCheck
    {
        IAuthService _authService;
        public AdminControl()
        {
            _authService = InstanceFactory.GetInstance<IAuthService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IsNullAuthorities();

            var userAuthorities = (UserAuthoritiesDto)HttpContext.Current.Session["UserAuthorities"];

            UserIsNotAdmin(userAuthorities);

            AdminRedirectToPanel();
        }

        private void AdminRedirectToPanel()
        {
            var href = "<a href=";
            var myLink = "'/Admin/Dashboard'" + " ";
            var myCssClass = "class=" + "'book-a-table-btn scrollto d-none d-lg-flex'>";
            var myName = "Admin";
            var hrefclose = "</a>";
            myLiteral.Text = href + myLink + myCssClass + myName + hrefclose;
        }
    }
}