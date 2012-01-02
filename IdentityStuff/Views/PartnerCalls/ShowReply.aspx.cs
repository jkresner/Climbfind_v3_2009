using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;

namespace IdentityStuff.Views.PartnerCalls
{
    public partial class ShowReply : ClimbFindViewPage<PartnerCallShowReplyViewData>
    {
        public PartnerCall CurrentCall { get { return ViewData.Model.CurrentCall; } }
        public PartnerCallReply CurrentReply { get { return ViewData.Model.CurrentReply; } }
        public ClimberProfile Replier { get { return ViewData.Model.Replier; } }

    }
}
