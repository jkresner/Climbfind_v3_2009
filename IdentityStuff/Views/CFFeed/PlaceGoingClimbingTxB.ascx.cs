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

namespace IdentityStuff.Views.CFFeed
{
    public partial class PlaceGoingClimbingTxB : ClimbFindControl
    {
        public string Mode { get; set; }
        protected string SearchService { get; set; }

        protected void Page_Init(Object o, EventArgs e)
        {
            SearchService = "/Places/FilterSearch";
        }
    }
}