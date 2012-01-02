using System.Security.Principal;
using System.Web;
using ClimbFind.Controller;
using ClimbFind.Model.Objects;

namespace IdentityStuff.Controllers.ActionFilters
{
    public class ProfileCompleteActionFilter : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            IIdentity user = HttpContext.Current.User.Identity;
            if (user.IsAuthenticated)
            {
                ClimberProfile profile = new CFController().GetClimberProfileByEmail(user.Name);
                if (profile.IsUnfinished) 
                { 
                    HttpContext.Current.Response.Redirect("/ClimberProfiles/Me", false); 
                    filterContext.Cancel = true;                
                }
            }
        }
    }
}
