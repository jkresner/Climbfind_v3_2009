using System;
using System.Collections.Generic;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;

namespace ClimbFind.Web.Mvc.Views.ClimberProfiles
{
    public partial class EditPartnerStatus : ClimbFindViewPage<ClimberProfileViewData>
    {        
        protected ClimberProfile climberProfile;
        protected List<ClimberProfilePartnerStatus> allStatus;

        protected void Page_Init(object sender, EventArgs e)
        {           
            climberProfile = cfController.GetClimberProfile(UserID);
            allStatus = CFDataCache.AllPartnerStatus;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected string SelectRB(byte value)
        {
            if (value == climberProfile.PartnerStatusID) { return "checked=\"checked\""; }
            else { return ""; }
        }
    }
}
