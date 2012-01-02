using System;
using System.Web.UI.WebControls;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Controllers;
using ClimbFind.Web.UI;

namespace ClimbFind.Web.Mvc.Views.Media
{
    public partial class EditOutdoorCragPicture : ClimbFindViewPage<OutdoorCrag>
    {
        public OutdoorCrag crag { get { return ViewData.Model; } }
        public OutdoorPlace place { get; set; }
        
        protected void Page_Init(object sender, EventArgs e)
        {
            place = cfController.GetOutdoorPlace(crag.PlaceID);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void SaveImage(FileUpload imageUploader, OutdoorCragSetterDelegate setter)
        {
            if (imageUploader.HasFile)
            {
                //-- save the image:
                setter.DynamicInvoke(crag);

                RedirectTo<PlacesController>(c => c.DetailCrag(place.FriendlyUrlLocation, place.FriendlyUrlName, crag.FriendlyUrlName));
            }
        }

        public void UploadImage_Click(Object Src, EventArgs E)
        {
            SaveImage(Image1UploadUC, c => cfController.SaveOutdoorCragPicture1(c, Image1UploadUC.FileName, Image1UploadUC.FileBytes));
        }

        public void UploadImage2_Click(Object Src, EventArgs E)
        {
            SaveImage(Image2UploadUC, c => cfController.SaveOutdoorCragPicture2(c, Image2UploadUC.FileName, Image2UploadUC.FileBytes));
        }

        public void UploadImage3_Click(Object Src, EventArgs E)
        {
            SaveImage(Image3UploadUC, c => cfController.SaveOutdoorCragPicture3(c, Image3UploadUC.FileName, Image3UploadUC.FileBytes));
        } 

    }
}
