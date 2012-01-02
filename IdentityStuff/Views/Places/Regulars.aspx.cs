using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Objects;
using ClimbFind.Web.UI;
using ClimbFind.Model.Enum;

namespace IdentityStuff.Views.Places
{
    public partial class Regulars : ClimbFindViewPage<Place>
    {
        public Place place { get { return ViewData.Model; } }
        public List<ClimberProfile> RegularClimbers { get; set; }

        protected void Page_Init(Object s, EventArgs e)
        {
            RegularClimbers = 
                (from c in cfController.GetClimbersThatClimbAtPlace(place.ID) orderby c.FullName select c).ToList();

            AreaAd.Area = cfController.GetAreaTagForCountry((Nation)place.CountryID);            
        }
    }
}
