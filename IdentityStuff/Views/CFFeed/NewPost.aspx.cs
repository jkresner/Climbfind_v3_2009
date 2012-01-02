using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClimbFind.Web.UI;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Controllers;
using ClimbFind.Model.DataAccess;
using System.Text;

namespace IdentityStuff.Views.CFFeed
{
    public partial class NewPost : ClimbFindViewPage<Place>
    {
        public Place place { get { return ViewData.Model; } }

        protected void Page_Load(Object o, EventArgs e)
        {

        }

        private DateTime GetSelectedDateAndTime()
        {
            DateTime climbingDateTime = DateTime.Now;
            DateTime.TryParse(DateTxB.Text, out climbingDateTime);
            return climbingDateTime;
        }

        protected void SavePost_Click(Object sender, EventArgs e)
        {
            if (PeterBlum.VAM.Globals.Page.IsValid)
            {
                cfController.SaveFeedPost(
                  new FeedClimbingPost
                  {
                      ClimbingDateTime = GetSelectedDateAndTime(),
                      Message = MessageTxB.Text,
                      TagID = byte.Parse(TagIDHD.Value),
                      PlaceID = place.ID,
                      UserID = UserID
                  }
                );

                RedirectTo<HomeController>(c => c.Index());
            }
        }


        protected string GetTagsFor(string category)
        {
            StringBuilder sb = new StringBuilder();
            List<FeedTag> tags = (from c in CFDataCache.AllFeedTags where c.Category == category select c).ToList();
            foreach (FeedTag t in tags)
            {
                sb.AppendFormat(@"<div><input id='{0}RB' name='Tag' type='radio' value='{0}' /> #{1}</div>", t.ID, t.Name);
            }
                
            return sb.ToString();
        }

    }
}
