using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClimbFind.Model.Objects;
using ClimbFind.Web.UI;
using ClimbFind.Model.DataAccess;
using ClimbFind.Helpers;
using System.Web.UI.WebControls;
using ClimbFind.Model.Enum;
using ClimbFind.Model.Objects.Interfaces;
using System.Threading;


namespace IdentityStuff.Views.CFFeed
{    
    public partial class Feed : ClimbFindViewUserControl
    {
        public FeedSettings Settings { get; set; }
        public string CurrentPlaceName { get {
            if (!Settings.PlaceID.HasValue) { return ""; }
            return CFDataCache.GetPlace(Settings.PlaceID.Value).ShortName; } }

        public string CurrentAreaName
        {
            get {
            if (!Settings.AreaID.HasValue) { return ""; }
            return CFDataCache.GetAreaTag(Settings.AreaID.Value).Name; } }

        protected void Page_Init(Object o, EventArgs e)
        {
            Settings = cf.GetUsersFeedViewSettings(UserID);
        }
    }

}
