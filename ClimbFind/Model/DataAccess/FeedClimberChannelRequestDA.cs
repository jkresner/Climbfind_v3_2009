using System;
using System.Linq;
using ClimbFind.Model.Objects;
using LinqToSql_FeedClimberChannelRequest = ClimbFind.Model.LinqToSqlMapping.FeedClimberChannelRequest;
using System.Collections.Generic;

namespace ClimbFind.Model.DataAccess
{
    public class FeedClimberChannelRequestDA : AbstractBaseDA<FeedClimberChannelRequest, LinqToSql_FeedClimberChannelRequest, int>
    {


        public void DeleteAllRequestsForUser(Guid userID)
        {
            EntityTable.DeleteAllOnSubmit(from c in EntityTable where c.WatchedUserID == userID ||
                                          c.WatchingUserID == userID select c);

            CommitChanges();
        }
        /// <summary>
        /// 
        /// </summary>
        public List<FeedClimberChannelRequest> GetClimbersUserIsWatching(Guid userID)
        {
            return MapList((from c in EntityTable 
                            where c.WatchingUserID == userID && c.ApprovedDateTime.HasValue select c).ToList());
        }

        public List<FeedClimberChannelRequest> GetClimbersNotAcceptedRequestFromUser(Guid userID)
        {
            return MapList((from c in EntityTable 
                            where c.WatchingUserID == userID && !c.ApprovedDateTime.HasValue select c).ToList());
        }

        public List<FeedClimberChannelRequest> GetClimbersWatchingMe(Guid userID)
        {
            return MapList((from c in EntityTable 
                            where c.WatchedUserID == userID && c.ApprovedDateTime.HasValue select c).ToList());
        }
        

        public List<FeedClimberChannelRequest> GetClimbersUserHasRequestedToWatch(Guid userID)
        {
            return MapList((from c in EntityTable
                            where c.WatchingUserID == userID
                            select c).ToList());
        }


        public FeedClimberChannelRequest GetClimberWatchEntry(Guid watchingUserID, Guid watchedUserID)
        {
            return MapType((from c in EntityTable 
                            where c.WatchingUserID == watchingUserID && 
                             c.WatchedUserID == watchedUserID select c).SingleOrDefault());
        }


        public List<FeedClimberChannelRequest> GetUnrepliedWatchRequests(Guid watchedUserID)
        {
            return MapList((from c in EntityTable 
                            where !c.ApprovedDateTime.HasValue && !c.RejectedDateTime.HasValue &&
                             c.WatchedUserID == watchedUserID select c).ToList());
        }
        

    }
}
