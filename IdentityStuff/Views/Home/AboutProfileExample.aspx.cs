using System;
using System.Collections.Generic;
using ClimbFind.Controller;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Controllers;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;

namespace IdentityStuff.Views.Home
{
    public partial class AboutProfileExample : ClimbFindViewPage<ClimberProfileViewData>
    {
        protected int i = 1;
        
        public ClimberProfile Current { get { return ViewData.Model.Profile; } }
        public List<PartnerCall> UsersCalls { get { return ViewData.Model.UsersCalls; } }
        protected ClimberProfileExtended extendedProfile;
        protected List<Club> clubs;

        protected void Page_Init(object sender, EventArgs e)
        {
            ClimbFind.Model.Objects.MessageBoard messageBoard = new CFController().GetMessageBoard(Current.MessageBoardID);
            extendedProfile = cfController.GetExtendedClimberProfile(Current.ID);
            Current.PlacesUserClimbs = cfController.GetPlacesUserClimbs(Current.ID);
            clubs = cfController.GetClubsUserBelongsTo(Current.ID);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        protected string ShowClimbingTypeDIVHtml(string type, bool show)
        {
            if (!show) { return ""; }
            else if (type == "TopRope")
            {
                return @"<div class=""climbingTypeDIV"">
                                <div class=""climbingTypeHeading"">Top rope</div>
                                <img src=""/images/UI/cf/TopRope.bmp"" alt=""Top rope"" /></div>";
            }
            else if (type == "Lead")
            {
                return @"<div class=""climbingTypeDIV"">
                                <div class=""climbingTypeHeading"">Lead</div>
                                <img src=""/images/UI/cf/Lead.bmp"" alt=""Lead"" /></div>";
            }
            else if (type == "Boulder")
            {
                return @"<div class=""climbingTypeDIV"">
                                <div class=""climbingTypeHeading"">Boulder</div>
                                <img src=""/images/UI/cf/Boulder.bmp"" alt=""Boulder"" /></div>";
            }
            else { return (""); }
        }

    }

  
}
