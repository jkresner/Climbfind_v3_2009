using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Controllers;
using ClimbFind.Web.UI;

namespace IdentityStuff.Views.Moderate
{
    public partial class EditOutdoorLocation : ClimbFindViewPage<OutdoorPlace>
    {
        public OutdoorPlace place { get { return ViewData.Model; } }
        public List<AreaTag> AreaTags { get; set; }

        protected void Page_Init(Object sender, EventArgs e)
        {
            AreaTags = cfController.GetAreaTagsForAPlace(place.ID);
            AreaTxB.Country = (ClimbFind.Model.Enum.Nation)place.CountryID;
        }
        
        protected void Page_Load(Object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                NameLb.Text = place.Name;
                DescriptionTxB.Text = place.Description;
                AccommodationTxB.Text = place.Accomodation;
                FoodTxB.Text = place.Food;
                LocalBetaTxB.Text = place.Food;
                DirectionsTxB.Text = place.Directions;
                ShortNameTxB.Text = place.ShortName;
                LatitudeTxB.DoubleValue = (double)place.Latitude;
                LongitudeTxB.DoubleValue = (double)place.Longitude;
            }
            BindAreaTags();
        }

        protected void UpdatePlace_Click(Object sender, EventArgs e)
        {
            string shortName = place.ShortName;
            if (UserIsModerator) { shortName = ShortNameTxB.Text; }
            
            if (PeterBlum.VAM.Globals.Page.IsValid)
            {
                //-- Validate country is not unknown or UK
                place.ShortName = shortName;
                place.Description = DescriptionTxB.Text;
                place.Accomodation = AccommodationTxB.Text;
                place.Food = FoodTxB.Text;
                place.LocalBeta = LocalBetaTxB.Text;
                place.Directions = DirectionsTxB.Text;
                place.Latitude = (decimal)LatitudeTxB.DoubleValue;
                place.Longitude = (decimal)LongitudeTxB.DoubleValue;

                cfController.UpdateOutdoorPlace(place);

                RedirectTo<PlacesController>(c => c.DetailOutdoor(place.FriendlyUrlLocation, place.FriendlyUrlName));
            }
        }

        protected void AddAreaTag_Click(Object sender, EventArgs e)
        {
            cfController.AddPlaceAreaTag(place.ID, AreaTxB.SelectedAreaTagID);
            AreaTxB.Clear();
            BindAreaTags();
        }

        protected void RemoveAreaTag_Click(Object sender, EventArgs e)
        {
            int areaTagID = int.Parse(((sender as LinkButton).Parent.FindControl("AreaTagIDLtr") as Literal).Text);

            cfController.DeletePlaceAreaTag(place.ID, areaTagID);
            BindAreaTags();
        }

        private void BindAreaTags()
        {
            AreaTags = cfController.GetAreaTagsForAPlace(place.ID);
            AreaTagsLV.DataSource = AreaTags;
            AreaTagsLV.DataBind();
        }
    }
}
