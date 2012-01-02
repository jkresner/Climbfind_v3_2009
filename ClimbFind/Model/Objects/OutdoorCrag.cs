using System;
using ClimbFind.Model.Enum;
using ClimbFind.Content;

namespace ClimbFind.Model.Objects
{
    public delegate void OutdoorCragSetterDelegate(OutdoorCrag crag);
    public delegate object OutdoorCragGetterDelegate(OutdoorCrag crag);

    
    public class OutdoorCrag : ClimbFind.Model.LinqToSqlMapping.PlaceOutdoorCrag
    {
        public string CragTypeString { get { return ((CragType)Type).ToString().ToLower(); } }

    
        private string MainPictureDirectory = "/images/places/outdoor-rock-climbing/crags/";
        private string MainPictureDefaultFile = "default.jpg";

        public string MainPictureDefaultUrl { get { return MainPictureDirectory + MainPictureDefaultFile; } }

        public string DescriptionImage1Url
        {
            get { if (String.IsNullOrEmpty(DescriptionImageFile1)) { return MainPictureDefaultUrl; }
            return string.Format("{0}{1}", MainPictureDirectory, DescriptionImageFile1);
        }
        }

        public string DescriptionImage2Url
        {
            get { if (String.IsNullOrEmpty(DescriptionImageFile2)) { return MainPictureDefaultUrl; }
            return string.Format("{0}{1}", MainPictureDirectory, DescriptionImageFile2);
        }
        }

        public string DescriptionImage3Url
        {
            get
            {
                if (String.IsNullOrEmpty(DescriptionImageFile3)) { return MainPictureDefaultUrl; }
                return string.Format("{0}{1}", MainPictureDirectory, DescriptionImageFile3);
            }
        }

        public string FriendlyUrlLocation { get; set; }
        public string FriendlyUrlPlaceName { get; set; }

        public string ClimbfindUrl { get { return CFUrlGenerator.GetOutdoorCragUrl(FriendlyUrlLocation, FriendlyUrlPlaceName, FriendlyUrlName); } }
    }
}
