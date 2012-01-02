using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects;
using ClimbFind.Web.UI;

namespace IdentityStuff.Views.Moderate
{
    public partial class EditPlaceMap : ClimbFindViewPage<Place>
    {
        public Place place { get { return ViewData.Model; } }

        protected void Page_Load(Object o, EventArgs e)
        {
            MapCoordinatePickerUC.SetPoint(place.Latitude, place.Longitude);
        }

        protected void SaveMap_Click(Object o, EventArgs e)
        {
            place.Latitude = MapCoordinatePickerUC.Latitude;
            place.Longitude = MapCoordinatePickerUC.Longitude;
            cfController.UpdatePlaceCoordinates(place);
            RedirectTo("~"+place.ClimbfindUrl);
        }

    }
}
