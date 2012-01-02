using System;
using System.Web.Mvc;

namespace ClimbFind.Web.Mvc.Views.Shared
{
    public partial class ViewStateFriendly : ViewMasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            this.ID = "cf";

            if (ViewData["PageTitle"] == null) { throw new Exception("Page has not set meta data"); }
        }
    }
}
