using ClimbFind.Content;
using ClimbFind.Model.Enum;
using System.Collections.Generic;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects.Interfaces;
using ClimbFind.Helpers;
using System;

namespace ClimbFind.Model.Objects
{
    public partial class FeedMoviePost : IFeedItem
    {
        public List<FeedPostComment> Comments { get; set; }
        public Guid UserID { get { return PlaceMedia.SubmittedByUserID;;} }
        public ClimberProfile User { get { return CFDataCache.GetClimberFromCache(UserID); } }
        public string UserProfileImgUrl { get { return User.ProfilePictureUrlMini; } }
        public int PlaceID { get; set; }
        public DateTime PostedDateTime { get { return PlaceMedia.SubmittedDateTime; } set { } }
        public MediaShare PlaceMedia { get; set; }

        public string CommentUrl { get { return "/Media/Detail/" + PlaceMedia.ID; } }
        public string DeleteUrl { get { return "/Media/Delete/" + PlaceMedia.ID; } }
                        
        public string RenderHTMLOptions()
        {
            string options = string.Format(@"<a class=""PostComment"" href=""{0}"">Comment on movie</a> - <a class=""PostDM"" href=""/write-message/{1}"">Msg {2}</a>", 
                    CommentUrl, UserID, User.FullName);
            
            if (CFProfile.UserID == UserID) { options += string.Format(@"- <a class=""PostDelete"" href=""{0}"">Delete</a>", DeleteUrl);  } 
            return options;
        }


        public string RenderHTMLPostTopDetails()
        {
            Place place = CFDataCache.GetPlace(PlaceID);
            return string.Format(@"<br /><b>{0}</b><br /><i>taken</i> @ <img src='{1}' /><a href='{2}'>{3}</a>", 
                PlaceMedia.Name, place.FlagImageUrl2, place.ClimbfindUrl, place.Name);
        }

        public string RenderHTMLPostBody()
        {
            return string.Format("<p>{0}</p><br />{1}", PlaceMedia.Description.GetHtmlParagraph(),
                PlaceMedia.RenderInBrowser());
        }

                //... <a class="PostComment" href="/Media/Detail/<%= media.Key.ID %>">Comment</a></p>


    }
}

