using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Controls;
using ClimbFind.Helpers;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects;
using ClimbFind.Web.UI;


namespace IdentityStuff.Views.Places
{
    public partial class DetailCrag : ClimbFindViewPage<OutdoorCrag>
    {
        public OutdoorCrag Crag { get { return ViewData.Model; } }
        public List<OutdoorCrag> OtherCrags { get; set; }
        public OutdoorPlace place { get; set; }

        public ClimberProfile descriptionImageFile1ByUser, descriptionImageFile2ByUser, descriptionImageFile3ByUser;

        public List<MediaShare> Media { get { return cfController.GetMediaForCrag(Crag.ID); } }
        //public List<OutdoorCrag> Crags { get { return ; } }

        protected void Page_Init(Object s, EventArgs e)
        {
            place = cfController.GetOutdoorPlace(Crag.PlaceID);
            MessageBoardUC.RenderMessageBoard(cfController.GetMessageBoard(Crag.MessageBoardID));
            
            ////-- Get contributing users
            if (Crag.DescriptionImageFile1ByUserID != null) { descriptionImageFile1ByUser = CFDataCache.GetClimberFromCache(Crag.DescriptionImageFile1ByUserID.Value); }
            if (Crag.DescriptionImageFile2ByUserID != null) { descriptionImageFile2ByUser = CFDataCache.GetClimberFromCache(Crag.DescriptionImageFile2ByUserID.Value); }
            if (Crag.DescriptionImageFile3ByUserID != null) { descriptionImageFile3ByUser = CFDataCache.GetClimberFromCache(Crag.DescriptionImageFile3ByUserID.Value); }

            OtherCrags = (from c in cfController.GetCragsAtPlace(place.ID) where c.ID != Crag.ID select c).ToList();
        }


        protected string GetPhotoHtml(string descriptionImageUrl, ClimberProfile cp, string altTextFormaterString)
        {
            if (descriptionImageUrl == "/images/places/outdoor-rock-climbing/default.jpg" || cp == null)
            {
                return string.Format(@"<a href=""/Media/EditOutdoorCragPictures/{0}""><img src=""/images/places/outdoor-rock-climbing/main/default.jpg""  class=""float-left"" alt=""click to change picture"" style=""margin-top:0px"" /></a>", Crag.ID);
            }
            else
            {
                string imageHtml = string.Format(@"<img src=""{0}"" class=""float-left"" alt=""", descriptionImageUrl);
                imageHtml += string.Format(altTextFormaterString, place.Name);

                return imageHtml + string.Format(@""" style=""margin-top:0px"" /> <div class=""byUser"">Photo submitted by {0}</div>",
                    CFControls.ClimberProfileLink(this, cp));
            }
        }


        protected string GetParagraphIfNoInfo(string s)
        {
            if (string.IsNullOrEmpty(s)) { return "Unknown"; } else { return s.GetHtmlParagraph(); }
        }
    }
}
