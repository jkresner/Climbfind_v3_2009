using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects;


namespace ClimbFind.Controller
{
    public partial class CFController
    {
        public bool IsAdmin { get { return User.Name == "jkresner@yahoo.com.au"; } } 
        
        public void DeleteOutdoorPlaceCompletely(int ID)
        {
            if (!IsAdmin) { throw new Exception("Only admin can delete places"); }

            Place place = new PlaceDA().GetByID(ID);

            new OutdoorPlaceDA().Delete(ID);
            new PlaceDA().Delete(ID);

            CFDataCache.CacheAllOutdoorPlaces();

            CFLogger.RecordModerateDeletePlace(CurrentClimber.ID, place.Name, place.CountryID, place.ClimbfindUrl); 
        }

        public void DeleteIndoorPlaceCompletely(int ID)
        {
            if (!IsAdmin) { throw new Exception("Only admin can delete places"); }
            Place place = new PlaceDA().GetByID(ID);

            new IndoorPlaceDA().Delete(ID);
            new PlaceDA().Delete(ID);

            CFDataCache.CacheAllIndoorPlaces();
            
            CFLogger.RecordModerateDeletePlace(CurrentClimber.ID, place.Name, place.CountryID, place.ClimbfindUrl);
        }
       
        public void GiveUserModeratorRights(Guid userID)
        {
            if (!IsAdmin) { throw new Exception("Only admin can give moderator rights"); }

            ClimberProfile cp = new ClimberProfileDA().GetByID(userID);
            cp.IsModerator = true;
            new ClimberProfileDA().Update(cp);
        }

        public void TakeUserModeratorRights(Guid userID)
        {
            if (!IsAdmin) { throw new Exception("Only admin can take moderator rights"); }

            ClimberProfile cp = new ClimberProfileDA().GetByID(userID);
            cp.IsModerator = false;
            new ClimberProfileDA().Update(cp);
        }
        
        public void DeleteUserCompletely(Guid userID)
        {
            if (!IsAdmin) { throw new Exception("Only admin can delete users"); }

            new ClimberProfileDA().DeleteUserCompletely(userID);

            CFDataCache.FlushClimberFromCache(userID);
        }

        public void DeleteClub(int clubID)
        {
            if (!IsAdmin) { throw new Exception("Only admin can delete clubs"); }

            new ClubDA().Delete(clubID);

            CFDataCache.CacheAllClubs();
        }
        
        public void DeleteLogEvent(int id)
        {
            CFLogger.Delete(id);
        }

        public void ArchiveLogEvent(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteLogExceptionEvent(int id)
        {
            CFLogger.DeleteException(id);
        }

        public void ArchiveLogExceptionEvent(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteFeedback(int feedbackID)
        {
            if (User.Name != "jkresner@yahoo.com.au") { throw new Exception("Only jonathon can delete feedback"); }

            new FeedbackDA().Delete(feedbackID);
        }



        public List<MessageBoardMessage> GetLast100MessageBoardMessages()
        {
            return new MessageBoardMessageDA().GetLastN(100);
        }

        public Dictionary<Guid, string> GetAllClimberProfiles()
        {
            return new ClimberProfileDA().GetAll().ToDictionary(c=>c.ID, c=>c.Email);
        }

        public List<ClimberProfile> GetAllProfiles()
        {
            return new ClimberProfileDA().GetAll();
        }

    }
}
