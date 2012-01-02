using System.Security.Principal;
using System.Web;

namespace IdentityStuff.Controllers.ActionFilters
{
    public class LoginFilter : System.Web.Mvc.ActionFilterAttribute
    {
        public string LoginMessage { get; set; }

        public override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            IIdentity user = HttpContext.Current.User.Identity;

            if (!user.IsAuthenticated)
            {
                string returnUrl = HttpUtility.UrlEncode( HttpContext.Current.Request.Url.ToString() );

                HttpContext.Current.Response.Redirect(string.Format("/Login/{0}?returnUrl={1}", LoginMessage, returnUrl), false);
            
                filterContext.Cancel = true;
            } 
        }
    }
}
