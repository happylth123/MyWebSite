using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GoBear.TimeTracking.Web.App_Start
{
    public class WebAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (base.AuthorizeCore(httpContext))
            {
                var cookie = httpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (cookie != null)
                {
                    string cacheKey = cookie.Value;
                    var authorCache = httpContext.Cache.Get(cacheKey);
                    if (authorCache == null)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}