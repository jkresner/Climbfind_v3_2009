using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;

namespace ClimbFind.Web.Mvc.Views.Admin
{
    public partial class PlaceList : ClimbFindViewPage<ISessionViewData>
    {
        protected List<AreaTag> AllAreaTags;
        protected List<OutdoorPlace> OutdoorPlaces;
        protected List<IndoorPlace> IndoorPlaces;


        protected void Page_Init(Object s, EventArgs e)
        {
            AllAreaTags = cfController.GetAllAreaTags();
            
            //IndoorPlacesGV.DataSource =
            IndoorPlaces = (from c in cfController.GetAllIndoorPlaces() orderby c.CountryID, c.Name select c).ToList();
            OutdoorPlaces = (from c in cfController.GetAllOutdoorPlaces() orderby c.CountryID, c.Name select c).ToList();
        }
   


    }
}
