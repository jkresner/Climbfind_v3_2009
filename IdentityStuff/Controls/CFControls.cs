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
    public static class CFControls
    {
        public static string ProfileImagePreview(this HtmlHelper html, string previewImageHtml, string fullSizeImageFileSrc, string title)
        {
            return string.Format(@"<a href=""{0}{1}"" class=""preview"" title=""{2}""><img id=""profileImg"" src=""{3}"" alt=""{2}"" /></a>",
                CFSettings.WebAddress.TrimEnd(new char[] { '/' }), fullSizeImageFileSrc, title, previewImageHtml);
        }

        public static string ImagePreview(this HtmlHelper html, string previewImageHtml, string fullSizeImageFileSrc, string title)
        {
            var webUrl = CFSettings.WebAddress.TrimEnd(new char[] { '/' });
            
            return string.Format(@"<a href=""{0}{1}"" class=""preview"" title=""{2}""><img src=""{3}"" alt=""{2}"" /></a>",
                webUrl, fullSizeImageFileSrc, title, previewImageHtml);
        }

        public static string MediaList(ViewPage page, List<MediaShare> media)
        {
            return page.Html.RenderUserControl("~/Views/Media/MediaList.ascx", media);
        } 
        
        public static string PeopleClimbingAtPlaceList(ViewPage page, List<PartnerCall> partnerCalls, string placeName, string urlLocation, string urlName)
        {
            return page.Html.RenderUserControl("~/Views/Places/PeopleClimbingAtPlaceList.ascx", partnerCalls, new { PlaceName = placeName, PlaceFriendlyUrlLocation = urlLocation, PlaceFriendlyUrlName = urlName });
        }

        public static string StarRating(ViewPage page, double rating)
        {
            return page.Html.RenderUserControl("~/Controls/StarRating.ascx", null, new { Rating = rating });
        }

        public static string OtherAreasInCountryCloud(ViewPage page, Nation nation)
        {
            AreaTag currentViewedArea = (from c in CFDataCache.AllAreaTags where c.CountryID == (short)nation && c.IsCountry select c).SingleOrDefault();
            List<AreaTag> areasInSameCountry = new CFController().GetAllAreaTagsInCountry(nation);

            return page.Html.RenderUserControl("~/Views/Places/OtherAreasInCountryCloud.ascx",
               areasInSameCountry, new { CurrentViewedArea = currentViewedArea });
        }

        public static string OtherPlaceRegularsCloud(ViewPage page, AreaTag currentViewedArea, bool isForIndoor)
        {
            return page.Html.RenderUserControl("~/Views/Places/OtherPlaceRegularsCloud.ascx");
        }     

        public static string ClimberProfileLink(ViewPage page, ClimberProfile climberProfile)
        {
            return ClimberProfileLink(page, climberProfile.ID, page.Html.Encode(climberProfile.FullName) );
        }

        public static string ClimberProfileLink(ViewUserControl control, ClimberProfile climberProfile)
        {
            return ClimberProfileLink((ViewPage)control.Page, climberProfile);
        }
        

        public static string ClimberProfileLink(ViewPage page, Guid userID, string name)
        {
            return page.Html.ActionLink<ClimberProfilesController>(c => c.Detail(userID), page.Html.Encode(name), new { rel = "nofollow" });       
        }


        public static string ClimberProfileFull(ViewPage page, ClimberProfile profile)
        {
            return page.Html.RenderUserControl("~/Controls/ClimbFindProfileFull.ascx", profile);
        }


        public static string RegularsShortlist(ViewPage page, Place place, List<ClimberProfile> regulars, int maxDisplayCount)
        {
            return page.Html.RenderUserControl("~/Views/ClimberProfiles/RegularsShortlist.ascx",
                new RegularsShortlistViewData { MaxDisplayCount = maxDisplayCount, place= place, Regulars = regulars });
        }

        public static string Button<T>(Expression<Action<T>> action, string text, ViewPage page)
            where T : System.Web.Mvc.Controller
        {
            return page.Html.ActionLink<T>(action, text, new { _class = "button" });
        }

        public static string AddThisBookmark(ViewPage page, string url, string title)
        {
            return page.Html.RenderUserControl("~/Views/Shared/AddThisBookmark.ascx", null, new { BookmarkUrl = url, BookmarkTitle = title });
        }

        public static string SuperButton<T>(Expression<Action<T>> action, string text, ViewPage page) 
            where T : System.Web.Mvc.Controller
        {
            return page.Html.ActionLink<T>(action, text, new { _class = "superButton" });
        }


        public static string BreadCrumbTrail(IBreadCrumb[] trail)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"<div id=""breadcrumb"">");
            sb.Append(@"<ul>");

            IBreadCrumb firstCrum = trail[0];

            sb.AppendFormat(@"<li class=""current"">{0}</li>", firstCrum.Text);

            for (int i = 1; i < trail.Length; i++)
            {
                IBreadCrumb crumb = trail[i];

                sb.AppendFormat(@"<li><a href=""{0}"">{1}</a></li>", crumb.Link, crumb.Text);
            }

            sb.Append(@"</ul>");
            sb.Append(@"<span>You are in:</span>");
            sb.Append(@"</div>");

            return sb.ToString();
        }
    }
}
