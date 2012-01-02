using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Objects;
using ClimbFind.Web.UI;
using ClimbFind.Controller;
using ClimbFind.Web.Mvc.Controllers;

namespace IdentityStuff.Views.PartnerCalls
{
    public partial class Subscribe : ClimbFindViewPage<Place>
    {
        public int i=1;
        public Place place { get { return ViewData.Model; } }
        public PartnerCallSubscription subscriptions;
        
        protected void Page_Init(Object s, EventArgs e)
        {
            if (UserLoggedIn)
            {
                subscriptions = cfController.GetPartnerCallSubscription(UserID, place.ID);

                if (subscriptions.RSS) { SubcsribeRSSMV.SetActiveView(VIEWSubscribedToRSS); }
                if (subscriptions.Email) { SubcsribeEmailMV.SetActiveView(VIEWSubscribedToEmail); }
            }
        }

        protected void SubscribeToRSS_Click(Object s, EventArgs e)
        {
            cfController.SubscribeToPartnerCallsByRSS(UserID, place.ID);
            SubcsribeRSSMV.SetActiveView(VIEWSubscribedToRSS);
        }

        protected void SubscribeToEmail_Click(Object s, EventArgs e)
        {
            ClimberProfile cp = cfController.GetClimberProfile(UserID);
            if (!cp.EmailVerified) { RedirectTo<ClimberProfilesController>(c=>c.VerifyEmailAddress(Guid.Empty)); }
            else
            {
                cfController.SubscribeToPartnerCallsByEmail(UserID, place.ID);
                SubcsribeEmailMV.SetActiveView(VIEWSubscribedToEmail);
            }
        }

        protected void UnSubscribeToEmail_Click(Object s, EventArgs e)
        {
            cfController.UnSubscribeToPartnerCallsByEmail(UserID, place.ID);
            SubcsribeEmailMV.SetActiveView(VIEWSubscribeToEmail);
        }


        protected void UnSubscribeToRSS_Click(Object s, EventArgs e)
        {
            cfController.UnSubscribeToPartnerCallsByRSS(UserID, place.ID);
            SubcsribeRSSMV.SetActiveView(VIEWSubscribeToRSS);
        }    

    }

}
