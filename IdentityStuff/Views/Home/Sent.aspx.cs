using System;
using System.Linq;
using System.Collections.Generic;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;

namespace ClimbFind.Web.Mvc
{
    public partial class Sent : ClimbFindViewPage<LoginViewData>
    {
        public List<UserMessage> SentPartnerCallReplies;
        public List<UserMessage> SentMessages;
        protected int myRepliesCount = 1;

        
        protected void Page_Init(object sender, EventArgs e)
        {
            SentMessages = cfController.GetUsersSentMessages();
            SentPartnerCallReplies = cfController.GetUserPartnerCallRepliesAsMessages(UserID);

            SentMessages.AddRange(SentPartnerCallReplies);
            SentMessages = (from c in SentMessages orderby c.SentDateTime descending select c).ToList();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected string GetUsersFullName(Guid userID)
        {
            return CFDataCache.GetClimberFromCache(userID).FullName;
        }

        protected string GetUsersPic(Guid userID)
        {
            return CFDataCache.GetClimberFromCache(userID).ProfilePictureUrlMini;
        }
    }
}
