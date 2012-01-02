using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Objects;
using LinqToSql_FeedPostComment = ClimbFind.Model.LinqToSqlMapping.FeedPostComment;
using System;


namespace ClimbFind.Model.DataAccess
{
    public class FeedPostCommentDA : AbstractBaseDA<FeedPostComment, LinqToSql_FeedPostComment, int>
    {
        public FeedPostCommentDA() : base() { }
        public FeedPostCommentDA(IDATransactionContext transactionContext) : base(transactionContext) {  }

        public List<FeedPostComment> GetCommentsForPost(int feedPostID)
        {
            return MapList( (from c in EntityTable
                             where c.FeedPostID == feedPostID
                             orderby c.PostedDateTime ascending
                             select c).ToList() );
        }

        public List<FeedPostComment> GetUsersComments(Guid userID)
        {
            var query = from c in EntityTable where c.UserID == userID orderby c.PostedDateTime select c;
            return MapList(query.ToList());
        }

    }

}
