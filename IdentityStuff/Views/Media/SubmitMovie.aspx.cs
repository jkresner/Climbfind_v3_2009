using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClimbFind.Model.Objects;
using ClimbFind.Web.UI;
using ClimbFind.Web.Mvc.Controllers;
using System.Collections.Generic;
using ClimbFind.Web.Mvc.Models.ViewData;

namespace IdentityStuff.Views.Media
{
    public partial class SubmitMovie : ClimbFindViewPage<ISessionViewData>
    {
        protected void SubmitMovie_Click(Object sender, EventArgs e)
        {
            if (PeterBlum.VAM.Globals.Page.IsValid)
            {
                string youTubeUrl = YouTubeUrlTxB.Text.Trim();
                cfController.AddPlaceYouTubeMovie(PlacePickerUC.SelectedPlaceID, youTubeUrl, YouTubeTitleTxB.Text, YouTubeDescriptionTxB.Text);
                RedirectTo<MediaController>(c => c.UsersMedia(UserID));
            }
        }    
    
    }
}
