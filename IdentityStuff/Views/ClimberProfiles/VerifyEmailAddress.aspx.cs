using System;
using ClimbFind.Model.Objects;
using ClimbFind.Web.UI;
using IdentityStuff.Models.ViewData;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Mail;
using System.Collections.Generic;

namespace IdentityStuff.Views.ClimberProfiles
{
    public partial class VerifyEmailAddress : ClimbFindViewPage<ISessionViewData>
    {
        public ClimberProfile cp;

        public void Page_Load(Object o, EventArgs e)
        {
            cp = cfController.GetClimberProfile(UserID);

            if (cp.EmailVerified)
            {
                VerifyEmailMV.SetActiveView(VIEWVerifySuccess);
            }
            else
            {
                VerifyEmailMV.SetActiveView(VIEWWhyVerify);
            }
        }


        public void SendVerifyEmail_Click(Object o, EventArgs e)
        {
            cfController.SendVerifyEmailAddressEmail(cp);
                       
            VerifyEmailMV.SetActiveView(VIEWVeifyEmailSent);
        }

        
    }
}
