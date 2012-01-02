using System.Collections.Generic;
using ClimbFind.Model.Objects;
using ClimbFind.Helpers;
using System;
using System.Linq;


namespace IdentityStuff.Views.Places
{
    public partial class PeopleClimbingAtPlaceList : System.Web.Mvc.ViewUserControl<List<PartnerCall>>
    {
        public string PlaceFriendlyUrlLocation { get; set; }
        public string PlaceFriendlyUrlName { get; set; }
        public string PlaceName { get; set; }
        public List<PartnerCall> PartnerCalls { get { return ViewData.Model; } }
        public List<PartnerCall> DistinctUserPartnerCalls { get; set; }
        public List<PartnerCall> PartnerCallsToDisplay { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            DistinctUserPartnerCalls = PartnerCalls.GetDistinctUserCalls();
            PartnerCallsToDisplay = DistinctUserPartnerCalls.Take(4).ToList();
        }
    }
}
