using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using ClimbFind.Controller;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Controllers;
using IdentityStuff.UI.Controls;
using IdentityStuff.Views.ClimberProfiles;
using ClimbFind.Model.Enum;
using System.Web;
using ClimbFind.Model.DataAccess;

namespace ClimbFind.Controls
{
    public static class CFAdControls
    {
        public static string Ad(string adUnitName, int adID)
        {
            string srcUrl = HttpContext.Current.Request.RawUrl.ToString();
            Ad ad = new CFController().GetAdAndRecordImpression(adID, adUnitName);

            return string.Format(@"<a href=""/Ads/Record?adID={0}&srcUrl={1}&destinationUrl={2}"" target=""_blank"">
                <img src=""/images/ads/{3}"" title=""{4}"" style=""{5}"" />
            </a>", adID, srcUrl, ad.DestinationPageUrl, ad.ImageFileName, ad.ProductName, ad.ImageTagStyles);
        }

        public static string IndoorPlaceDetailsRight160(ViewPage page, Place place)
        {
            return page.Html.RenderUserControl("~/Controls/AdUnits/IndoorPlaceDetailsRight160x600.ascx", null, new { place = place });

        }
    }
}
