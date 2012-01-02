using System;
using ClimbFind.Controller;
using ClimbFind.Model.Objects;

namespace ClimbFind.Web.Mvc.Models.ViewData
{
    public class PartnerCallEditViewData : IClimbFindBaseViewData
    {
        public PartnerCall Current { get; set; }

        public PartnerCallEditViewData(Guid id)
        {
            Current = new CFController().GetPartnerCall(id);
        }
    }
}
