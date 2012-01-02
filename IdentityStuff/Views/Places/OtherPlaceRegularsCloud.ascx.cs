using System.Collections.Generic;
using ClimbFind.Controller;
using ClimbFind.Model.Objects;

namespace IdentityStuff.Views.Places
{
    public partial class OtherPlaceRegularsCloud : System.Web.Mvc.ViewUserControl
    {
        public List<Place> AllPlaces { get { return new CFController().GetAllPlaces(); } }
    }
}
