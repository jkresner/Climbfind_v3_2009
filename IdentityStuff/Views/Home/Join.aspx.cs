using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClimbFind.Controller;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;
using ClimbFind.Web.UI.Controls.DropDownLists;
using ClimbFind.Web.Mvc.Controllers;

namespace IdentityStuff.Views.Home
{
    public partial class Join : ClimbFindViewPage<ISessionViewData>
    {
        public Control CreateUserWizardControls { get { return RegisterUserUC.WizardSteps[0].Controls[0]; } }

        protected void Page_Init(Object s, EventArgs e)
        {
            if (UserLoggedIn) { RedirectTo<HomeController>(c => c.Index()); }
            else { Response.Redirect("https://accounts.climbfind.com/signin", false); }
        } 


        protected void SetUserNameToEmailAddres(object sender, EventArgs e)
        {
            (CreateUserWizardControls.FindControl("Email") as TextBox).Text =
                (CreateUserWizardControls.FindControl("UserName") as TextBox).Text;
        }

        protected void RedirectToProfilePage(object sender, EventArgs e)
        {
            MembershipUser CFUser = Membership.GetUser(RegisterUserUC.UserName);
            Guid userID = new Guid(CFUser.ProviderUserKey.ToString());

            cfController.CreateClimberProfile(userID, RegisterUserUC.UserName,
                (CreateUserWizardControls.FindControl("FullNameTxB") as TextBox).Text,
                (CreateUserWizardControls.FindControl("NickNameTxB") as TextBox).Text,
                (CreateUserWizardControls.FindControl("IsMaleRB") as CheckBox).Checked,
                (CreateUserWizardControls.FindControl("NationalityDDLUC") as NationalityDDL).SelectedNation, "Unknown");

            CFLogger.RecordRegistrationOnJoinPage(userID, CFUser.Email,
                (CreateUserWizardControls.FindControl("FullNameTxB") as TextBox).Text);

            //-- TODO: fix this static string
            RedirectTo<CFFeedController>(c => c.FirstPost());
        }
    }
}
