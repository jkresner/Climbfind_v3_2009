using System;
using System.Web.UI.WebControls;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Controllers;
using ClimbFind.Web.UI;

namespace ClimbFind.Web.Mvc.Views.Media
{
    public partial class EditOutdoorLocationPictures : ClimbFindViewPage<OutdoorPlace>
    {
        public OutdoorPlace place { get { return ViewData.Model; } }
        
        protected void Page_Init(object sender, EventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void SavePlaceImage(FileUpload imageUploader, OutdoorPlaceSetterDelegate setter)
        {
            if (imageUploader.HasFile)
            {
                setter.DynamicInvoke(place);
                RedirectTo<PlacesController>(c => c.DetailOutdoor(place.FriendlyUrlLocation, place.FriendlyUrlName));
            }
        }


        public void UploadImage_Click(Object Src, EventArgs E)
        {
            SavePlaceImage(Image1UploadUC, c => cfController.SaveOutdoorPlacePicture1(c, Image1UploadUC.FileName, Image1UploadUC.FileBytes));
        }

        public void UploadImage2_Click(Object Src, EventArgs E)
        {
            SavePlaceImage(Image2UploadUC, c => cfController.SaveOutdoorPlacePicture2(c, Image2UploadUC.FileName, Image2UploadUC.FileBytes));
        }

        public void UploadImage3_Click(Object Src, EventArgs E)
        {
            SavePlaceImage(Image3UploadUC, c => cfController.SaveOutdoorPlacePicture3(c, Image3UploadUC.FileName, Image3UploadUC.FileBytes));
        } 
    }
}
