using System;
using System.Web.Mvc;
using ClimbFind.Controller;
using ClimbFind.Model.Objects;
using IdentityStuff.Controllers.ActionFilters;

namespace ClimbFind.Web.Mvc.Controllers
{
    [HandleError(View = "Error")]
    public class MediaController : BaseController
    {
        public ActionResult Index()
        {
            SetPageMetaData();           
            return View();      
        }


        public ActionResult Delete(Guid id)
        {
            MediaShare media = new CFController().GetMedia(id);

            if (media.SubmittedByUserID != UserID) { throw new Exception("You cannot delete media that does not belong to you media ID = " + id.ToString()); }

            new CFController().DeleteMedia(id);

            return RedirectToAction("UsersMedia", new { id = media.SubmittedByUserID });
        }

        public ActionResult Detail(Guid id)
        {           
            MediaShare media = new CFController().GetMedia(id);
            if (media == null) { return PageGoneView(); }
            else
            {
                string title = string.Format("{0} - Climbing {1} - Climbfind.com", media.Name, media.MediaTypeString);
                string keywords = string.Format("Climbing {1}, {0}", media.Name, media.MediaTypeString);

                SetPageMetaData(title, media.Description, keywords, PageRobots.IndexNoFollow);
                return View(media);
            }
        }

        [LoginFilter(LoginMessage = "Please login to add you tube movies")]
        public ActionResult SubmitMovie()
        {
            SetPageMetaData();
            return View();

        }

        [LoginFilter(LoginMessage = "Please login to add you tube movies")]
        public ActionResult AddPlaceYouTube(int id)
        {
            Place place = new CFController().GetPlace(id);
            if (place == null) { throw new Exception(string.Format("No place for id [{0}]", id)); }
            SetPageMetaData();

            return View(place);
        }
        
        [LoginFilter(LoginMessage = "Please login to add you tube movies")]
        public ActionResult AddCragYouTube(Guid id)
        {
            OutdoorCrag crag = new CFController().GetCrag(id);
            if (crag == null) { throw new Exception(string.Format("No crag for id [{0}]", id)); }
            SetPageMetaData();

            return View(crag);
        }
        

        [LoginFilter(LoginMessage = "Please login to edit pictures")]
        public ActionResult EditOutdoorLocationPictures(int id)
        {
            OutdoorPlace outdoorPlace = new CFController().GetOutdoorPlace(id);
            if (outdoorPlace == null) { throw new Exception(string.Format("No outdoor place for id [{0}]", id)); }
            SetPageMetaData();
            return View(outdoorPlace);
        }

        [LoginFilter(LoginMessage = "Please login to edit pictures")]
        public ActionResult EditOutdoorCragPictures(Guid id)
        {
            OutdoorCrag crag = new CFController().GetCrag(id);
            if (crag == null) { throw new Exception(string.Format("No crag for id [{0}]", id)); }
            SetPageMetaData();
            return View(crag);
        }



        [LoginFilter(LoginMessage = "Please login to see your movies")]
        public ActionResult MyMovies()
        {
            return RedirectToAction("UsersMedia", new { id = UserID });
        }

        public ActionResult UsersMedia(Guid id)
        {
            ClimberProfile user = new CFController().GetClimberProfile(id);
            if (user == null) { return RedirectToAction("Index"); }
            else
            {
                string title = "Climbing media submitted by " + user.FullName + " - Climbfind.com";
                string description = "Climbing related movies, photos and other webmedia submitted by " + user.FullName + " on www.climbfind.com";
                string keywords = "Climbing movies, climbing photos, climbing media";
                SetPageMetaData(title, description, keywords, PageRobots.NoIndexNoFollow);
                return View(user);
            }
        }
    }
}
