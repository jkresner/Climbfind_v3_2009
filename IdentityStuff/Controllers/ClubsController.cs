using System;
using System.Web.Mvc;
using ClimbFind.Controller;
using ClimbFind.Model.Objects;
using IdentityStuff.Controllers.ActionFilters;

namespace ClimbFind.Web.Mvc.Controllers
{
    [HandleError(View = "Error")]
    public class ClubsController : BaseController
    {
        public ActionResult Index()
        {
            string title = "Mountaineering Clubs and Rock Climbing Clubs - Climbfind.com";
            string description = "List of Mountaineering Clubs and Rock Climbing Clubs";
            string keywords = ("Rock Climbing Clubs, Mountaineering  Clubs");
            
            SetPageMetaData(title, description, keywords, PageRobots.IndexFollow);
            
            return View();      
        }

        [LoginFilter(LoginMessage = "To create a club, please login or register an account")]
        public ActionResult New()
        {
            SetPageMetaData();
               
            return View();            
        }

        public ActionResult PostACall()
        {
            if (UserAuthenticated) { return RedirectToAction("PostMeet"); }
            else
            {
                SetPageMetaData(
                    "Post a meet or trip for your rock climbing club - Climbfind.com",
                    "Info on how you can promote your climbing club using Climbfind's meet posting mechanism which is like posting an ad for the next time your club goes climbing",
                    "Climbing partners, climbing clubs, climbing trips", PageRobots.IndexNoFollow);
                return View("About");
            }
        }


        [LoginFilter(LoginMessage = "To post a club meet, please login or register an account")]
        public ActionResult PostMeet()
        {
            SetPageMetaData();

            return View();
        }

        public ActionResult Detail(string country, string friendlyUrlName)
        {
            Club club = new CFController().GetClub(friendlyUrlName);

            if (club == default(Club)) { return RedirectToAction("Index"); }
            else
            {
                string title = club.Name + " - Mountaineering and Climbing Clubs - Climbfind.com";
                string description = string.Format("About the {0} and its members", club.Name);
                string keywords = string.Format("{0}, {1} Rock Climbing Clubs, Mountaineering in {1}", club.Name, club.Country);

                SetPageMetaData(title, description, keywords, PageRobots.IndexNoFollow);
                return View(club);
            }     
        }

        [LoginFilter]
        public ActionResult Edit(Guid id)
        {
            SetPageMetaData();
            
            return View();
        }


        [LoginFilter]
        public ActionResult EditPicture(Guid id)
        {
            SetPageMetaData();
            
            return View();
        }

 

        //public ActionResult Search()
        //{
        //    SetPageMetaData();
            
        //    return View();
        //}



        [LoginFilter(LoginMessage = "To join a club, please login or register an account")]
        public ActionResult JoinClub(int clubID, Guid userID)
        {
            Club club = new CFController().GetClub(clubID);

            new CFController().JoinClub(club.ID, club.Name, userID, User.Identity.Name);

            return RedirectToAction("Detail", new { country = club.FriendlyCountryUrl, friendlyUrlName = club.FriendlyUrlName });
        }


        [LoginFilter]
        public ActionResult LeaveClub(int clubID, Guid userID)
        {
            Club club = new CFController().GetClub(clubID);

            new CFController().LeaveClub(club.Name, clubID, userID);

            return RedirectToAction("Detail", new { country = club.FriendlyCountryUrl, friendlyUrlName = club.FriendlyUrlName });
        }
    }
}
