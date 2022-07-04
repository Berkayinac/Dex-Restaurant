using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.UserControl
{
    public partial class UserAuthoritiesCheck : System.Web.UI.UserControl
    {
        protected void UserAuthorityRoute(List<AuthorityDto> authoritiesDto)
        {
            foreach (var authorityDto in authoritiesDto)
            {
                if (authorityDto.AuthorityName == "Admin")
                {
                    Response.Redirect("~/AdminWebPage");
                }
            }
            Response.Redirect("~/WebPage");
        }

        protected void UserIsNotAdmin(UserAuthoritiesDto userAuthoritiesDto)
        {
            string result = GetAuthorities(userAuthoritiesDto);
            CheckAuthority(result);
        }

        protected static string GetAuthorities(UserAuthoritiesDto userAuthoritiesDto)
        {
            string result = "";

            foreach (var authorityDto in userAuthoritiesDto.Authorities)
            {
                result += authorityDto.AuthorityName;
            }

            return result;
        }

        protected void CheckAuthority(string result)
        {
            if (!result.Contains("Admin"))
            {
                Response.Redirect("~/WebPage");
            }
        }

        protected void IsNullAuthorities()
        {
            if ((UserAuthoritiesDto)HttpContext.Current.Session["UserAuthorities"] == null)
            {
                Response.Redirect("~/WebPage");
            }
        }

        protected void CheckUserAuthorities()
        {
            if (!HttpContext.Current.Session["Authorities"].ToString().Contains("Admin"))
            {
                Response.Redirect("/WebPage");
            }
        }

        protected void UserNotFound()
        {
            if (HttpContext.Current.Session["UserId"] != null)
            {
                Response.Redirect("~/Login");
            }
        }
    }
}