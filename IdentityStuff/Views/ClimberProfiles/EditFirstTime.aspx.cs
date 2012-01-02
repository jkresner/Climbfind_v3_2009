using System;
using System.Collections.Generic;
using ClimbFind.Model.Enum;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Controllers;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;

namespace ClimbFind.Web.Mvc.Views.ClimberProfiles
{
    public partial class EditFirstTime : ClimbFindViewPage<ClimberProfileViewData>
    {        
        protected ClimberProfile climberProfile;
        protected MessageBoard messageBoard;
        protected List<Place> allPlaces;
        protected List<int> placesUserClimbsIDs;


        protected void Page_Init(object sender, EventArgs e)
        {           
            climberProfile = cfController.GetClimberProfile(UserID);

            //climberProfile.PlacesUserClimbs = cfController.GetPlacesUserClimbs(UserID);
            messageBoard = cfController.GetMessageBoard(climberProfile.MessageBoardID);
            //allPlaces = CFDataCache.AllPlaces;
            //placesUserClimbsIDs = climberProfile.PlacesUserClimbs.Select(c => c.ID).ToList();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) { SetToUpdateClimberProfile_Click(sender, e); }

            //List<Place> indoorPlaces = (from c in allPlaces where c.IsIndoor orderby c.CountryID descending, c.Name select c).ToList();
            //IndoorPlacesUserClimbsLV.DataSource = indoorPlaces;

            //List<Place> outdoorPlaces = (from c in allPlaces where !c.IsIndoor orderby c.CountryID descending, c.Name select c).ToList();
            //OutdoorPlacesUserClimbsLV.DataSource = outdoorPlaces;

            //List<Place> ukIndoorPlaces = (from c in allPlaces where c.CountryID == (short)Nation.UnitedKingdom &&  orderby c.Name select c).ToList();
            //List<Place> ausPlaces = (from c in allPlaces where c.CountryID == (short)Nation.Australia orderby c.Name select c).ToList();

            //List<Place> ukIndoorPlaces = (from c in ukPlaces where c.IsIndoor select c).ToString();
            //ukPlaces.AddRange(ausPlaces);

            //IndoorPlacesUserClimbsLV.DataSource = (from c in ukPlaces where c.IsIndoor select c).ToString();
            //PlacesUserClimbsLV.DataSource = ukPlaces;
            
            DataBind();
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

               // cfController.SavePlacesUserClimbsAt(climberProfile.ID, GetSelectedPlacesUserClimbsAt());
            }

            RedirectTo<ClimberProfilesController>(c=>c.EditPartnerStatus());
        }

        //protected bool CheckIfUserAlreadyClimbsAt(int placeID)
        //{
        //    return placesUserClimbsIDs.Contains(placeID);
        //}

        //private List<int> GetSelectedPlacesUserClimbsAt()
        //{
        //    List<int> pids = new List<int>();
        //    foreach (ListViewDataItem item in IndoorPlacesUserClimbsLV.Items)
        //    {
        //        HtmlInputCheckBox pidCB = item.FindControl("PID") as HtmlInputCheckBox;
        //        if (pidCB.Checked)
        //        {
        //            pids.Add(int.Parse(pidCB.Value));
        //        }
        //    }
        //    foreach (ListViewDataItem item in OutdoorPlacesUserClimbsLV.Items)
        //    {
        //        HtmlInputCheckBox pidCB = item.FindControl("PID") as HtmlInputCheckBox;
        //        if (pidCB.Checked)
        //        {
        //            pids.Add(int.Parse(pidCB.Value));
        //        }
        //    }
        //    return pids;
        //}

    }
}
