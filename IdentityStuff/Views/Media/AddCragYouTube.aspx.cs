using System;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Controllers;
using ClimbFind.Web.UI;

namespace IdentityStuff.Views.Media
{
    public partial class AddCragYouTube : ClimbFindViewPage<OutdoorCrag>
    {
        public OutdoorCrag Crag { get { return ViewData.Model; } }
        public OutdoorPlace place { get; set; }

        protected void Page_Load(Object sender, EventArgs e)
        {

        }

        protected void AddYouTubeMovie_Click(Object sender, EventArgs e)
        {
            // DO validation
            if (PeterBlum.VAM.Globals.Page.IsValid)
            {
                string youTubeUrl = YouTubeUrlTxB.Text.Trim();
                cfController.AddCragYouTubeMovie(Crag.ID, youTubeUrl, YouTubeTitleTxB.Text, YouTubeDescriptionTxB.Text);

                place = cfController.GetOutdoorPlace(Crag.PlaceID);
                RedirectTo<PlacesController>(c => c.DetailCrag(place.FriendlyUrlLocation, place.FriendlyUrlName, Crag.FriendlyUrlName));
            }
        }    
    
    }
}
