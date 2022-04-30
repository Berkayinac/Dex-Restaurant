using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Web
{
    public class Global : System.Web.HttpApplication
    {

        void RouteUser(RouteCollection route)
        {
            route.MapPageRoute("Giriş", "Login/Login", "~/UserLRP/Login/Login.aspx");
            route.MapPageRoute("Kayıt", "Register/Register", "~/UserLRP/Register/Register.aspx");
            route.MapPageRoute("Şifremi Hatırlat", "PasswordReminder/PasswordReminder", "~/UserLRP/PasswordReminder/PasswordReminder.aspx");
            route.MapPageRoute("Güvenlik Sorusu ile email", "PasswordReminder/Question/{Email}", "~/UserLRP/PasswordReminder/Question.aspx");
            route.MapPageRoute("Güvenlik Sorusu", "PasswordReminder/Question", "~/UserLRP/PasswordReminder/Question.aspx");
            route.MapPageRoute("Şifremi Değiştir", "PasswordReminder/PasswordChange", "~/UserLRP/PasswordReminder/PasswordChange.aspx");

            // Admin
            route.MapPageRoute("Product","Admin/Product", "~/AdminPages/AdminProductPanelV1.aspx");
            route.MapPageRoute("Category", "Admin/Category", "~/AdminPages/AdminCategoryPanelV1.aspx");
            route.MapPageRoute("Customer", "Admin/Customer", "~/AdminPages/AdminCustomerPanelV1.aspx");
            route.MapPageRoute("Dashboard", "Admin/Dashboard", "~/AdminPages/AdminDashboard.aspx");
            route.MapPageRoute("Order", "Admin/Order", "~/AdminPages/AdminOrderPanelV1.aspx");
            route.MapPageRoute("Authority", "Admin/Authority", "~/AdminPages/AdminAuthorityPanelV1.aspx");
            route.MapPageRoute("User", "Admin/User", "~/AdminPages/AdminUserPanelV1.aspx");
            route.MapPageRoute("UserAuthority", "Admin/UserAuthority", "~/AdminPages/AdminUserAuthorityPanelV1.aspx");
            route.MapPageRoute("AdminUserWebPage", "AdminWebPage", "~/AdminControlWebPage.aspx");

            // User
            route.MapPageRoute("UserWebPage", "WebPage", "~/WebPage.aspx");
            route.MapPageRoute("UserCart", "Cart", "~/UserCart/UserCartWebPage.aspx");
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteUser(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session.Timeout = 10;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}