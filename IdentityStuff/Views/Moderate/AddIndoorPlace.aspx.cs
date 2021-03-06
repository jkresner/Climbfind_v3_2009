﻿using System;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Controllers;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;
using ClimbFind.Helpers;
using ClimbFind.Model.Enum;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace IdentityStuff.Views.Moderate
{
    public partial class AddIndoorPlace : ClimbFindViewPage<ISessionViewData>
    {
        public int NewPlaceID { get { return int.Parse(PlaceIDHD.Value); } }
        public Place NewPlace { get { return cfController.GetPlace(NewPlaceID); } }

        protected void Page_Init(Object o, EventArgs e)
        {
            if (!Page.IsPostBack) { AreaTxB.Country = Nation.Zimbabwe; AreaTxB.Group = "AddArea"; } //-- Hack to stop exception
        }

        protected void ContinueToDetails_Click(Object o, EventArgs e)
        {
            AddPlaceMV.SetActiveView(VIEWAddDetails);
        }

        protected void CreatePlace_Click(Object sender, EventArgs e)
        {
            if (PeterBlum.VAM.Globals.Page.IsValid)
            {
                string friendlyUrlName = NameTxB.Text.Trim().Replace(" ", "-").ToLower();
                string friendlyUrlLocation = NationalityDDLUC.SelectedNation.GetCountryFriendlyUrl();

                Place existingPlace = cfController.GetPlace(friendlyUrlLocation, friendlyUrlName);

                if (existingPlace != null)
                {
                    //-- Incase user clicks button twice this is to stop an exception
                    RedirectTo<ModerateController>(c => c.EditIndoorPlace(existingPlace.ID));
                }
                else
                {
                    string address = AddressTxB.Text.Replace("'", ""); // Stop virtual earth javascript from crashing

                    Place place = cfController.AddIndoorPlace( new Place
                    {
                        CreatedByUserID = UserID,
                        CountryID = (short)NationalityDDLUC.SelectedNation,
                        Description = "",
                        FriendlyUrlLocation = friendlyUrlLocation,
                        IsIndoor = true,
                        Latitude = MapCoordinatePickerUC.Latitude,
                        Longitude = MapCoordinatePickerUC.Longitude,
                        Name = NameTxB.Text.Trim(),
                        ShortName = ShortNameTxB.Text.Trim(),
                    }, address, "", WebsiteTxB.Text, BoulderCB.Checked, LeadClimbCB.Checked,
                        TopRopeCB.Checked);

                    PlaceIDHD.Value = place.ID.ToString();

                    if (IsRegularRB.Checked) { cfController.SavePlaceUserClimbsAt(UserID, NewPlaceID); }

                    //-- Continue to map
                    AreaTag tag = cfController.GetAreaTagForCountry(NationalityDDLUC.SelectedNation);
                    MapCoordinatePickerUC.SetMapStartPosition(tag.Latitude, tag.Longitude, tag.DefaultVirtualEarthZoom);
                    AddPlaceMV.SetActiveView(VIEWPlotOnMap);
                }
            }
        }

        protected void SaveCoordinates_Click(Object sender, EventArgs e)
        {
            if (MapCoordinatePickerUC.HasCoordinates)
            {
                Place place = cfController.GetPlace(NewPlaceID);
                place.Latitude = MapCoordinatePickerUC.Latitude;
                place.Longitude = MapCoordinatePickerUC.Longitude;

                cfController.UpdatePlaceCoordinates(place);
            }

            GoToAreaTags_Click(sender, e);
        }

        protected void AddAreaTag_Click(Object sender, EventArgs e)
        {
            cfController.AddPlaceAreaTag(NewPlace.ID, AreaTxB.SelectedAreaTagID);
            AreaTxB.Clear();
            BindAreaTags();
        }

        protected void RemoveAreaTag_Click(Object sender, EventArgs e)
        {
            int areaTagID = int.Parse(((sender as LinkButton).Parent.FindControl("AreaTagIDLtr") as Literal).Text);

            cfController.DeletePlaceAreaTag(NewPlace.ID, areaTagID);
            BindAreaTags();
        }

        private void BindAreaTags()
        {
            List<AreaTag> AreaTags = cfController.GetAreaTagsForAPlace(NewPlaceID);
            AreaTagsLV.DataSource = AreaTags;
            AreaTagsLV.DataBind();
        }

        protected void GoToAreaTags_Click(Object sender, EventArgs e)
        {
            Place place = cfController.GetPlace(NewPlaceID);

            List<AreaTag> tagsForCountry = cfController.GetAllAreaTagsInCountry((Nation)place.CountryID);
            if (tagsForCountry.Count == 1) { GoToPlacePage_Click(sender, e); } // no point in screen if no tags available to add

            AddPlaceMV.SetActiveView(VIEWAddAreaTags);
            AreaTxB.Country = (Nation)place.CountryID;

            BindAreaTags();
        }

        protected void GoToPlacePage_Click(Object o, EventArgs e)
        {
            Place place = cfController.GetPlace(NewPlaceID);
            RedirectTo<PlacesController>(c => c.DetailIndoor(place.FriendlyUrlLocation, place.FriendlyUrlName));
        }

        protected void ContinueToMap_Click(Object o, EventArgs e)
        {
            if (PeterBlum.VAM.Globals.Page.IsValid)
            {
                AreaTag tag = cfController.GetAreaTagForCountry(NationalityDDLUC.SelectedNation);
                MapCoordinatePickerUC.SetMapStartPosition(tag.Latitude, tag.Longitude, tag.DefaultVirtualEarthZoom); 
                AddPlaceMV.SetActiveView(VIEWPlotOnMap);
            }
        }
      

    }
}
