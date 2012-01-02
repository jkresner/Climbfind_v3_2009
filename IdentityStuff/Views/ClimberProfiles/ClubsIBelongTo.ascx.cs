using System.Collections.Generic;
using ClimbFind.Model.Objects;

namespace IdentityStuff.Views.ClimberProfiles
{
    public partial class ClubsIBelongTo : System.Web.Mvc.ViewUserControl<List<Club>>
    {
        protected List<Club> Clubs { get { return ViewData.Model; } }

        //protected void Page_Init(object sender, EventArgs e)
        //{

        //}
    }

}
