using System;
using System.Collections.Generic;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;
using ClimbFind.Model.Objects.Interfaces;

namespace ClimbFind.Web.Mvc.Views.ClimberProfiles
{
    public partial class Me : ClimbFindViewPage<ClimberProfileViewData>
    {        
        protected ClimberProfile climberProfile;
        protected ClimberProfileExtended extendedProfile;
        //protected MessageBoard messageBoard;
        protected List<Club> clubs;
        //public List<MediaShare> UsersMovies { get; set; }
        protected List<IFeedItem> UsersActivity;


        protected void Page_Init(object sender, EventArgs e)
        {
            climberProfile = cfController.GetClimberProfile(UserID);
            climberProfile.PlacesUserClimbs = cfController.GetPlacesUserClimbs(climberProfile.ID);
            //messageBoard = cfController.GetMessageBoard(climberProfile.MessageBoardID);
            extendedProfile = cfController.GetExtendedClimberProfile(climberProfile.ID);
            clubs = cfController.GetClubsUserBelongsTo(climberProfile.ID);
            //UsersMovies = cfController.GetUsersYouTubeMovies(UserID, 3); 
            UsersActivity = cfController.GetUsersActivity(climberProfile.ID);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {  }

            //MessageBoardUC.RenderMessageBoard(messageBoard, UserID);
        }

    }
}
