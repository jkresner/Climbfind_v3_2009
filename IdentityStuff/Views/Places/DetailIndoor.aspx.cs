using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Objects;
using ClimbFind.Web.UI;
using ClimbFind.Model.Enum;
using ClimbFind.Helpers;
using System.Text;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects.Interfaces;

namespace IdentityStuff.Views.Places
{
    public partial class DetailIndoor : ClimbFindViewPage<IndoorPlace>
    {
        public IndoorPlace place { get { return ViewData.Model; } }
        public Place mapPlace { get; set; }
        public List<IFeedItem> FeedPosts { get; set; } 
        public bool UserClimbsHere { get; set; } 

        protected void Page_Init(Object s, EventArgs e)
        {
            mapPlace = CFDataCache.GetPlace(ViewData.Model.ID);
            FeedPosts = cfController.GetPlacesLatestFeedActivity(place.ID);
            if (!UserLoggedIn) { UserClimbsHere = false; }
            else { UserClimbsHere = cfController.UserClimbAtPlace(UserID, place.ID); }
        }

        protected string GetWebsite(string url)
        {
            if (url.Length > 26) { return url.Take(26) + "..."; }
            else return url;
        }
    }
}
