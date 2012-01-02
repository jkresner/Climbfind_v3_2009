using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Controller;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects;

namespace IdentityStuff.Views.Home
{
    public partial class IndexMovieFeed : System.Web.Mvc.ViewUserControl
    {
        public Dictionary<MediaShare, int> LatestMedia;

        protected void Page_Init(Object o, EventArgs e)
        {
            LatestMedia = new CFController().GetLatestPlaceYouTubeMovies(4);
        }   
    }
}