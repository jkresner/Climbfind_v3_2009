using System;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Controllers;
using ClimbFind.Web.UI;

namespace IdentityStuff.Views.Moderate
{
    public partial class EditClubLogo : ClimbFindViewPage<Club>
    {
        public Club club { get { return ViewData.Model; } }

        protected void Page_Load(Object sender, EventArgs e)
        {
            
        }
      
        public void UploadImage_Click(Object Src, EventArgs E)
        {
            if (ImageUploadUC.HasFile)
            {
                //-- save the image:
                cfController.SaveClubLogo(club, ImageUploadUC.FileName, ImageUploadUC.FileBytes);

                RedirectTo<ClubsController>(c => c.Detail(club.FriendlyCountryUrl, club.FriendlyUrlName));
            }
        }
    }
}
