using System;
using ClimbFind.Content;
using ClimbFind.Model.Objects.Interfaces;
using ClimbFind.Model.Enum;

namespace ClimbFind.Model.Objects
{
    public delegate void OutdoorPlaceSetterDelegate(OutdoorPlace place);
    public delegate object OutdoorPlaceGetterDelegate(OutdoorPlace place);
    
    public class OutdoorPlace : ClimbFind.Model.LinqToSqlMapping.PlaceOutdoorDetail, IClimbingPlace
    {
        public Guid CreatedByUserID { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; } 
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string FriendlyUrlName { get; set; }
        public string FriendlyUrlLocation { get; set; }
        public Guid MessageBoardID { get; set; }
        public bool IsIndoor { get { return false; } set { ;} }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public short CountryID { get; set; }

        private string MainPictureDirectory = "/images/places/outdoor-rock-climbing/main/";
        private string MainPictureDefaultFile = "default.jpg";
        public string MainPictureDefaultUrl { get { return MainPictureDirectory + MainPictureDefaultFile; } }

        public string DescriptionImageUrl { get { return string.Format("{0}{1}", MainPictureDirectory, DescriptionImageFile); } }

        public string DescriptionImageUrl2
        {
            get { if (String.IsNullOrEmpty(DescriptionImageFile2)) { return MainPictureDefaultUrl; }
            return string.Format("{0}{1}", MainPictureDirectory, DescriptionImageFile2); }        
        }

        public string DescriptionImageUrl3
        {
            get { if (String.IsNullOrEmpty(DescriptionImageFile3)) { return MainPictureDefaultUrl; }
            return string.Format("{0}{1}", MainPictureDirectory, DescriptionImageFile3); }
        }

        //public string PrimaryImageUrl { get { return DescriptionImageUrl; } set { } }

        public string ClimbfindUrl { get { return CFUrlGenerator.GetOutdoorPlaceUrl(FriendlyUrlLocation, FriendlyUrlName); } }
    }
}
