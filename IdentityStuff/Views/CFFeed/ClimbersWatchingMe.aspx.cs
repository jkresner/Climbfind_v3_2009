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
    public partial class ClimbersWatchingMe : ClimbFindViewPage<ISessionViewData>
    {
        public List<FeedClimberChannelRequest> Climbers { get; set; }
        public List<FeedClimberChannelRequest> WatchRequestsNeedingReply { get; set; }

 
        protected void Page_Init(Object o, EventArgs e)
        {
            Climbers = cfController.GetClimbersWatchingMe(UserID);
            WatchRequestsNeedingReply = cfController.GetUnrepliedWatchRequests(UserID);
        }


        protected ClimberProfile GetC(FeedClimberChannelRequest c)
        {
            return CFDataCache.GetClimberFromCache(c.WatchingUserID);
        }

        protected ClimberProfile GetClimberWhoseChannelYouJoined()
        {
            var query = from c in Climbers orderby c.ApprovedDateTime descending select c;
            return GetC(query.Take(1).SingleOrDefault());
        }

        

    }
}
