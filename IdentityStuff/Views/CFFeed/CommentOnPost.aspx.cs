using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClimbFind.Web.UI;
using ClimbFind.Model.Objects;
using ClimbFind.Model.DataAccess;
using ClimbFind.Web.Mvc.Controllers;

namespace IdentityStuff.Views.CFFeed
{
    public partial class CommentOnPost : ClimbFindViewPage<FeedClimbingPost>
    {
        public FeedClimbingPost post { get { return ViewData.Model; } }

        public ClimberProfile Poster { get { return CFDataCache.GetClimberFromCache(post.UserID); } }


        public void Comment_Click(Object s, EventArgs e)
        {
            if (PeterBlum.VAM.Globals.Page.IsValid)
            {
                cfController.SaveFeedPostComment(new FeedPostComment { FeedPostID = post.ID, UserID = UserID, Message = MessageTxB.Text });
                post.Comments = cfController.GetFeedClimbingPost(post.ID).Comments;
                MessageTxB.Text = "";
            }
        }


        public ClimberProfile GetProfile(Guid userID)
        {
            return CFDataCache.GetClimberFromCache(userID);
        }


        protected string GetTagsString(byte tagID)
        {
            if (tagID == 0) { return ""; }
            else
            {
                return "#" + (from c in CFDataCache.AllFeedTags where c.ID == tagID select c.Name).SingleOrDefault();
            }
        }
    }
}
