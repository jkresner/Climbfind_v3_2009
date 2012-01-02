using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Objects;

namespace IdentityStuff.Views.ClimberProfiles
{
    public class RegularsShortlistViewData
    {
        public int MaxDisplayCount { get; set; }
        public Place place { get; set; }
        public List<ClimberProfile> Regulars { get; set; }
    }
    
    public partial class RegularsShortlist : System.Web.Mvc.ViewUserControl<RegularsShortlistViewData>
    {
        public List<ClimberProfile> RegularsToDisplay 
        { 
            get 
            {               
                List<ClimberProfile> filteredList = (from c in ViewData.Model.Regulars where !c.ImageNotUploaded select c).ToList();
                if (filteredList.Count > 5) { return filteredList.RandomSample(ViewData.Model.MaxDisplayCount); }
                else { return ViewData.Model.Regulars.RandomSample(ViewData.Model.MaxDisplayCount); }                
            } 
        }

        public int DisplayCount { get { return RegularsToDisplay.Count; } }
        public int TotalCount { get { return ViewData.Model.Regulars.Count; } }
        public string PlaceName { get { return ViewData.Model.place.Name; } }
        public string PlaceNameShort { get { return ViewData.Model.place.ShortName; } }
        public string PlaceUrl { get { return ViewData.Model.place.ClimbfindUrl; } }
        public string AllRegularsForPlaceUrl { get { return ViewData.Model.place.ClimbfindRegularsUrl; } }
    }
}
