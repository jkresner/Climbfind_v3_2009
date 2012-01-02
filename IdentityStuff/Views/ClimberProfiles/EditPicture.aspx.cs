using System;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Controllers;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;

namespace ClimbFind.Web.Mvc.Views.ClimberProfiles
{
    public partial class EditPicture : ClimbFindViewPage<ISessionViewData>
    {
        public ClimberProfile profile;

        protected void Page_Init(object sender, EventArgs e)
        {
            profile = cfController.GetClimberProfile(UserID);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }


        public void UploadImage_Click(Object Src, EventArgs E)
        {           
            if (ProfileImageUploadUC.HasFile)
            {
                ClimberProfile profile = cfController.GetClimberProfile(UserID);
                
                //-- save the image:
                cfController.SaveClimberProfilePicture(profile, ProfileImageUploadUC.FileName,
                    ProfileImageUploadUC.FileBytes);

                RedirectTo<ClimberProfilesController>(c => c.Me()); 
            }
        }
    }
}
