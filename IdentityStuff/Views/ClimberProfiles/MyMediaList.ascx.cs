using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClimbFind.Model.Objects;
using System.Web.Security;

namespace IdentityStuff.Views.ClimberProfiles
{
    public partial class MyMediaList : System.Web.Mvc.ViewUserControl<List<MediaShare>>
    {
        public List<MediaShare> Media { get { return ViewData.Model; } }
        public MembershipUser CFUser { get { return Membership.GetUser(); } }
        public bool UserLoggedIn { get { return HttpContext.Current.User.Identity.IsAuthenticated; } }
        public Guid UserID { get { return new Guid(CFUser.ProviderUserKey.ToString()); } }


        protected bool UserOwnsMedia(MediaShare media)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated) { return false; }
            else { return UserID == media.SubmittedByUserID; }
        }
    }
}
