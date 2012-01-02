using ClimbFind.Content;
using ClimbFind.Model.Enum;
using LinqToSql_FeedPostComment = ClimbFind.Model.LinqToSqlMapping.FeedPostComment;
using ClimbFind.Model.DataAccess;

namespace ClimbFind.Model.Objects
{
    public partial class FeedPostComment : LinqToSql_FeedPostComment
    {
        public ClimberProfile User { get { return CFDataCache.GetClimberFromCache(UserID); } }
        public string CommentorsName { get { return User.NickName; } }
        public string UserProfileImgUrl { get { return User.ProfilePictureUrlMini; } }
    }
}

