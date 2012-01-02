using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Objects;

namespace IdentityStuff.Views.ClimberProfiles
{
    public partial class PlacesIClimb : System.Web.Mvc.ViewUserControl<ClimberProfile>
    {
        public ClimberProfile climberProfile { get { return ViewData.Model; } }
       
        protected List<Place> indoorPlaces;
        protected List<Place> outdoorPlaces;
        protected List<short> countriesIClimb;

        protected void Page_Init(object sender, EventArgs e)
        {
            indoorPlaces = (from c in climberProfile.PlacesUserClimbs where c.IsIndoor select c).ToList();
            outdoorPlaces = (from c in climberProfile.PlacesUserClimbs orderby c.CountryID where !c.IsIndoor select c).ToList();

            countriesIClimb = (from c in outdoorPlaces select c.CountryID).Distinct().ToList();
        }

        protected string getCountrysPlaceWhereUserClimbs(short countryID)
        {
            List<Place> countrysPlaces = (from c in outdoorPlaces where c.CountryID == countryID select c).ToList();
            string placesUrls = "";
            foreach (Place p in countrysPlaces) { placesUrls += string.Format("<a href='{0}'>{1}</a>, ", p.ClimbfindUrl, p.ShortName); }
            return placesUrls.Substring(0, placesUrls.Length - 2);
        }
    }

}
