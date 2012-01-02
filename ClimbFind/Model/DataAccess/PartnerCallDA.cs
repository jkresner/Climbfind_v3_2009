using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Objects;
using LinqToSql_PartnerCall = ClimbFind.Model.LinqToSqlMapping.PartnerCall;
using LinqToSql_PartnerCallPlace = ClimbFind.Model.LinqToSqlMapping.PartnerCallPlace;
using LinqToSql_PartnerCallSubscription = ClimbFind.Model.LinqToSqlMapping.PartnerCallSubscription;
using ClimbFind.Model.Enum;
using ClimbFind.Helpers;


namespace ClimbFind.Model.DataAccess
{
    public class PartnerCallDA : AbstractBaseDA<PartnerCall, LinqToSql_PartnerCall, Guid>
    {
        public PartnerCallDA() : base() { }
        public PartnerCallDA(IDATransactionContext transactionContext) : base(transactionContext) { }
   
        /// <summary>
        /// Note that by default we do not get the replies for a partner call as this would be unneccessarily
        /// expensive for say returns search results of calls for a place.
        /// </summary>
        protected override PartnerCall MapLinqTypeToOOType(LinqToSql_PartnerCall o)
        {
            PartnerCall o2 = new PartnerCall();
            MapValues(o2, o.GetProperyNameAndValues());

            //LinqToSql_Place place = o.Place;

            o2.PlaceIDs = (from c in ctx.PartnerCallPlaces where c.PartnerCallID == o2.ID select c.PlaceID).ToList();

            //o2.PlaceName = place.Name;
            //o2.PlaceShortName = place.ShortName;
            //o2.PlaceClimbfindUrl = CFUrlGenerator.GetPlaceUrl(place.IsIndoor, place.FriendlyUrlLocation, place.FriendlyUrlName);
            //o2.PlaceIDs = 
            
            return (o2);
        }

        public List<FeedPartnerCallPost> GetLatestFeedPartnerCallPostsForPlace(int placeID, int count)
        {
            return (from pcp in ctx.PartnerCallPlaces
             from pc in ctx.PartnerCalls
             where (pcp.PlaceID == placeID) && (pcp.PartnerCallID == pc.ID)
              && !pc.Deleted
             orderby pc.PostedDateTime descending
             select new FeedPartnerCallPost { Call = MapType(pc) } ).Take(count).ToList();
        }


        public void DeleteByUserAndSaveSurvey(PartnerCall call, string reason, int numberOfpeoplWhoContacted)
        {
            ctx.PartnerCallSurveys.InsertOnSubmit( new ClimbFind.Model.LinqToSqlMapping.PartnerCallSurvey {
                 PartnerCallID = call.ID, DeletedDateTime = DateTime.Now, Reason = reason, 
                 NumberOfPeopleWhoContacted = numberOfpeoplWhoContacted, UserID = call.CreatorUserID } );
                
            base.Update(call);

            CommitChanges();
        }


        /// <summary>
        /// 
        /// </summary>
        public void DeletePlaceUserWantToClimbAt(Guid id, int placeID)
        {
            ctx.PartnerCallPlaces.DeleteOnSubmit((
                           from c in ctx.PartnerCallPlaces
                           where c.PlaceID == placeID
                               && c.PartnerCallID == id
                           select c).SingleOrDefault());

            CommitChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        public void InsertPlaceUserWantToClimbsAt(Guid id, int placeID)
        {
            ctx.PartnerCallPlaces.InsertOnSubmit(new LinqToSql_PartnerCallPlace { PartnerCallID = id, PlaceID = placeID });

            CommitChanges();
        }

        public List<int> GetPlaceIDsWithCalls()
        {
            return (from c in ctx.PartnerCallPlaces select c.PlaceID).Distinct().ToList();
        }

        


        /// <summary>
        /// We have to override the delete method to delete or the children... I guess we could also just set
        /// on cascade delete in the DB....
        /// </summary>
        public new void Delete(Guid id)
        {
            ctx.PartnerCallPlaces.DeleteAllOnSubmit(from c in ctx.PartnerCallPlaces where c.PartnerCallID == id select c);
            ctx.PartnerCallReplies.DeleteAllOnSubmit(from c in ctx.PartnerCallReplies where c.PartnerCallID == id select c);
            base.Delete(id);
        }

        /// <summary>
        /// 
        /// </summary>
        public List<PartnerCall> GetPartnerCallsForPlace(int placeID)
        {
            List<Guid> partnerCallIDs = (from c in ctx.PartnerCallPlaces where c.PlaceID == placeID select c.PartnerCallID).ToList();

            return MapList((from c in ctx.PartnerCalls
                            where partnerCallIDs.Contains(c.ID)
                            orderby c.PostedDateTime descending
                            select c).ToList());
        }

        public List<PartnerCall> GetPartnerCallsForAreaTag(int areaTagID, int number, bool? indoorOnly)
        {
            List<int> placesInArea = (from c in ctx.PlacesInAreas where c.AreaTagID == areaTagID select c.PlaceID).ToList();
            List<Guid> partnerCallIDs = (from c in ctx.PartnerCallPlaces where placesInArea.Contains(c.PlaceID) select c.PartnerCallID).Distinct().ToList();

            var query = (from c in ctx.PartnerCalls select c);
            query = from c in query where partnerCallIDs.Contains(c.ID) && !c.Deleted orderby c.PostedDateTime descending select c;
            if (indoorOnly.HasValue) { query = from c in query where c.IsIndoor == indoorOnly.Value select c; }

            return MapList(query.ToList()).Take(number).ToList();
        }

        public List<PartnerCall> GetPartnerCallsForPlaceCombo(List<int> placeIDs, int number)
        {
            List<Guid> partnerCallIDs = (from c in ctx.PartnerCallPlaces where placeIDs.Contains(c.PlaceID) select c.PartnerCallID).Distinct().ToList();

            var query = (from c in ctx.PartnerCalls select c);
            query = from c in query where partnerCallIDs.Contains(c.ID) orderby c.PostedDateTime descending select c;

            return MapList(query.ToList()).GetDistinctUserCalls().Take(number).ToList();
        }

        


        public List<PartnerCall> GetLatestIndoorPartnerCalls(int number, List<short> countries)
        {
            var query = from c in ctx.PartnerCalls where c.IsIndoor select c;
            if (countries != null) { query = from c in query where countries.Contains(c.CountryID) select c; }

            return MapList((from c in query orderby c.PostedDateTime descending select c).Take(number).ToList());
        }

        public List<PartnerCall> GetLatestPartnerCalls(int number, PartnerCallPlaceType type)
        {
            var query = from c in ctx.PartnerCalls where !c.Deleted select c;
            if (type != PartnerCallPlaceType.Both) {
                if (type == PartnerCallPlaceType.Indoor) {
                    query = from c in query where c.IsIndoor select c; }
                if (type == PartnerCallPlaceType.Outdoor) {
                    query = from c in query where !c.IsIndoor select c; } 
            }

            return MapList((from c in query orderby c.PostedDateTime descending select c).Take(number).ToList());
        }
        


        public List<PartnerCall> GetLatestOutdoorPartnerCalls(int number, List<short> countries)
        {
            var query = from c in ctx.PartnerCalls where !c.IsIndoor select c;
            if (countries != null) { query = from c in query where countries.Contains(c.CountryID) select c; }

            return MapList((from c in query orderby c.PostedDateTime descending select c).Take(number).ToList());
        }


        

        /// <summary>
        /// 
        /// </summary>
        public List<PartnerCall> GetUsersPartnerCalls(Guid userID)
        {
            List<PartnerCall> calls = (from c in ctx.PartnerCalls
                            where c.ClimberProfileID == userID
                            select GetFullPartnerCallDetails(c.ID)).ToList();         
            
            return calls;
        }

        /// <summary>
        /// Returns a partner call with all it's child replies
        /// </summary>
        public PartnerCall GetFullPartnerCallDetails(Guid id)
        {
            PartnerCall call = GetByID(id);
            if (call != null) { call.Replies = new PartnerCallReplyDA().GetRepliesForPartnerCall(id); }
            
            return call;
        }
    }
}
