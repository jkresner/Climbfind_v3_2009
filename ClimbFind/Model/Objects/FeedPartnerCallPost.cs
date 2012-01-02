using ClimbFind.Content;
using ClimbFind.Model.Enum;
using System.Collections.Generic;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects.Interfaces;
using ClimbFind.Helpers;
using System;

namespace ClimbFind.Model.Objects
{
	public partial class FeedPartnerCallPost : IPartnerPageItem
    {
        private List<FeedPostComment> _comments = new List<FeedPostComment>();
        public List<FeedPostComment> Comments { get { return _comments; } set { _comments = value; } }
        public Guid UserID { get { return Call.CreatorUserID; } }
        public ClimberProfile User { get { return CFDataCache.GetClimberFromCache(Call.CreatorUserID); } }
        public string UserProfileImgUrl { get { return User.ProfilePictureUrlMini; } }
        public DateTime PostedDateTime { get { return Call.PostedDateTime; } set { } }
        public PartnerCall Call { get; set; }

        public string CommentUrl { get { return "/PartnerCalls/Reply/" + Call.ID; } }
        public string DeleteUrl { get { return "/PartnerCalls/ConfirmDelete/" + Call.ID; } }

        public string RenderHTMLOptions()
        {
            string options = string.Format(@"<a class=""PostComment"" href=""/PartnerCalls/Reply/{0}"">Reply</a>", Call.ID);
            if ((CFProfile.UserID == UserID) || CFProfile.UserIsKrez) { options += string.Format(@"- <a class=""PostDelete"" href=""{0}"">Delete</a>", DeleteUrl); }
            return options;
        }

        public string RenderHTMLPostTopDetails()
        {
            return string.Format(@"<label>#PartnerCall</label><br /><i>Looking for climbers @</i> <img src='{0}' />{1}", 
                Call.FlagImageUrl, Call.PlacesClimbfindUrls);
        }

        public string RenderHTMLPostBody()
        {
            return string.Format("<p>{0}</p>", Call.Message.GetHtmlParagraph());
        }

		public string RenderHTMLOptionsForPartnerPage()
		{
			string options = string.Format(@"<a class=""PostComment"" href=""/PartnerCalls/Reply/{0}"" target=""_blank"">Reply</a>", Call.ID);
			if ((CFProfile.UserID == UserID) || CFProfile.UserIsKrez) { options += string.Format(@"- <a class=""PostDelete"" href=""{0}"" target=""_blank"">Delete</a>", DeleteUrl); }
			return options;
		}

		public string RenderHTMLPostTopDetailsForPartnerPage()
		{
			return RenderHTMLPostTopDetails();
		}

		public string RenderHTMLPostBodyForPartnerPage()
		{
			return RenderHTMLPostBody();
		}
	}
}

