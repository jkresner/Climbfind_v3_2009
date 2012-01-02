using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Objects;
using LinqToSql_FeedClimbingPost = ClimbFind.Model.LinqToSqlMapping.FeedClimbingPost;
using System;
using ClimbFind.Model.Enum;


namespace ClimbFind.Model.DataAccess
{   
    public class FeedClimbingPostDA : AbstractBaseDA<FeedClimbingPost, LinqToSql_FeedClimbingPost, int>
    {
        
        private FeedPostCommentDA feedPostCommentDA;
        public FeedClimbingPostDA() : base() { feedPostCommentDA = new FeedPostCommentDA(ctx); }

        
        public List<FeedClimbingPost> GetLatestPosts(int number, short? tagID, FeedView view)
        {
            var query = from c in EntityTable select c;

            return FilterAndSortQuery(query, number, tagID, view);
        }


        public List<FeedClimbingPost> GetPostsByUser(Guid userID, int number)
        {
            var query = from c in EntityTable where c.UserID == userID select c;

            return FilterAndSortQuery(query, number, null, FeedView.Posted);
        }

        public List<FeedClimbingPost> GetLatestPlacePosts(int number, int placeID, short? tagID, FeedView view)
        {
            var query = from c in EntityTable where c.PlaceID == placeID select c;

            return FilterAndSortQuery(query, number, tagID, view);
        }

        public List<FeedClimbingPost> GetLatestAreaPosts(int number, int areaID, short? tagID, FeedView view)
        {
            List<int> placeIDs = (from c in ctx.PlacesInAreas where c.AreaTagID == areaID select c.PlaceID).ToList();
            var query = from c in EntityTable where placeIDs.Contains(c.PlaceID) select c;

            return FilterAndSortQuery(query, number, tagID, view);
        }

        public List<FeedClimbingPost> GetUsersPosts(Guid userID)
        {
            var query = from c in EntityTable where c.UserID == userID orderby c.PostedDateTime select c;

            return MapList(query.ToList());
        }


        public List<FeedClimbingPost> GetLatestWatchedClimberPosts(int number, List<Guid> userIDs, 
            short? tagID, FeedView view)
        {
            if (userIDs.Count == 0) { return new List<FeedClimbingPost>(); }
            else
            {
                var query = from c in EntityTable where userIDs.Contains(c.UserID) select c;

                return FilterAndSortQuery(query, number, tagID, view);
            }
        }
        


        private List<FeedClimbingPost> FilterAndSortQuery(IQueryable<LinqToSql_FeedClimbingPost> query,
            int number, short? tagID, FeedView view)
        {
            if (tagID.HasValue) { query = (from c in query where c.TagID == tagID.Value select c); }
            if (view == FeedView.Posted) { query = (from c in query orderby c.PostedDateTime descending select c); }
            else if (view == FeedView.Climbing) { query = (from c in query where c.ClimbingDateTime > DateTime.Now orderby c.ClimbingDateTime ascending select c); }

            return MapList(query.Take(number).ToList());
        }


        protected override FeedClimbingPost MapLinqTypeToOOType(LinqToSql_FeedClimbingPost o)
        {
            FeedClimbingPost o2 = new FeedClimbingPost();
            MapValues(o2, o.GetProperyNameAndValues());

            o2.Comments = feedPostCommentDA.GetCommentsForPost(o.ID); //

            return (o2);
        }

    }

}
