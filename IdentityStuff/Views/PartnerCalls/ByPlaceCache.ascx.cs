using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Controller;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects;
using ClimbFind.Helpers;


namespace IdentityStuff.Views.PartnerCalls
{
    public partial class ByPlaceCache : System.Web.Mvc.ViewUserControl
    {
        protected int i = 1;

        protected List<PartnerCall> AllPartnerCalls;
    
        protected List<Place> IndoorWithCalls;
        protected List<Place> OutdoorWithCalls;
        protected List<int> PlaceIDsWithCalls;

        protected List<short> IndoorCountryIDs;
        protected List<short> OutdoorCountryIDs;

        protected List<PartnerCall> LastestIndoorPartnerCalls;
        protected List<PartnerCall> LastestOutdoorPartnerCalls;

        /// <summary>
        /// 
        /// </summary>
        protected void Page_Init(object sender, EventArgs e)
        {
            AllPartnerCalls = new CFController().GetAllPartnerCalls();
            
            PlaceIDsWithCalls = new CFController().GetPlaceIDsWithCalls();
            IndoorWithCalls = (from c in CFDataCache.AllPlaces where PlaceIDsWithCalls.Contains(c.ID) && c.IsIndoor orderby c.CountryID, c.Name select c).ToList();
            OutdoorWithCalls = (from c in CFDataCache.AllPlaces where PlaceIDsWithCalls.Contains(c.ID) && !c.IsIndoor orderby c.CountryID, c.Name select c).ToList();

            IndoorCountryIDs = (from c in IndoorWithCalls select c.CountryID).Distinct().ToList();
            IndoorCountryIDs = (from c in OutdoorWithCalls select c.CountryID).Distinct().ToList();

            LastestIndoorPartnerCalls = (from c in AllPartnerCalls orderby c.PostedDateTime descending where c.IsIndoor select c).Take(30).ToList().GetDistinctUserCalls();
            LastestOutdoorPartnerCalls = (from c in AllPartnerCalls orderby c.PostedDateTime descending where !c.IsIndoor select c).Take(30).ToList().GetDistinctUserCalls();
        }
    }
}