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
    public partial class FindClimbersForWatchList : ClimbFindViewPage<ISessionViewData>
    {
        public List<ClimberProfile> SuggestedClimbersToWatch { get; set; }        
        public List<FeedClimberChannelRequest> WatchedClimbers { get; set; }

        protected void Page_Init(Object o, EventArgs e)
        {
            WatchedClimbers = cfController.GetClimbersUserIsWatching(UserID);
            SuggestedClimbersToWatch = new List<ClimberProfile>();
            SuggestedClimbersToWatch.Add( cfController.GetClimberProfile(new Guid("130b1de1-fd5d-46f5-9df1-d6e030a4158b")) );
            SuggestedClimbersToWatch.Add(cfController.GetClimberProfile(new Guid("a9646cc3-18cb-4a62-8402-5263ba8b3476")));
            SuggestedClimbersToWatch.Add(cfController.GetClimberProfile(new Guid("a071283a-7625-4d73-9bf6-8e95d534e78c")));
            

        }

        protected ClimberProfile GetC(FeedClimberChannelRequest c)
        {
            return CFDataCache.GetClimberFromCache(c.WatchedUserID);
        }
    }
}
