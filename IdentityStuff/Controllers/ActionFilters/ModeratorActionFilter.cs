using System.Security.Principal;
using System.Web;
using ClimbFind.Controller;
using ClimbFind.Model.Objects;

namespace IdentityStuff.Controllers.ActionFilters
{
    public class ModeratorActionFilter : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            IIdentity user = HttpContext.Current.User.Identity;
            ClimberProfile cp = new CFController().GetClimberProfileByEmail(user.Name.ToString());
            
            if (!cp.IsModerator)
            {
                filterContext.Cancel = true;
                HttpContext.Current.Response.Redirect("/Moderate/UnauthorizedAccess", false); 
            }
        }
    }
}
