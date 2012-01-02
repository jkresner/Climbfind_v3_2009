using System;
using System.Linq;
using System.Collections.Generic;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;

namespace ClimbFind.Web.Mvc
{
    public partial class Inbox : ClimbFindViewPage<LoginViewData>
    {
        public List<UserMessage> InboxPartnerCallReplies;
        public List<UserMessage> InboxMessages;
        
        protected void Page_Init(object sender, EventArgs e)
        {
            InboxMessages = cfController.GetUsersInboxMessages();

            InboxPartnerCallReplies = cfController.GetRepliesToUsersPartnerCalls(UserID);

            InboxMessages.AddRange(InboxPartnerCallReplies);
            InboxMessages = (from c in InboxMessages orderby c.SentDateTime descending select c).ToList();
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
