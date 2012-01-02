using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Objects;
using ClimbFind.Web.UI;
using ClimbFind.Controller;
using ClimbFind.Model.Enum;
using System.Web.Mvc;

namespace IdentityStuff.Views.Places
{
    public partial class SeekingPartnersRSS : ViewPage<Place>
    {
        public int i=1;
        public Place place { get { return ViewData.Model; } }
        public List<ClimberProfile> ClimbersSeekingPartners { get; set; }
        public List<PartnerCall> CallsForPlace { get; set; }

        public string PubDate 
        { 
            get 
            {
                if (CallsForPlace.Count > 0)
                {
                    return CallsForPlace[CallsForPlace.Count - 1].PostedDateTime.ToString("ddd, dd MMM yyyy HH:mm:ss");
                }
                else { return DateTime.Now.ToString("ddd, dd MMM yyyy HH:mm:ss"); }
            } 
        }

        public string LastBuildDate
        {
            get
            {
                if (CallsForPlace.Count > 0)
                {
                    return CallsForPlace[0].PostedDateTime.ToString("ddd, dd MMM yyyy HH:mm:ss");
                }
                else { return DateTime.Now.ToString("ddd, dd MMM yyyy HH:mm:ss"); }
            }
        }

        protected void Page_Init(Object s, EventArgs e)
        {
            CallsForPlace = new CFController().GetPartnerCallsForPlace(place.ID);
        }


    }
}
