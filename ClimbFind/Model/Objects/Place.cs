using System.Collections.Generic;
using ClimbFind.Content;
using ClimbFind.Model.Enum;
using ClimbFind.Model.Objects.Interfaces;

namespace ClimbFind.Model.Objects
{
    public class Place : ClimbFind.Model.LinqToSqlMapping.Place, IClimbingPlace
    {       
        public List<MediaShare> Media { get; set; }

        public string ClimbfindUrl { get { return CFUrlGenerator.GetPlaceUrl(IsIndoor, FriendlyUrlLocation, FriendlyUrlName); }}
        public string ClimbfindRegularsUrl { get { return CFUrlGenerator.GetPlaceRegularsUrl(IsIndoor, FriendlyUrlLocation, FriendlyUrlName); } }
        
        public bool HasPrimaryImage { get { return !(string.IsNullOrEmpty(this.PrimaryImageFile) || this.PrimaryImageFile == "Default.jpg"); } }

        public string PrimaryImageUrl
        {
            get 
            {
                if (IsIndoor) { return string.Format("/images/places/indoor-rock-climbing/logos/{0}", this.PrimaryImageFile); }
                else { return string.Format("/images/places/outdoor-rock-climbing/main/{0}", this.PrimaryImageFile); }
            }
        }

        public string FlagImageUrl
        {
            get
            {
                if (CountryID == 14) { return "~/images/ui/flags/england.png"; }
                else if (CountryID == 15) { return "~/images/ui/flags/scotland.png"; }
                else if (CountryID == 18) { return "~/images/ui/flags/wales.png"; }
                else 
                { 
                    return "~/images/ui/flags/" + FlagList.GetFlag((Nation)CountryID); 
                }
            }
        }

        public string FlagImageUrl2
        {
            get
            {
                return FlagImageUrl.Remove(0,1);
            }
        }
    }
}
