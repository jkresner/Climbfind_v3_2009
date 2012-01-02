using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;

namespace ClimbFind.Web.Mvc.Views.Moderate
{
    public partial class OutdoorPlaceList : ClimbFindViewPage<ISessionViewData>
    {
        protected List<OutdoorPlace> OutdoorPlaces;

        protected void Page_Init(Object s, EventArgs e)
        {
            OutdoorPlaces = (from c in cfController.GetAllOutdoorPlaces() orderby c.CountryID, c.Name select c).ToList();
        }
    }
}
