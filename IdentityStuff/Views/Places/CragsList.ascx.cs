using System.Collections.Generic;
using ClimbFind.Model.Objects;

namespace IdentityStuff.Views.Places
{
    public partial class CragsList : System.Web.Mvc.ViewUserControl<List<OutdoorCrag>>
    {
        public List<OutdoorCrag> Crags { get { return ViewData.Model; } }
        public OutdoorPlace place { get; set; }
    }
}
