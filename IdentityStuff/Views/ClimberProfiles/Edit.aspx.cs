using System;
using ClimbFind.Model.Enum;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Controllers;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;
using ClimbFind.Model.DataAccess;

namespace ClimbFind.Web.Mvc.Views.ClimberProfiles
{
    public partial class Edit : ClimbFindViewPage<ClimberProfileViewData>
    {        
        protected ClimberProfile climberProfile;
        protected MessageBoard messageBoard;


        protected void Page_Init(object sender, EventArgs e)
        {           
            climberProfile = cfController.GetClimberProfile(UserID);

            climberProfile.PlacesUserClimbs = cfController.GetPlacesUserClimbs(UserID);
            messageBoard = cfController.GetMessageBoard(climberProfile.MessageBoardID);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) 
            { 
                SetToUpdateClimberProfile_Click(sender, e); 
            }
        }


        protected void SetToUpdateClimberProfile_Click(object sender, EventArgs e)
        {
            FullNameTxB.Text = climberProfile.FullName;
            NickNameTxB.Text = climberProfile.NickName;
            NationalityDDLUC.Bind((Nation)climberProfile.Nationality);

            //-- TODO: Some really crap code..
            if (!String.IsNullOrEmpty(climberProfile.ClimbingLevel))
            {
                int selectedIndex = 0;
                if (climberProfile.ClimbingLevel == "Intermediate") { selectedIndex = 1; }
                if (climberProfile.ClimbingLevel == "Confident") { selectedIndex = 2; }
                if (climberProfile.ClimbingLevel == "Advanced") { selectedIndex = 3; }

                ClimbingLevelDDL.SelectedIndex = selectedIndex;
            }

            if (climberProfile.IsMale == true) { IsMaleRB.Checked = true; }
            else if (climberProfile.IsMale == false) { IsFemaleRB.Checked = true; }

            ContactNumberTxB.Text = climberProfile.ContactNumber;         

            if (messageBoard.IsVisible) { ShowMessageBoardRB.Checked = true; }
            else { HideMessageBoardRB.Checked = true; }

         }


        protected void UpdateClimberProfile_Click(object sender, EventArgs e)
        {
            if (PeterBlum.VAM.Globals.Page.IsValid)
            {
                cfController.SaveClimberProfile(climberProfile, FullNameTxB.Text, NickNameTxB.Text, IsMaleRB.Checked,
                    NationalityDDLUC.SelectedNation, ClimbingLevelDDL.SelectedItem.Value,
                    ContactNumberTxB.Text, ShowMessageBoardRB.Checked);
            }

            RedirectTo<ClimberProfilesController>(c=>c.Me());
        }

    }
}
