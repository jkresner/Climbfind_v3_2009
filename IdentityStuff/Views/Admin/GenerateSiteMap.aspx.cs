using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects;
using System.Text;
using System.Web;
using System.Xml;
using System.IO;
using ClimbFind.Controller;


namespace IdentityStuff.Views.Admin
{
    public partial class GenerateSiteMap : ViewPage
    {
        private int pagesCount = 0;
        CFController cf = new CFController();

        protected void Page_Init(Object o, EventArgs e)
        {
        }

        protected void Page_Load(Object o, EventArgs e)
        {
            //XmlTextWriter xWriter = new XmlTextWriter(Server.MapPath("~/"), Encoding.UTF8);
            
            StringBuilder sb = new StringBuilder(@"<?xml version=""1.0"" encoding=""utf-8"" ?>
<urlset xmlns=""http://www.sitemaps.org/schemas/sitemap/0.9"">");

            WriteUrlNode(sb, "/", DateTime.Now, "daily", "1.0");
            
            //-- Intended for google site links:
            WriteUrlNode(sb, "/climbing-partners", DateTime.Now, "daily", "1.0");
            WriteUrlNode(sb, "/search-for-rock-climbing-partners", DateTime.Now, "daily", "1.0");
            WriteUrlNode(sb, "/Places", DateTime.Now, "weekly", "1.0");
            WriteUrlNode(sb, "/world-climbing-map", DateTime.Now, "weekly", "1.0");
            WriteUrlNode(sb, "/2009-Climbfind-USA-Canada-Road-Trip", DateTime.Now, "daily", "1.0");
            WriteUrlNode(sb, "/Clubs", DateTime.Now, "weekly", "1.0");
            
            WriteUrlNode(sb, "/News", DateTime.Now, "daily", "0.9");
            //WriteUrlNode(sb, "/Calendar", DateTime.Now, "monthly", "0.5");
            WriteUrlNode(sb, "/Glossary", DateTime.Now, "monthly", "0.8");
            WriteUrlNode(sb, "/Glossary/GradeConverter", DateTime.Now, "monthly", "0.6");
            WriteUrlNode(sb, "/2008-UK-Roadtrip", new DateTime(2008, 11, 10), "yearly", "0.5");


            WriteUrlNode(sb, "/Places/Outdoor", DateTime.Now, "daily", "1.0");
            foreach (Place place in cf.GetAllPlaces())
            {
                WriteUrlNode(sb, place.ClimbfindUrl, DateTime.Now.AddDays(-2), "weekly", "0.7");
            }

            foreach (AreaTag tag in cf.GetAllAreaTags())
            {
                WriteUrlNode(sb, tag.ClimbfindUrl, DateTime.Now.AddDays(-2), "weekly", "0.5");
            }

            foreach (Club club in cf.GetAllClubs())
            {
                WriteUrlNode(sb, club.ClimbfindUrl, DateTime.Now.AddDays(-10), "monthly", "0.6");
            }

            WriteUrlNode(sb, "/News/FeatureArticles", DateTime.Now, "weekly", "0.8");
            foreach (FeatureArticle article in cf.GetAllFeatureArticle())
            {
                WriteUrlNode(sb, article.ClimbfindUrl, article.Date, "monthly", "0.7");
            }

            WriteUrlNode(sb, "/Competitions", DateTime.Now, "weekly", "0.8");
            foreach (Competition comp in cf.GetAllClimbingCompetitions())
            {
                WriteUrlNode(sb, comp.ClimbfindUrl, comp.Date, "monthly", "0.7");
            }


            List<PartnerCall> AllPartnerCalls = new CFController().GetAllPartnerCalls();
            //List<PartnerCall> UniqueUserPartnerCalls = (from c in AllPartnerCalls orderby c.MeetUpDateTime descending select c).Distinct(new PartnerCallUserComparer()).ToList();
            List<int> PlaceIDsWithCalls = new CFController().GetPlaceIDsWithCalls();
            List<Place> IndoorWithCalls = (from c in CFDataCache.AllPlaces where PlaceIDsWithCalls.Contains(c.ID) && c.IsIndoor orderby c.CountryID, c.Name select c).ToList();
            List<Place> OutdoorWithCalls = (from c in CFDataCache.AllPlaces where PlaceIDsWithCalls.Contains(c.ID) && !c.IsIndoor orderby c.CountryID, c.Name select c).ToList();

            foreach (Place p in IndoorWithCalls) { 
                WriteUrlNode(sb, 
                    string.Format("/people-looking-for-climbing-partners/{0}/{1}",p.FriendlyUrlLocation, p.FriendlyUrlName), DateTime.Now, "weekly", "0.7");
            }

            foreach (Place p in OutdoorWithCalls)
            {
                WriteUrlNode(sb,
                    string.Format("/people-looking-for-climbing-partners/{0}/{1}", p.FriendlyUrlLocation, p.FriendlyUrlName), DateTime.Now, "weekly", "0.7");
            } 

            sb.Append("</urlset>");

            SiteMapLb.Text = string.Format("<p>Total pages count: {0}</p>", pagesCount) + HttpUtility.HtmlEncode(sb.ToString());

            StreamWriter tw = new StreamWriter(Server.MapPath("~/"+"SiteMap2.xml"));
            tw.WriteLine(sb.ToString());
            tw.Close();
        }


        private void WriteUrlNode(StringBuilder sb, string location, DateTime lastModDate, string changeFrequency, string priorty)
        {
            if (!location.Contains("&"))
            {
                sb.AppendLine("<url>");
                sb.AppendFormat("<loc>http://www.climbfind.com{0}", location);
                sb.AppendLine("</loc>");
                sb.AppendFormat("<lastmod>{0}", lastModDate.ToString("yyyy-MM-dd"));
                sb.AppendLine("</lastmod>");
                sb.AppendFormat("<changefreq>{0}", changeFrequency);
                sb.AppendLine("</changefreq>");
                sb.AppendFormat("<priority>{0}", priorty);
                sb.AppendLine("</priority>");
                sb.AppendLine("</url>");
                pagesCount++;
            }
        }
    
    }

}

