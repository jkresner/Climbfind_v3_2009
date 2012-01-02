using System;
using System.Web.Security;
using System.Web.Profile;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace ClimbFind.Model.DataAccess
{
    public static class CFProfile
    {
        public static Guid UserID { get { return _wrapper.UserID; } set { _wrapper.UserID = value; } }

        public static bool UserIsKrez { get { return (_wrapper.UserID == new Guid("a9646cc3-18cb-4a62-8402-5263ba8b3476")); } }

        private static ProfileWrapper _wrapper
        {
            get
            {
                ProfileWrapper currentWrapper = (ProfileWrapper)HttpContext.Current.Items["CachedCFProfile"];

                if (currentWrapper == null)
                {
                    currentWrapper = new ProfileWrapper();
                    HttpContext.Current.Items["CachedCFProfile"] = currentWrapper;
                }

                return (currentWrapper);
            }
        }

        //------------------------------------------------------------------------//
        //- direct wrapper for the ProfileCommon class ---------------------------//
        //------------------------------------------------------------------------//

        private class ProfileWrapper
        {
            private Guid _cachedUserId = Guid.Empty;
            public bool IsAuthenticated { get { return HttpContext.Current.User.Identity.IsAuthenticated; } }

            public Guid UserID
            {
                get
                {
                    if (_cachedUserId.Equals(Guid.Empty) && IsAuthenticated)
                    {
                        _cachedUserId = new Guid(Membership.GetUser().ProviderUserKey.ToString());
                    }

                    return (_cachedUserId);
                }
                set
                {
                    _cachedUserId = value;
                }
            }
        }

    }
}
