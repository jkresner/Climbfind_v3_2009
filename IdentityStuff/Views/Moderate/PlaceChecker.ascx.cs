using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ClimbFind.Controller;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Enum;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;

namespace IdentityStuff.Views.Moderate
{
    public partial class PlaceChecker : ClimbFindControl
    {
        public string Mode { get; set; }
        protected string SearchService { get; set; }
        public int SelectedPlaceID { get { return int.Parse(ResultsHD.Value); } }

        protected void Page_Init(Object o, EventArgs e)
        {
            SearchService = "/Places/FilterSearch";

            if (Mode == "Outdoor") { SearchService = "/Places/FilterSearchOutdoor"; }
            if (Mode == "Indoor") { SearchService = "/Places/FilterSearchIndoor"; }
        }

        protected void GoToPlacePage_Click(Object o, EventArgs e)
        {
            int selectedPlaceID;
            if (int.TryParse(ResultsHD.Value.ToString(), out selectedPlaceID))
            {
                Place place = new CFController().GetPlace(selectedPlaceID);
                RedirectTo("~"+place.ClimbfindUrl);
            }
        }  
    }

}