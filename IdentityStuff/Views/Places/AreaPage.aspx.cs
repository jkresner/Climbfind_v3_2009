using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClimbFind.Helpers;
using ClimbFind.Model.Objects;
using ClimbFind.Web.UI;
using ClimbFind.Model.Objects.Interfaces;
using ClimbFind.Model.DataAccess;

namespace IdentityStuff.Views.Places
{
    public partial class AreaPage : ClimbFindViewPage<AreaTag>
    {
        public AreaTag Area { get { return ViewData.Model; } }
        public List<Place> PlacesInThisArea { get; set; }
        public List<IndoorPlace> IndoorPlacesInThisArea { get; set; }
        public List<OutdoorPlace> OutdoorPlacesInThisArea { get; set; }
        public List<Club> ClubsInThisArea { get; set; }
        public string MapDivID { get { return string.Format("Map-Of-Climbing-Around-{0}", Area.ParagraphName.Replace(" ", "-")); } }
        public string MapTitle { get { return string.Format("Map showing climbing locations around {0}", Area.ParagraphName); } }
        public bool DisplayPlaceImage { get; set; }

        protected void Page_Init(object o, EventArgs e)
        {
            PlacesInThisArea = cfController.GetPlacesInArea(ViewData.Model.ID);

            IndoorPlacesInThisArea = cfController.GetIndoorPlacesInArea(ViewData.Model.ID);
            OutdoorPlacesInThisArea = cfController.GetOutdoorPlacesInArea(ViewData.Model.ID);
            ClubsInThisArea = cfController.GetClubsInArea(ViewData.Model.ID).OrderBy(c => c.Name).ToList();

            Ad.Area = Area;

            DisplayPlaceImage = !((Area.ID == 2) || (Area.ID == 38) || (Area.ID == 9));
        }    
    }
}










