using System;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Controllers;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;

namespace ClimbFind.Web.Mvc.Views.ClimberProfiles
{
    public partial class EditExtendedProfile : ClimbFindViewPage<ClimberProfileViewData>
    {        
        protected ClimberProfile climberProfile;
        protected ClimberProfileExtended extendedProfile;


        protected void Page_Init(object sender, EventArgs e)
        {           
            climberProfile = cfController.GetClimberProfile(UserID);
            extendedProfile = cfController.GetExtendedClimberProfile(UserID);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) 
            {
                BestMomentTxB.Text = extendedProfile.BestMoment;
                ClimbingAmbitionsTxB.Text = extendedProfile.ClimbingAmbitions;
                ClimbingHistoryTxB.Text = extendedProfile.ClimbingHistory;
                CompetitionsICompeteInTxB.Text = extendedProfile.CompetitionsICompeteIn;
                CurrentProjectsTxB.Text = extendedProfile.CurrentProjects;
                DislikeAboutClimbfindTxB.Text = extendedProfile.DislikeAboutClimbfind;
                FavoriteBrandsTxB.Text = extendedProfile.FavoriteBrands;
                FavoritePlacesTxB.Text = extendedProfile.FavoritePlaces;
                GradesTxB.Text = extendedProfile.Grades;
                LikeAboutClimbfindTxB.Text = extendedProfile.LikeAboutClimbfind;
                LikeToClimbTxB.Text = extendedProfile.LikeToClimb;
                PlacesIWouldLikeToClimbTxB.Text = extendedProfile.PlacesIWouldLikeToClimb;
                RoleModelsTxB.Text = extendedProfile.RoleModels;
            }
        }


        protected void SaveExtendedClimberProfile_Click(object sender, EventArgs e)
        {
            extendedProfile.BestMoment = BestMomentTxB.Text;
            extendedProfile.ClimbingAmbitions = ClimbingAmbitionsTxB.Text;
            extendedProfile.ClimbingHistory = ClimbingHistoryTxB.Text;
            extendedProfile.CompetitionsICompeteIn = CompetitionsICompeteInTxB.Text;
            extendedProfile.CurrentProjects = CurrentProjectsTxB.Text;
            extendedProfile.DislikeAboutClimbfind = DislikeAboutClimbfindTxB.Text;
            extendedProfile.FavoriteBrands = FavoriteBrandsTxB.Text;
            extendedProfile.FavoritePlaces = FavoritePlacesTxB.Text;
            extendedProfile.Grades = GradesTxB.Text;
            extendedProfile.LikeAboutClimbfind = LikeAboutClimbfindTxB.Text;
            extendedProfile.LikeToClimb = LikeToClimbTxB.Text;
            extendedProfile.PlacesIWouldLikeToClimb = PlacesIWouldLikeToClimbTxB.Text;
            extendedProfile.RoleModels = RoleModelsTxB.Text;

            cfController.UpdateExtendedClimberProfile(extendedProfile);

            RedirectTo<ClimberProfilesController>(c => c.Me());
        }
    }
}
