using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClimbFind.Model.Objects;
using ClimbFind.Controller;
using ClimbFind.Web.UI;
using ClimbFind.Model.Enum;
using ClimbFind.Model.DataAccess;

namespace IdentityStuff.Controls.AdUnits
{
    public partial class CF3Homepage160x600Banner : ClimbFindViewUserControl
    {
        public FeedSettings Settings { get; set; }
        public Nation CurrentCountry { get; set; }

        public void Page_Load(Object o, EventArgs e)
        {
            Settings = new CFController().GetUsersFeedViewSettings(UserID);

            if ((FeedChannel)Settings.CurrentChannelType == FeedChannel.Area)
            {
                CurrentCountry = (Nation)CFDataCache.GetAreaTag(Settings.AreaID.Value).CountryID;
            }
            else if ((FeedChannel)Settings.CurrentChannelType == FeedChannel.Place)
            {
                CurrentCountry = (Nation)CFDataCache.GetPlace(Settings.PlaceID.Value).CountryID;
            }
            else
            {
                CurrentCountry = Nation.Afghanistan;
            }
        }
    }
}
