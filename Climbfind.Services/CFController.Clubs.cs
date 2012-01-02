using System;
using System.Collections.Generic;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Enum;
using ClimbFind.Model.Objects;

namespace ClimbFind.Controller
{
    public partial class CFController
    {                  
        /// <summary>
        /// Group stuff
        /// </summary>

        public Club CreateClub(Club club)
        {         
            Club newClub = new ClubDA().Insert( club );

            AddClubAreaTag(newClub.ID, GetAreaTagForCountry((Nation)newClub.CountryID).ID);            
  
            CFLogger.RecordClubCreate(CurrentClimber.ID, club.Name, club.ID);

            CFDataCache.CacheAllClubs();

            return club;
        }

        public List<AreaTag> GetAreaTagsForAClub(int id)
        {
            return new AreaTagDA().GetAreaTagsForAClub(id);
        }

        public void AddClubAreaTag(int clubID, int areaTagID)
        {
            new ClubDA().InsertPlaceArea(clubID, areaTagID);
        }

        public void DeleteClubAreaTag(int clubID, int areaTagID)
        {
            new ClubDA().DeleteAreaTag(clubID, areaTagID);
        }

        public Club GetClub(int id)
        {
            return new ClubDA().GetByID(id);
        }

        public Club GetClub(string friendlyUrlName)
        {
            return new ClubDA().GetByUrlName(friendlyUrlName);
        }



        public List<Club> GetClubsInArea(int areaTagID)
        {
            return new ClubDA().GetClubsInArea(areaTagID);
        }

        public List<Club> GetAllClubs()
        {
            return new ClubDA().GetAll();
        }

        public List<ClimberProfile> GetClubMembers(int clubID)
        {
            ClimberProfileDA da = new ClimberProfileDA();

            return da.GetClubMembers(clubID);
        }


        public Club UpdateClub(Club club)
        {
            return new ClubDA().Update(club);
        }


        public List<Club> GetClubsUserBelongsTo(Guid userID)
        {
            List<Club> clubs = new List<Club>();
            List<int> clubIDs =  new ClubDA().GetClubsUserBelongsTo(userID);
            foreach (int id in clubIDs) { clubs.Add(CFDataCache.GetClub(id)); }
            return clubs;
        }


        public void JoinClub(int clubID, string clubName, Guid userID, string usersEmail)
        {
            ClimberProfileDA cpDA = new ClimberProfileDA();

            if (cpDA.GetClimberProfile(usersEmail) == null)
            {
                cpDA.CreateDefaultClimberProfile(userID, usersEmail, InsertNewMessageBoard());
            }

            CFLogger.RecordClubJoin(userID, clubName, clubID);

            new ClubDA().InsertMemeber(clubID, userID);
        }


        public void LeaveClub(string clubName, int clubID, Guid userID)
        {
            CFLogger.RecordClubLeave(userID, clubName, clubID);

            new ClubDA().RemoveMemeber(clubID, userID);
        }


        public bool UserBelongsToClub(string email, int clubID)
        {
            ClimberProfile profile = GetClimberProfileByEmail(email);
            if (profile == null) { return false; } //-- No worries, person is not registered on climbfind
            else
            {
                //-- check if the user is already a member of the group.
                return new ClubDA().UserBelongsToClub(profile.ID, clubID);
            }
        }


    }
}
