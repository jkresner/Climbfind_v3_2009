using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Objects;
using ClimbFind.Web.UI;
using ClimbFind.Controller;
using ClimbFind.Helpers;
using ClimbFind.Model.Objects.Interfaces;
using ClimbFind.Model.Enum;


namespace IdentityStuff.Views.Places
{
    public partial class SeekingPartners : ClimbFindViewPage<Place>
    {
        public Place place { get { return ViewData.Model; } }
        public List<IFeedItem> FeedPosts { get; set; } 

        protected void Page_Init(Object s, EventArgs e)
        {
            FeedPosts = cfController.GetPlacesAllFeedActivity(place.ID);
            
            AreaAd.Area = cfController.GetAreaTagForCountry((Nation)place.CountryID);
        }
    }
}
