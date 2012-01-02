using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using ClimbFind.Web.Mvc.Models.ViewData;
using IdentityStuff.Controllers.ActionFilters;
using ClimbFind.Controller;
using IdentityStuff.Controllers.ActionResults;
using System.ServiceModel.Syndication;
using ClimbFind.Model.Objects;
using ClimbFind.Model.Enum;
using ClimbFind.Model.Objects.Interfaces;
using System.Collections.Generic;
using ClimbFind.Model.DataAccess;
using ClimbFind.Content;

namespace ClimbFind.Web.Mvc.Controllers
{
    [HandleError(View="Error")]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {            
            if (!User.Identity.IsAuthenticated)
            {
                SetPageMetaData("Find climbing partners - Climbfind.com",
                    "The ultimate rock climbing partner resource and climbers social network",
                    "find climbing partner, indoor rock climbing gyms, rock climbing partners, outdoor climbing locations, climbing travel", PageRobots.IndexFollow);
                return View();
            }
            else
            {
                SetPageMetaData();
                return View("IndexAuthenticated");
            }
        }



        public ActionResult PGIndex()
        {
            SetPageMetaData();
            return View("PGIndex");
        }

        public ActionResult Search(string searchstr)
        {
            SetPageMetaData();
            return View((object)searchstr);
        }

        public ActionResult AboutPartnerWidget()
        {
            SetPageMetaData("Climbfind partner widget for climbing gyms - Climbfind.com", 
                "Climbing partner functionality to embed directly into your website", 
                "find rock climbing partners, indoor climbing partner", PageRobots.IndexNoFollow);
            return View(new ISessionViewData());
        }


        public ActionResult AboutProfileExample()
        {
            SetPageMetaData("Climbfind profile example", "", "", PageRobots.NoIndexFollow);
            return View(new ClimberProfileViewData(new Guid("A9646CC3-18CB-4A62-8402-5263BA8B3476")));
        }


        [LoginFilter(LoginMessage = "To view your inbox, please login or register an account")]
        public ActionResult Inbox() { return NoMetaView(); }

        [LoginFilter(LoginMessage = "To view your inbox, please login or register an account")]
        public ActionResult Sent() { return NoMetaView(); }

        public ActionResult Feedback()
        {
            SetPageMetaData("Climbfind feedback", "", "", PageRobots.NoIndexFollow);

            return View();
        }

        public ActionResult Logout()
        {     
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }


        public ActionResult Login(string message, string returnUrl)
        {
            SetPageMetaData("Climbfind.com login", "Climbfind Login Page", "Login", PageRobots.NoIndexNoFollow);           
            if (String.IsNullOrEmpty(message))
            {
                return View( new LoginViewData());
            }
            else
            {
                return View(new LoginViewData
                {
                    LoginReason = message,
                    ReturnUrl = returnUrl
                });
            }
        }

        public ActionResult ForgottenPassword()
        {
            if (UserAuthenticated) { return RedirectToAction("Index"); }
            else
            {
                SetPageMetaData();
                return View();
            }
        }

        [LoginFilter]
        public ActionResult ChangePassword() { return NoMetaView(); }

        public ActionResult ThrowExceptionTwo() { return NoMetaView(); }
        
        public ActionResult Friends() { return NoMetaView(); }
        public ActionResult About() { return NoMetaView(); }
        public ActionResult Help() { return NoMetaView(); }
        public ActionResult Contribute() { return NoMetaView(); }
        public ActionResult Promote() { return NoMetaView(); }
        public ActionResult Find() { return NoMetaView(); }
        public ActionResult Join() { return NoMetaView(); }
        public ActionResult ForIndoorClimbingBusinesses() { return NoMetaView(); }
        public ActionResult CFMail() { return NoMetaView(); }
        public ActionResult CF4() { return NoMetaView(); }
        
        [LoginFilter]
        public ActionResult ThankYou() { return NoMetaView(); }

        [LoginFilter(LoginMessage = "You must log in to customize your own homepage")]
        public ActionResult HomepageSettings() { return NoMetaView(); }


        public ActionResult Glossary()
        {
            SetPageMetaData("Rock climbing glossary - Climbfind.com",
                "A glossary / dictionary of rock climbing terms, jargon & slang used by the rock climbing community to describe moves, rock formations, equipment and climbing techniques.",
                "Climbing jargon, rock climbing glossary, climbing terms",
                PageRobots.IndexFollow);

            return View();
        }

        public ActionResult GradeConverter()
        {
            SetPageMetaData("Rock climbing grade comparison chart - Climbfind.com",
                "Chart to compare and convert climbing grades including French, UIAA, USA, Australian, Heuco and Fontainebleau, there is also a short description on each grading system.",
                "Climbing jargon, rock climbing grades, covert rock climb grades, climbing grade char",
                PageRobots.IndexFollow);

            return View();
        }

        public ActionResult ClimbingFeedRss()
        {
            List<SyndicationItem> newItems = new List<SyndicationItem>();

            List<FeedClimbingPost> ClimbingPosts = controller.GetPostsBySettings(
                new FeedSettings { CurrentChannelType = (byte)FeedChannel.All }, FeedView.Posted, 6);

            foreach (FeedPartnerCallPost p in controller.GetLatestPartnerCalls(3)) { newItems.Add(p.GetSyndicationItem()); }
            foreach (FeedClimbingPost p in ClimbingPosts) { newItems.Add(p.GetSyndicationItem()); }

            newItems = (from c in newItems orderby c.LastUpdatedTime descending select c).ToList();
            DateTimeOffset lastUpdated = (from c in newItems orderby c.LastUpdatedTime descending select c.LastUpdatedTime).First();

            SyndicationFeed feed =
                new SyndicationFeed("Climbfind Climbing Feed",
                                    "Climbing users looking for partners and climbing buddies",
                                    null,
                                    "ClimbfindClimbingFeed0.9",
                                    lastUpdated,
                                    newItems);

            return new RssActionResult() { Feed = feed };
        }

        




        public ActionResult GoToError(HandleErrorInfo info)
        {
            SetPageMetaData();
            return View("Error", info);
        }

        public ActionResult WebFormError() { return NoMetaView(); }

        public ActionResult ThrowException()
        {
            throw new Exception("Testing exception");
        }

        public ActionResult UrlMoved(string NewUrl) 
        {
        
            SetPageMetaData("301 Moved", "", "", PageRobots.NoIndexNoFollow);
            return View("301-Permanently-Moved", null, NewUrl);
        }

        public ActionResult UrlGone()
        {
            SetPageMetaData("410 Gone", "", "", PageRobots.NoIndexNoFollow);
            return View("UrlGone");
        }



    }

    public static class FeedItemExtensions
    {
        public static SyndicationItem GetSyndicationItem(this FeedPartnerCallPost p)
        {
            return new SyndicationItem(
                string.Format("{0} wants partners @ {1}", p.User.FullName, p.Call.PlacesNamesString, p.Call.FirstPlaceFullQualifiedUrl),
                string.Format("{0}", p.Call.Message),
                new Uri(p.Call.FirstPlaceFullQualifiedUrl),
                string.Format("PartnerCall[{0}]", p.Call.ID),
                p.PostedDateTime) { PublishDate = p.PostedDateTime };
        }

        public static SyndicationItem GetSyndicationItem(this FeedClimbingPost p)
        {
            Place place = CFDataCache.GetPlace(p.PlaceID);
            string placeLink = string.Format("{0}{1}", CFSettings.WebAddress, place.ClimbfindUrl);
            
            return new SyndicationItem(
                string.Format("{0} wants to climb {1} @ {2}, {3}", p.User.FullName, p.ClimbingDateTime.ToString("dd MMM"),
                    place.ShortName, FlagList.GetCountryName((Nation)place.CountryID), placeLink),
                string.Format("{0}", p.Message),
                new Uri(placeLink),
                string.Format("ClimbingPost[{0}]", p.ID),
                p.PostedDateTime) { PublishDate = p.PostedDateTime };
        }
    }
}
