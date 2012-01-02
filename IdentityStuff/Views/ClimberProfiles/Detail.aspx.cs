using System;
using System.Linq;
using System.Collections.Generic;
using ClimbFind.Controller;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;
using ClimbFind.Helpers;
using ClimbFind.Model.Objects.Interfaces;


namespace ClimbFind.Web.Mvc.Views.ClimberProfiles
{
    public partial class Detail : ClimbFindViewPage<ClimberProfileViewData>
    {
        protected int i = 1;
        
        public ClimberProfile Current { get { return ViewData.Model.Profile; } }
        public List<PartnerCall> UsersCalls { get { return ViewData.Model.UsersCalls; } }
        //public List<PartnerCall> UniquePlacePartnerCalls { get; set; }
        //public List<MediaShare> UsersMovies { get; set; }
        public FeedClimberChannelRequest FeedWatchEntry { get; set; }

        protected ClimberProfileExtended extendedProfile;
        protected List<Club> clubs;
        protected List<IFeedItem> UsersActivity;

        protected void Page_Init(object sender, EventArgs e)
        {
            ClimbFind.Model.Objects.MessageBoard messageBoard = new CFController().GetMessageBoard(Current.MessageBoardID);
            //MessageBoardUC.RenderMessageBoard(messageBoard, Current.ID);
            extendedProfile = cfController.GetExtendedClimberProfile(Current.ID);
            Current.PlacesUserClimbs = cfController.GetPlacesUserClimbs(Current.ID);
            clubs = cfController.GetClubsUserBelongsTo(Current.ID);
            //UsersMovies = cfController.GetUsersYouTubeMovies(Current.ID, 3);
            FeedWatchEntry = cfController.GetClimberWatchEntry(UserID, Current.ID);

            UsersActivity = cfController.GetUsersActivity(Current.ID);

            //UniquePlacePartnerCalls = (from c in UsersCalls orderby c.PostedDateTime descending select c).ToList().GetDistinctPlaceCalls();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

    }
}
