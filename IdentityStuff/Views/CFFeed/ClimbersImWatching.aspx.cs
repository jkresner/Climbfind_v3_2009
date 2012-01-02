using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;
using ClimbFind.Model.Objects;
using ClimbFind.Model.DataAccess;


namespace IdentityStuff.Views.CFFeed
{
    public partial class ClimbersImWatching : ClimbFindViewPage<ISessionViewData>
    {
        public List<FeedClimberChannelRequest> WatchedClimbers { get; set; }
        public List<FeedClimberChannelRequest> RequestedClimbers { get; set; }
        public List<FeedClimberChannelRequest> Climbers { get; set; }


        protected void Page_Init(Object o, EventArgs e)
        {
            WatchedClimbers = cfController.GetClimbersUserIsWatching(UserID);
            RequestedClimbers = cfController.GetClimbersIHaveRequested(UserID);
            Climbers = new List<FeedClimberChannelRequest>(WatchedClimbers);
            Climbers.AddRange(RequestedClimbers);
            Climbers = (from c in Climbers orderby GetC(c).FullName select c).ToList();
        }


        protected ClimberProfile GetC(FeedClimberChannelRequest c)
        {
            return CFDataCache.GetClimberFromCache(c.WatchedUserID);
        }


        protected ClimberProfile GetLatestWatchedClimber()
        {
            var query = from c in WatchedClimbers orderby c.ApprovedDateTime select c;
            if (query.Count() == 0) { return null; }
            else { return GetC(query.Take(1).SingleOrDefault()); }
        }

        protected ClimberProfile GetLatestRequestedClimber()
        {
            var query = from c in WatchedClimbers orderby c.RequestedDateTime select c;
            return GetC(query.Take(1).SingleOrDefault());
        }
    }
}
