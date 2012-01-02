using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;

namespace ClimbFind.Web.Mvc.Views.Moderate
{
    public partial class OutdoorCragList : ClimbFindViewPage<ISessionViewData>
    {
        protected List<OutdoorCrag> Crags;

        protected void Page_Init(Object s, EventArgs e)
        {
            Crags = (from c in cfController.GetAllOutdoorCrags() orderby c.Name select c).ToList();
        }
    }
}
