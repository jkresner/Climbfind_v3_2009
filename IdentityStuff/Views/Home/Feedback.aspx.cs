using System;
using System.Collections.Generic;
using ClimbFind.Controller;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Controllers;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;

namespace IdentityStuff.Views.Home
{
    public partial class Feedback : ClimbFindViewPage<ISessionViewData>
    {
        public List<ClimbFind.Model.Objects.Feedback> SiteFeedback { get; set; }
        public ClimberProfile CurentUserProfile { get; set; }

        public int i = 0;

        protected void Page_Init(Object sender, EventArgs e)
        {
            SiteFeedback = CFLogger.GetPublishedFeedback();
        }
        
        protected void Page_Load(Object sender, EventArgs e)
        {

            if (UserLoggedIn)
            {
                CurentUserProfile = cfController.GetClimberProfile(UserID);

                if (CurentUserProfile.IsUnfinished)
                {
                    LeaveFeedbackMV.SetActiveView(VIEWFinishYourProfile);
                }
                else
                {
                    LeaveFeedbackMV.SetActiveView(ViewLeaveFeedback);
                }
            }
            else
            {
                LeaveFeedbackMV.SetActiveView(VIEWLoginOrRegister);
            }
            

        }

        protected void PostFeedback_Click(Object sender, EventArgs e)
        {
            if (PeterBlum.VAM.Globals.Page.IsValid)
            {
                CFLogger.SaveFeedback(UserID, CommentTxB.Text);
               
                RedirectToThankYouPage("Your feedback has been left", 
                    ResolveLinkTo<HomeController>(c=>c.Feedback()));
            }
        }
    
    }
}
