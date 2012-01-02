using System;
using ClimbFind.Model.Objects;
using ClimbFind.Web.UI;

namespace IdentityStuff.Views.Media
{
    public partial class AddPlaceYouTube : ClimbFindViewPage<Place>
    {
        public Place place { get { return ViewData.Model; } }

        protected void Page_Load(Object sender, EventArgs e)
        {
        }

        protected void AddYouTubeMovie_Click(Object sender, EventArgs e)
        {
            // DO validation
            if (PeterBlum.VAM.Globals.Page.IsValid)
            {
                string youTubeUrl = YouTubeUrlTxB.Text.Trim();
                cfController.AddPlaceYouTubeMovie(place.ID, youTubeUrl, YouTubeTitleTxB.Text, YouTubeDescriptionTxB.Text);
                Response.Redirect("~/"+place.ClimbfindUrl, false);
            }
        }    
    
    }
}
