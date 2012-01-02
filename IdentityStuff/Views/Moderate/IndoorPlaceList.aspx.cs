using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;

namespace ClimbFind.Web.Mvc.Views.Moderate
{
    public partial class IndoorPlaceList : ClimbFindViewPage<ISessionViewData>
    {
        protected List<IndoorPlace> IndoorPlaces;


        protected void Page_Init(Object s, EventArgs e)
        {           
            IndoorPlaces = (from c in cfController.GetAllIndoorPlaces() orderby c.Name select c).ToList();
        }
    }
}
