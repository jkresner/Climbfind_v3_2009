using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Objects;
using ClimbFind.Web.UI;
using ClimbFind.Controller;
using ClimbFind.Helpers;
using ClimbFind.Model.Objects.Interfaces;
using ClimbFind.Model.Enum;
using ClimbFind.Model.DataAccess;


namespace IdentityStuff.Views.Places
{
    public partial class PartnerWidget2 : ClimbFindViewPage<Place>
    {
        public string CSS = "";
        public string SiteName = "";
        public PartnerWidgetCSS Styles;
        public Place place { get { return ViewData.Model; } }
		public List<IPartnerPageItem> FeedPosts { get; set; } 

        protected void Page_Init(Object s, EventArgs e)
        {
            FeedPosts = cfController.GetPlacesPartnerPageFeedActivity(place.ID);

            if (Request.QueryString["Site"] != null)
            {
                SiteName = Request.QueryString["Site"].ToString();
                Styles = new PartnerWidgetCSSDA().GetByID(SiteName);
            }
        }
    }
}
