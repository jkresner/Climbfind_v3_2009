using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Objects;
using LinqToSql_MediaShare = ClimbFind.Model.LinqToSqlMapping.MediaShare;
using LinqToSql_OutdoorCragMediaShare = ClimbFind.Model.LinqToSqlMapping.OutdoorCragMediaShare;
using LinqToSql_PlaceMediaShare = ClimbFind.Model.LinqToSqlMapping.PlaceMediaShare;


namespace ClimbFind.Model.DataAccess
{
    public class MediaShareDA : AbstractBaseDA<MediaShare, LinqToSql_MediaShare, Guid>
    {
        public MediaShareDA() : base() { }
        public MediaShareDA(IDATransactionContext transactionContext) : base(transactionContext) { }
   
        /// <summary>
        /// 
        /// </summary>
        protected override MediaShare MapLinqTypeToOOType(LinqToSql_MediaShare o)
        {
            MediaShare o2 = new MediaShare();
            MapValues(o2, o.GetProperyNameAndValues());

            return (o2);
        }

        public MediaShare InsertPlaceMedia(MediaShare media, int placeID)
        {
            base.Insert(media);
            ctx.PlaceMediaShares.InsertOnSubmit(new LinqToSql_PlaceMediaShare() { MediaShareID = media.ID, PlaceID = placeID });
            CommitChanges();
            return media;
        }


        public MediaShare InsertCragMedia(MediaShare media, Guid cragID)
        {
            base.Insert(media);
            ctx.OutdoorCragMediaShares.InsertOnSubmit(new LinqToSql_OutdoorCragMediaShare() { MediaShareID = media.ID, OutdoorCragID = cragID });
            CommitChanges();
            return media;
        }

        /// <summary>
        /// 
        /// </summary>
        public List<MediaShare> GetMediaForPlace(int placeID)
        {
            return MapList((from ms in ctx.MediaShares from pm in ctx.PlaceMediaShares where pm.PlaceID == placeID && pm.MediaShareID == ms.ID select ms).ToList());
        }

        public Dictionary<MediaShare, int> GetLatestPlaceYouTubeMovies(int count)
        {
            return (from ms in ctx.MediaShares
                    from pm in ctx.PlaceMediaShares 
                    where ms.ID == pm.MediaShareID
                   orderby ms.SubmittedDateTime descending
                    select new KeyValuePair<MediaShare, int>(MapType(ms), pm.PlaceID)).Take(count).ToDictionary(p => p.Key, p => p.Value);
        }


        public List<FeedMoviePost> GetLatestFeedMoviePosts(int count)
        {
            return (from ms in ctx.MediaShares
                    from pm in ctx.PlaceMediaShares
                    where ms.ID == pm.MediaShareID
                    orderby ms.SubmittedDateTime descending
                    select new FeedMoviePost { PlaceID = pm.PlaceID, PlaceMedia = MapType(ms), Comments = new List<FeedPostComment>() }).Take(count).ToList();
        }

        public List<FeedMoviePost> GetLatestFeedMoviePostsForArea(int areaTagID, int count)
        {
            List<int> placesInArea = (from c in ctx.PlacesInAreas where c.AreaTagID == areaTagID select c.PlaceID).ToList();

            return (from ms in ctx.MediaShares
                    from pm in ctx.PlaceMediaShares
                    where ms.ID == pm.MediaShareID && placesInArea.Contains(pm.PlaceID)
                    orderby ms.SubmittedDateTime descending
                    select new FeedMoviePost { PlaceID = pm.PlaceID, PlaceMedia = MapType(ms), Comments = new List<FeedPostComment>() }).Take(count).ToList();
        }

        public List<FeedMoviePost> GetLatestFeedMoviePostsByClimbers(List<Guid> userIDs, int count)
        {
            return (from ms in ctx.MediaShares
                    from pm in ctx.PlaceMediaShares
                    where ms.ID == pm.MediaShareID && userIDs.Contains(ms.SubmittedByUserID)
                    orderby ms.SubmittedDateTime descending
                    select new FeedMoviePost { PlaceID = pm.PlaceID, PlaceMedia = MapType(ms), Comments = new List<FeedPostComment>() }).Take(count).ToList();
        }

        


        public List<FeedMoviePost> GetLatestFeedMoviePostsForPlace(int placeID, int count)
        {
            return (from ms in ctx.MediaShares
                    from pm in ctx.PlaceMediaShares
                    where ms.ID == pm.MediaShareID && pm.PlaceID == placeID
                    orderby ms.SubmittedDateTime descending
                    select new FeedMoviePost { PlaceID = pm.PlaceID, PlaceMedia = MapType(ms), Comments = new List<FeedPostComment>() }).Take(count).ToList();
        }    


        public List<MediaShare> GetUsersYouTubeMovies(Guid userID, int count)
        {
            var query = (from ms in ctx.MediaShares
                    where ms.SubmittedByUserID == userID
                    orderby ms.SubmittedDateTime descending
                    select ms);

            if (count != -1) { return MapList(query.Take(count).ToList()); }
            else { return MapList(query.ToList()); }
        }


        public List<FeedMoviePost> GetUsersFeedMoviePosts(Guid userID, int count)
        {
            return (from ms in ctx.MediaShares
                    from pm in ctx.PlaceMediaShares
                    where ms.ID == pm.MediaShareID && ms.SubmittedByUserID == userID
                    orderby ms.SubmittedDateTime descending
                    select new FeedMoviePost { PlaceID = pm.PlaceID, PlaceMedia = MapType(ms), Comments = new List<FeedPostComment>() }).Take(count).ToList();

        }

        /// <summary>
        /// 
        /// </summary>
        public List<MediaShare> GetMediaForOutdoorCrag(Guid cragID)
        {
            return MapList((from ms in ctx.MediaShares from ocms in ctx.OutdoorCragMediaShares where ocms.OutdoorCragID == cragID && ocms.MediaShareID == ms.ID select ms).ToList());
        }
    }
}
