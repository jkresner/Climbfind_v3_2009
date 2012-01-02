using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;
using ClimbFind.Model.Objects;

namespace IdentityStuff.Views.ClimberProfiles
{
    public partial class AllWhatILike : ClimbFindViewPage<ISessionViewData>
    {
        public List<ClimberProfileExtended> AllLikeExtendedProfiles;

        protected void Page_Load(Object src, EventArgs e)
        {
            AllLikeExtendedProfiles = cfController.GetExtendedProfilesWithLike();
        }
    }
}
