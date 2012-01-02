using System.Linq;
using ClimbFind.Content;
using ClimbFind.Model.Enum;
using LinqToSql_FeedClimbingPost = ClimbFind.Model.LinqToSqlMapping.FeedClimbingPost;
using System.Collections.Generic;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects.Interfaces;
using ClimbFind.Helpers;

namespace ClimbFind.Model.Objects
{
	public partial class FeedClimbingPost : LinqToSql_FeedClimbingPost, IPartnerPageItem
    {
        public List<FeedPostComment> Comments { get; set; }
        public ClimberProfile User { get { return CFDataCache.GetClimberFromCache(UserID); } }
        public string UserProfileImgUrl { get { return User.ProfilePictureUrlMini; } }
        public string CommentUrl { get { return "/CFFeed/CommentOnPost/"+ID; } }
        public string DeleteUrl { get { return "/CFFeed/DeletePost/"+ID; } }


        public string RenderHTMLOptions()
        {
            string options = string.Format(@"<a class=""PostComment"" href=""{0}"">Comment/Reply</a> - <a class=""PostDM"" href=""/write-message/{1}"">Msg {2}</a>",
                    CommentUrl, UserID, User.FullName);

            if ((CFProfile.UserID == UserID) || CFProfile.UserIsKrez) { options += string.Format(@"- <a class=""PostDelete"" href=""{0}"">Delete</a>", DeleteUrl); }
            return options;
        }

        public string RenderHTMLPostTopDetails()
        {
            Place place = CFDataCache.GetPlace(PlaceID);
            return string.Format(@"<label>{0}</label><br /><i>climbing</i> {1} @ <img src='{2}' /><a href='{3}'>{4}</a>",
                TagString, ClimbingDateTime.ToCFDateString(), place.FlagImageUrl2, place.ClimbfindUrl, place.Name);
        }

        public string RenderHTMLPostBody()
        {
            return string.Format("<p>{0}</p>", Message.GetHtmlParagraph());
        }

        public string TagString
        {
            get {
                if (TagID == 0) { return ""; }
                else { return "#" + (from c in CFDataCache.AllFeedTags where c.ID == TagID select c.Name).SingleOrDefault(); }
            }
        }

		public string RenderHTMLOptionsForPartnerPage()
		{
			string options = string.Format(@"<a class=""PostComment"" href=""{0}"" target=""_blank"">Comment/Reply</a> - <a class=""PostDM"" href=""/write-message/{1}"" target=""_blank"">Msg {2}</a>",
					CommentUrl, UserID, User.FullName);

			if ((CFProfile.UserID == UserID) || CFProfile.UserIsKrez) { options += string.Format(@"- <a class=""PostDelete"" href=""{0}"" target=""_blank"">Delete</a>", DeleteUrl); }
			return options;

		}

		public string RenderHTMLPostTopDetailsForPartnerPage()
		{
			Place place = CFDataCache.GetPlace(PlaceID);
			return string.Format(@"<label>{0}</label><br /><i>climbing</i> {1}",
				TagString, ClimbingDateTime.ToCFDateString());
		}

		public string RenderHTMLPostBodyForPartnerPage()
		{
			return RenderHTMLPostBody();
		}
	}
}

