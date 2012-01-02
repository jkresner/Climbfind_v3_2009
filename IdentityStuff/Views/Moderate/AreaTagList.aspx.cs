using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;

namespace ClimbFind.Web.Mvc.Views.Moderate
{
    public partial class AreaTagList : ClimbFindViewPage<ISessionViewData>
    {
        protected List<AreaTag> Tags;

        protected void Page_Init(Object s, EventArgs e)
        {
            Tags = (from c in cfController.GetAllAreaTags() orderby c.CountryID, c.Name select c).ToList();
        }
    }
}
