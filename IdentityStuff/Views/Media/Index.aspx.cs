using System.Collections.Generic;
using System.Web.Mvc;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;
using System;

namespace IdentityStuff.Views.Media
{
    public partial class Index : ClimbFindViewPage<ISessionViewData>
    {
        public Dictionary<MediaShare, int> LatestMedia, YourMedia, BestMedia;

        protected void Page_Load(Object o, EventArgs e)
        {
            LatestMedia = cfController.GetLatestPlaceYouTubeMovies(15);
        }  

    }
}
