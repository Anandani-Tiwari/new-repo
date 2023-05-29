using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace EFDBFirstApproachExample.Filters
{
    public class AdminAuthorization:FilterAttribute,IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filtercontext)
        {
            if (filtercontext.HttpContext.User.IsInRole("Admin") == false)
            {
                filtercontext.Result = new HttpUnauthorizedResult();
            }
        }

    }
}