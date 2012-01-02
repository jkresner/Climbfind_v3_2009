using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClimbFind.Controls;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects;
using ClimbFind.Web.UI;
using ClimbFind.Model.Enum;
using ClimbFind.Helpers;
using ClimbFind.Model.Objects.Interfaces;

namespace IdentityStuff.Views.Places
{
    public partial class DetailOutdoor : ClimbFindViewPage<OutdoorPlace>
    {
        public OutdoorPlace place { get { return ViewData.Model; } }
        public Place mapPlace { get; set; }
        public List<IFeedItem> FeedPosts { get; set; }
        public bool UserClimbsHere { get; set; } 

        public ClimberProfile descriptionLastUpdatedByUser, descriptionImageFile1ByUser, descriptionImageFile2ByUser, descriptionImageFile3ByUser;

        public List<MediaShare> Media { get { return cfController.GetMediaForPlace(place.ID); } }
        public List<OutdoorCrag> Crags { get ; set ; }
        public List<OutdoorPlaceAuthority> AuthoritySites { get; set; }


        protected void Page_Init(Object s, EventArgs e)
        {
            mapPlace = CFDataCache.GetPlace(ViewData.Model.ID);
            FeedPosts = cfController.GetPlacesLatestFeedActivity(place.ID);
            if (!UserLoggedIn) { UserClimbsHere = false; }
            else { UserClimbsHere = cfController.UserClimbAtPlace(UserID, place.ID); }
            
            Crags = (from c in cfController.GetCragsAtPlace(place.ID) orderby c.Name select c).ToList();
            AuthoritySites = cfController.GetOutdoorPlacesAuthoriySites(place.ID);

            //-- Get contributing users
            if (place.DescriptionByUserID != null) { descriptionLastUpdatedByUser = CFDataCache.GetClimberFromCache(place.DescriptionByUserID.Value); }
            if (place.DescriptionImageFileByUserID != null) { descriptionImageFile1ByUser = CFDataCache.GetClimberFromCache(place.DescriptionImageFileByUserID.Value); }
            if (place.DescriptionImageFile2 != null) { descriptionImageFile2ByUser = CFDataCache.GetClimberFromCache(place.DescriptionImageFile2ByUserID.Value); }
            if (place.DescriptionImageFile3 != null) { descriptionImageFile3ByUser = CFDataCache.GetClimberFromCache(place.DescriptionImageFile3ByUserID.Value); }
        }

        protected string GetPhotoHtml(string descriptionImageUrl, ClimberProfile cp, string altTextFormaterString)
        {
            if (descriptionImageUrl == "/images/places/outdoor-rock-climbing/main/default.jpg" || cp == null)
            {
                return string.Format(@"<a href=""/Media/EditOutdoorLocationPictures/{0}""><img src=""/images/places/outdoor-rock-climbing/main/default.jpg""  class=""float-left"" alt=""click to change picture"" style=""margin-top:0px"" /></a>", place.ID);
            }
            else
            {
                string imageHtml = string.Format(@"<img src=""{0}"" class=""float-left"" alt=""", descriptionImageUrl);
                imageHtml += string.Format(altTextFormaterString, place.Name.RemoveSpecialChars());
            
                return imageHtml + string.Format(@""" style=""margin-top:0px"" /> <div class=""byUser"">Photo submitted by {0}</div>", 
                    CFControls.ClimberProfileLink(this, cp));
            }
        }

    }
}
