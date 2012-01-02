using System;
using ClimbFind.Controller;
using ClimbFind.Model.Objects;

namespace ClimbFind.Web.Mvc.Models.ViewData
{
    public class PartnerCallShowReplyViewData : IClimbFindBaseViewData
    {
        public PartnerCall CurrentCall { get; set; }
        public PartnerCallReply CurrentReply { get; set; }
        public ClimberProfile Replier { get; set; }

        public PartnerCallShowReplyViewData(Guid id)
        {
            CFController cf = new CFController();
            
            CurrentReply = cf.GetPartnerCallReply(id);
            CurrentCall = cf.GetPartnerCall(CurrentReply.PartnerCallID);
            Replier = cf.GetClimberProfile(CurrentReply.ReplyingUserID);
         }
    }
}
