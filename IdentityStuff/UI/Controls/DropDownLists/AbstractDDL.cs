using System;
using System.Web.Security;
using ClimbFind.Controller;
using ClimbFind.Model.Objects;

namespace ClimbFind.Web.UI.Controls.DropDownLists
{
    public abstract class AbstractDDL : System.Web.UI.WebControls.DropDownList
    {
        public bool UserLoggedIn { get { return Page.User.Identity.IsAuthenticated; } }
        public MembershipUser CFUser { get { return Membership.GetUser(); } }
        public Guid UserID { get { return new Guid(CFUser.ProviderUserKey.ToString()); } }
        public UserSettings UsersSearchSettings
        {
            get
            { return new CFController().GetUserSearchSettings(UserID); }
        }
  
        protected void RedirectTo(string uri)
        {
            Page.Response.Redirect(uri, false);
        }
    }
}
