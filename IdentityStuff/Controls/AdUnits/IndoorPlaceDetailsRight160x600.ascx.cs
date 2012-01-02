using System;
using ClimbFind.Controller;
using ClimbFind.Model.Objects;
using ClimbFind.Model.DataAccess;
namespace ClimbFind.Web.Mvc.Controls.AdUnits
{
    public partial class IndoorPlaceDetailsRight160x600 : System.Web.Mvc.ViewUserControl
    {
        public Place place { get; set; }

        public bool PlaceInLondon { get { return new CFController().PlaceBelongsToArea(place.ID, 1);} }

        protected void Page_Load(object o, EventArgs e)
        {
            
            
            if (place == null) { throw new Exception("Cannot run ad without place specified"); }
        }
    }
}
