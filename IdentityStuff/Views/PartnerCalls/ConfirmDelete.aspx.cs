using System;
using System.Collections.Generic;
using ClimbFind.Controller;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;
using ClimbFind.Web.Mvc.Controllers;

namespace IdentityStuff.Views.PartnerCalls
{
    public partial class ConfirmDelete : ClimbFindViewPage<PartnerCall>
    {
        public PartnerCall Current { get { return ViewData.Model; } }
        
        protected void Page_Init(Object src, EventArgs e)
        {
        }

        protected void Delete_Click(Object src, EventArgs e)
        {
            if (PeterBlum.VAM.Globals.Page.IsValid)
            {
                string reason = "";

                if (ReasonNoLongerRB.Checked) { reason = "Dont need partner there anymore"; }
                if (ReasonNotClimbingRB.Checked) { reason = "No longer climbing"; }
                if (ReasonWantToRepostRB.Checked) { reason = "Want to repost"; }
                if (ReasonCreepyPersonRB.Checked) { reason = "Creepy contact"; }
                if (ReasonOtherRB.Checked) { reason = "Other"; }

                new CFController().DeletePartnerCallByUserAndSaveSurvery(Current, reason, NumberOfPeopleTxB.IntegerValueOrZero);
      
                RedirectTo<ClimberProfilesController>(c=>c.Me());
            }
        }
    }
}



