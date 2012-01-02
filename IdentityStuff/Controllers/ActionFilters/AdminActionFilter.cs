using System;
using System.Security.Principal;
using System.Web;

namespace IdentityStuff.Controllers.ActionFilters
{
    public class AdminActionFilter : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            IIdentity user = HttpContext.Current.User.Identity;
            if (user.Name != "jkresner@yahoo.com.au")
            {
                filterContext.Cancel = true;
                throw new Exception("Unauthorized access to admin controller.");
            }
        }
    }
}
