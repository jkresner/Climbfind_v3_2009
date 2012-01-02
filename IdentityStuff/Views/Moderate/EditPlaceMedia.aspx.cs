using System;
using System.Collections.Generic;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects;
using ClimbFind.Web.UI;

namespace IdentityStuff.Views.Moderate
{
    public partial class EditPlaceMedia : ClimbFindViewPage<Place>
    {
        public Place place { get { return ViewData.Model; } }
        public List<MediaShare> Media { get { return cfController.GetMediaForPlace(place.ID); } }

        protected string GetClimberName(Guid id)
        {
            return CFDataCache.GetClimberFromCache(id).NickName;
        }

        protected void Page_Load(Object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }

        protected void AddYouTubeMovie_Click(Object sender, EventArgs e)
        {
            // DO validation
            if (PeterBlum.VAM.Globals.Page.IsValid)
            {
                string youTubeUrl = YouTubeUrlTxB.Text;
                cfController.AddPlaceYouTubeMovie(place.ID, youTubeUrl, YouTubeTitleTxB.Text, YouTubeDescriptionTxB.Text);
                Response.Redirect("~/"+place.ClimbfindUrl, false);
            }
        }    
    
    }
}
