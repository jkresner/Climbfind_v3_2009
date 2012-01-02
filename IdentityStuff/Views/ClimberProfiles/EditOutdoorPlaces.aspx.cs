using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Controllers;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;
using ClimbFind.Model.Enum;

namespace ClimbFind.Web.Mvc.Views.ClimberProfiles
{
    public partial class EditOutdoorPlaces : ClimbFindViewPage<ClimberProfileViewData>
    {        
        protected ClimberProfile climberProfile;
        protected List<Place> allPlaces;
        protected List<int> placesUserClimbsIDs;

        protected void Page_Init(object sender, EventArgs e)
        {           
            climberProfile = cfController.GetClimberProfile(UserID);

            climberProfile.PlacesUserClimbs = cfController.GetPlacesUserClimbs(UserID);
            allPlaces = CFDataCache.AllPlaces;
            placesUserClimbsIDs = climberProfile.PlacesUserClimbs.Select(c => c.ID).ToList();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            short countryID = 245;

            if (CurrentClimber.Nationality.HasValue)
            {
                if (CurrentClimber.Nationality == (short)Nation.UnitedKingdom)
                {
                    countryID = (short)Nation.England;
                }
                else
                {
                    countryID = CurrentClimber.Nationality.Value;
                }
            }

            List<Place> homePlaces = (from c in allPlaces where c.CountryID == countryID && !c.IsIndoor orderby c.CountryID descending, c.Name select c).ToList();
            List<Place> otherPlaces = (from c in allPlaces where c.CountryID != countryID && !c.IsIndoor orderby c.CountryID descending, c.Name select c).ToList();
            List<Place> outdoorPlaces = homePlaces;
            outdoorPlaces.AddRange(otherPlaces);
            
            OutdoorPlacesUserClimbsLV.DataSource = outdoorPlaces;

            DataBind();
        }

        protected void UpdateClimberProfile_Click(object sender, EventArgs e)
        {
            if (PeterBlum.VAM.Globals.Page.IsValid)
            {
                List<int> indoorPlaces = (from c in climberProfile.PlacesUserClimbs where c.IsIndoor select c.ID).ToList();

                List<int> allNewPlaceIDs = GetSelectedPlacesUserClimbsAt();
                allNewPlaceIDs.AddRange(indoorPlaces);

                cfController.SavePlacesUserClimbsAt(UserID, allNewPlaceIDs);
            }

            RedirectTo<ClimberProfilesController>(c => c.Me());
        }

        protected bool CheckIfUserAlreadyClimbsAt(int placeID)
        {
            return placesUserClimbsIDs.Contains(placeID);
        }


        private List<int> GetSelectedPlacesUserClimbsAt()
        {
            List<int> pids = new List<int>();
            foreach (ListViewDataItem item in OutdoorPlacesUserClimbsLV.Items)
            {
                HtmlInputCheckBox pidCB = item.FindControl("PID") as HtmlInputCheckBox;
                if (pidCB.Checked)
                {
                    pids.Add(int.Parse(pidCB.Value));
                }
            }
            return pids;
        }

    }
}
