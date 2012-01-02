using System;
using System.Web.Mvc;
using ClimbFind.Controller;
using ClimbFind.Model.Objects;
using IdentityStuff.Controllers.ActionFilters;

namespace ClimbFind.Web.Mvc.Controllers
{
    [HandleError(View = "Error")]
    public partial class NewsController : BaseController
    {
        public ActionResult FeatureArticles()
        {
            SetPageMetaData("Climbfind Climbing Articles & News",
                                   "Articles & news about the UK climbing community",
                                   "Climbfind, climbing news, climbing events", PageRobots.IndexFollow);

            return View("FeatureArticles");
        }

        public ActionResult RSSAggregate()
        {
            SetPageMetaData();
            return View();
        }


        public ActionResult FeatureArticleBuilder()
        {
            SetPageMetaData();
            return View();
        }

        public ActionResult CompetitionsList()
        {
            SetPageMetaData("Climbfind Climbing Competitions & News",
                                   "Compeitions & news about the UK climbing community",
                                   "Climbfind, climbing news, climbing events", PageRobots.IndexFollow);

            return View("Competitions");
        }

        public ActionResult MainFeed()
        {
            SetPageMetaData("Climbfind news",
                                   "Climbfind news feed which includes information about what's happening with the Climbfind site and its crew.",
                                   "Climbfind, climbing news, climbing events, climbing competittions, climbing calendar", PageRobots.IndexFollow);

            return View("MainFeed");
        }

        public ActionResult Calendar()
        {
            SetPageMetaData("Climbfind Climbing Competitions & Events Calendar",
                                   "Climbing Calendar of competition and events for the UK climbing community",
                                   "Climbfind, climbing news, climbing events, climbing competittions, climbing calendar", PageRobots.IndexFollow);

            return View("Calendar");
        }
        

        //Check two comps with same url and different date
        public ActionResult Competitions(string date, string friendlyUrl)
        {
            try
            {
                if (date.Length != 10) { throw new Exception("Date paramter invalid"); }
            
                int year = int.Parse(date.Substring(0, 4));
                int month = int.Parse(date.Substring(5, 2));
                int day = int.Parse(date.Substring(8, 2));

                DateTime dateTime = new DateTime(year, month, day);
                
                Competition comp = new CFController().GetClimbingCompetition(dateTime, friendlyUrl);

                if (comp == null) { throw new Exception(string.Format("No competition found for parameters [{0}] and [{1}]", date, friendlyUrl)); }
                else
                {
                    SetPageMetaData(comp.ArticleHeading + " - Climbfind Climbing Competitions & News - Climbfind.com",
                        comp.MetaDescription + ". Compeitions & news about the UK climbing community",
                        comp.MetaKeywords + "Climbfind, climbing news, climbing events, uk climbing competitions, bouldering competition", PageRobots.IndexFollow);

                    return View("2008-CompetitionTemplate", comp);
                }
            }
            catch
            {
                 return RedirectToAction("Index");
            }
        }
        

        //Check two comps with same url and different date
        //[OutputCache(Duration = 3600, VaryByParam = "friendlyUrl")]
        public ActionResult FeatureArticle(string date, string friendlyUrl)
        {
            try
            {
                if (date.Length != 10) { throw new Exception("Date paramter invalid"); }

                int year = int.Parse(date.Substring(0, 4));
                int month = int.Parse(date.Substring(5, 2));
                int day = int.Parse(date.Substring(8, 2));

                DateTime dateTime = new DateTime(year, month, day);

                FeatureArticle article = new CFController().GetFeatureArticle(dateTime, friendlyUrl);

                if (article == null) { throw new Exception(string.Format("No feature article found for parameters [{0}] and [{1}]", date, friendlyUrl)); }
                else
                {
                    SetPageMetaData(article.ArticleHeading + " - Climbfind Feature Articles & News - Climbfind.com",
                        article.MetaDescription + ". News about the UK climbing community",
                        article.MetaKeywords + "Climbfind, climbing news, climbing events, uk climbing, uk bouldering", PageRobots.IndexFollow);

                    return View("2008-FeatureArticle", article);
                }
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Index()
        {
            SetPageMetaData("Climbfind Climbing News",
                "News about the UK climbing community and Climbfind's movements",
                "Climbfind, climbing news, climbing events", PageRobots.IndexFollow);

            return View();
        }


        [OutputCache(Duration = 3600)]
        public ActionResult Climbfind_Roadtrip_2008_11()
        {
            SetPageMetaData("Climbfind 2008 UK Road Trip - Climbfind Climbing News - Climbfind.com", "", "", PageRobots.IndexFollow);

            return View("2008-11-Climbfind-Roadtrip");
        }
    }
}
