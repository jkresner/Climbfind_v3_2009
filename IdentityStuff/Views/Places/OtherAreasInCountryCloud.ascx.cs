using System.Collections.Generic;
using ClimbFind.Model.Objects;

namespace IdentityStuff.Views.Places
{
    public partial class OtherAreasInCountryCloud : System.Web.Mvc.ViewUserControl<List<AreaTag>>
    {
        public AreaTag CurrentViewedArea { get; set; }
        public List<AreaTag> Areas { get { return ViewData.Model; } }
    }
}
