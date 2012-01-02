using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Objects;
using ClimbFind.Web.UI;
using ClimbFind.Controller;
using ClimbFind.Model.DataAccess;

namespace IdentityStuff.Views.Places
{
    public partial class PartnerWidget : ClimbFindViewPage<Place>
    {
        public int i=1;
        public int ResulsToDisplay = 6, numberOfDesiredResults ;
        public string CSS = "";
        public string SiteName = "";
        public Place place { get { return ViewData.Model; } }
        public List<ClimberProfile> ClimbersSeekingPartners { get; set; }
        public List<PartnerCall> CallForPlace { get; set; }
        public PartnerWidgetCSS Styles;

        public bool ShowPictures = true, ShowClimbingTypes = true, ShowMessages = true;

        protected void Page_Init(Object s, EventArgs e)
        {
            if (Request.QueryString["Results"] != null) 
            {
                if ( int.TryParse(Request.QueryString["Results"].ToString(), out numberOfDesiredResults) )
                {
                    if (numberOfDesiredResults < 20 && numberOfDesiredResults > 3) { ResulsToDisplay = numberOfDesiredResults; }                
                }
            }

            if (Request.QueryString["Types"] != null)
            {
                if (Request.QueryString["Types"].ToString() == "F") { ShowClimbingTypes = false; }
            }

            if (Request.QueryString["Site"] != null)
            {
                SiteName = Request.QueryString["Site"].ToString();
                Styles = new PartnerWidgetCSSDA().GetByID(SiteName);
            }

            CallForPlace = (from c in cfController.GetPartnerCallsForPlace(place.ID) orderby c.PostedDateTime descending select c).ToList();
            CallForPlace = CallForPlace.Take(ResulsToDisplay).ToList();
        }


        protected string ShowClimbingTypeDIVHtml(string type, bool show)
        {
            if (!show) { return ""; }
            else if (type == "TopRope")
            {
                return @"<div class=""ClimbingType""><div>Top rope</div><img src=""/images/UI/cf/TopRope.bmp"" /></div>";
            }
            else if (type == "Lead")
            {
                return @"<div class=""ClimbingType""><div>Lead</div><img src=""/images/UI/cf/Lead.bmp"" /></div>";
            }
            else if (type == "Boulder")
            {
                return @"<div class=""ClimbingType""><div>Boulder</div><img src=""/images/UI/cf/Boulder.bmp"" alt=""Boulder"" /></div>";
            }
            else { return (""); }
        }
    }
}
