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

        private static string GetAuthorities(UserAuthoritiesDto userAuthoritiesDto)
        {
            string result = "";

            foreach (var authorityDto in userAuthoritiesDto.Authorities)
            {
                result += authorityDto.AuthorityName;
            }

            return result;
        }

        private void CheckAuthority(string result)
        {
            if (!result.Contains("Admin"))
            {
                Response.Redirect("~/WebPage");
            }
        }
    }
}