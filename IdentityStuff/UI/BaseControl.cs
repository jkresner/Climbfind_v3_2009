using System;
using System.Web.Security;
using IdentityStuff.UI;
using ClimbFind.Model.DataAccess;

namespace ClimbFind.Web.UI
{
    public class BaseControl : System.Web.UI.UserControl
    {
        public bool UserLoggedIn { get { return Page.User.Identity.IsAuthenticated; } }
        public MembershipUser CFUser { get { return Membership.GetUser(); } }
        public Guid UserID { get { return CFProfile.UserID; } }
        

        protected void RedirectTo(string uri)
        {
            Response.Redirect(uri, false);
        }

    }
}
