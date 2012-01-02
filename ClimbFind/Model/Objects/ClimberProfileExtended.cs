using System;


namespace ClimbFind.Model.Objects
{
    public class ClimberProfileExtended : ClimbFind.Model.LinqToSqlMapping.ClimberProfileExtended
    {
        public bool IsEmpty 
        {
            get
            {
                return String.IsNullOrEmpty(BestMoment) && 
                    String.IsNullOrEmpty(ClimbingAmbitions) && 
                    String.IsNullOrEmpty(ClimbingHistory) && 
                    String.IsNullOrEmpty(CompetitionsICompeteIn) && 
                    String.IsNullOrEmpty(CurrentProjects) && 
                    String.IsNullOrEmpty(DislikeAboutClimbfind) && 
                    String.IsNullOrEmpty(FavoriteBrands) && 
                    String.IsNullOrEmpty(FavoritePlaces) && 
                    String.IsNullOrEmpty(Grades) && 
                    String.IsNullOrEmpty(LikeAboutClimbfind) && 
                    String.IsNullOrEmpty(LikeToClimb) && 
                    String.IsNullOrEmpty(PlacesIWouldLikeToClimb) && 
                    String.IsNullOrEmpty(RoleModels);
            }
        }
    }
}
