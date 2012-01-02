using System;
using ClimbFind.Controller;
using ClimbFind.Model.Objects;

namespace ClimbFind.Web.Mvc.Models.ViewData
{
    public class PartnerCallReplyViewData : IClimbFindBaseViewData
    {
        public PartnerCall Current { get; set; }
        public ClimberProfile PartnerCallPoster { get; set; }

        public PartnerCallReplyViewData(Guid id)
        {
            Current = new CFController().GetPartnerCall(id);
            if (Current != null)
            {
                PartnerCallPoster = new CFController().GetClimberProfile(Current.ClimberProfileID);
            }
        }
    }
}
