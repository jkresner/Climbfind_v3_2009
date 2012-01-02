using System;
using ClimbFind.Content;
using ClimbFind.Model.Objects.Interfaces;
using ClimbFind.Model.Enum;

namespace ClimbFind.Model.Objects
{
    public class IndoorPlace : ClimbFind.Model.LinqToSqlMapping.PlaceIndoorDetail, IClimbingPlace
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }      
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string FriendlyUrlName { get; set; }
        public string FriendlyUrlLocation { get; set; }
        public Guid MessageBoardID { get; set; }
        public bool IsIndoor { get { return true; } set { ;} }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public short CountryID { get; set; }
        public Guid CreatedByUserID { get; set; }

        public string LogoHalfSizeImageUrl { get { return string.Format("/images/places/indoor-rock-climbing/logos/half/{0}", LogoImageFile); } }
        public string LogoImageUrl { get { return string.Format("/images/places/indoor-rock-climbing/logos/{0}", LogoImageFile); } }
        public string ClimbfindUrl { get { return CFUrlGenerator.GetIndoorPlaceUrl(FriendlyUrlLocation, FriendlyUrlName); } }
    }
}
