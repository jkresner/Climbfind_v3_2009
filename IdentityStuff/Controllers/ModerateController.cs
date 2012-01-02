using System;
using System.Web.Mvc;
using ClimbFind.Controller;
using ClimbFind.Model.Objects;
using IdentityStuff.Controllers.ActionFilters;

namespace ClimbFind.Web.Mvc.Controllers
{
    [HandleError(View="Error")]
    [LoginFilter(LoginMessage = "Please login")] 
    public class ModerateController : BaseController
    {
        [ModeratorActionFilter]
        public ActionResult Index()
        {
            SetPageMetaData();
            
            return View();
        }

        public ActionResult UnauthorizedAccess()
        {
            SetPageMetaData();

            return View();
        }

        [ModeratorActionFilter]
        public ActionResult AddAreaTag()
        {
            SetPageMetaData();
            return View();
        }


        [ModeratorActionFilter]
        public ActionResult EditAreaTag(int id)
        {
            AreaTag tag = new CFController().GetAreaTag(id);
            if (tag == null) { throw new Exception(string.Format("No area tag id [{0}]", id)); }
            SetPageMetaData();
            return View(tag);
        }


        [ModeratorActionFilter]
        public ActionResult EditOutdoorAuthoritySites(int id)
        {
            OutdoorPlace outdoorPlace = new CFController().GetOutdoorPlace(id);
            if (outdoorPlace == null) { throw new Exception(string.Format("No outdoor place for id [{0}]", id)); }
            SetPageMetaData();
            return View(outdoorPlace);
        }

        [ModeratorActionFilter]
        public ActionResult AreaTagList()
        {
            SetPageMetaData();
            return View();
        }

        public ActionResult AddOutdoorLocation()
        {
            SetPageMetaData();
            return View();
        }

        public ActionResult AddOutdoorCrag(int id)
        {
            OutdoorPlace outdoorPlace = new CFController().GetOutdoorPlace(id);
            if (outdoorPlace == null) { throw new Exception(string.Format("No outdoor place for id [{0}]", id)); }
            SetPageMetaData();
            return View(outdoorPlace);
        }

        public ActionResult IndoorPlaceList()
        {
            SetPageMetaData();

            return View();
        }

        public ActionResult OutdoorPlaceList()
        {
            SetPageMetaData();
            return View();
        }

        [ModeratorActionFilter]
        public ActionResult OutdoorCragList()
        {
            SetPageMetaData();
            return View();
        }

        [ModeratorActionFilter]
        public ActionResult DeleteOutdoorCrag(Guid id)
        {
            new CFController().DeleteOutdoorCragCompletely(id);
            return RedirectToAction("OutdoorCragList");
        }

        //[ModeratorActionFilter]
        public ActionResult EditOutdoorLocation(int id)
        {
            OutdoorPlace outdoorPlace = new CFController().GetOutdoorPlace(id);
            if (outdoorPlace == null) { throw new Exception(string.Format("No outdoor place for id [{0}]", id)); }
            SetPageMetaData();
            return View(outdoorPlace);
        }

        public ActionResult EditPlaceMap(int id)
        {
            Place p = new CFController().GetPlace(id);
            if (p == null) { throw new Exception(string.Format("No place for id [{0}]", id)); }
            SetPageMetaData();
            return View(p);
        }

        public ActionResult SavePlaceMap(int placeID, string lat, string lon)
        {
            Place p = new CFController().GetPlace(placeID);
            decimal lattitude, longitude;
            if (decimal.TryParse(lat, out lattitude) && decimal.TryParse(lon, out longitude))
            {
                p.Latitude = lattitude;
                p.Longitude = longitude;
                controller.UpdatePlaceCoordinates(p);
            }
            return View("EmptyControl");
        }

        public ActionResult OwnerEditOutdoorLocation(int id)
        {           
            OutdoorPlace outdoorPlace = new CFController().GetOutdoorPlace(id);
            if (outdoorPlace == null) { throw new Exception(string.Format("No outdoor place for id [{0}]", id)); }

            if (UserID == outdoorPlace.CreatedByUserID)
            {
                SetPageMetaData();
                return View("EditOutdoorLocation", outdoorPlace);
            }
            else { return RedirectToAction("UnauthorizedAccess"); }
        }


        [ModeratorActionFilter]
        public ActionResult EditOutdoorCrag(Guid id)
        {
            OutdoorCrag crag = new CFController().GetCrag(id);
            if (crag == null) { throw new Exception(string.Format("No outdoor crag for id [{0}]", id)); }
            SetPageMetaData();
            return View(crag);
        }

        public ActionResult OwnerEditOutdoorCrag(Guid id)
        {
            OutdoorCrag crag = new CFController().GetCrag(id);
            if (crag == null) { throw new Exception(string.Format("No outdoor crag for id [{0}]", id)); }

            if (UserID == crag.CreatedByUserID)
            {
                SetPageMetaData();
                return View("EditOutdoorCrag", crag);
            }
            else { return RedirectToAction("UnauthorizedAccess"); }
        }


        public ActionResult AddIndoorPlace()
        {
            SetPageMetaData();
            return View();
        }

        [ModeratorActionFilter]
        public ActionResult EditIndoorPlace(int id)
        {
            IndoorPlace indoorPlace = new CFController().GetIndoorPlace(id);
            if (indoorPlace == null) { throw new Exception(string.Format("No indoor place for id [{0}]", id)); }
            SetPageMetaData();
            return View(indoorPlace);
        }

        [ModeratorActionFilter]
        public ActionResult EditIndoorPlaceLogo(int id)
        {
            IndoorPlace indoorPlace = new CFController().GetIndoorPlace(id);
            if (indoorPlace == null) { throw new Exception(string.Format("No indoor place for id [{0}]", id)); }
            SetPageMetaData();
            return View(indoorPlace);
        }

        [ModeratorActionFilter]
        public ActionResult EditPlaceMedia(int id)
        {
            Place place = new CFController().GetPlace(id);
            if (place == null) { throw new Exception(string.Format("No place for id [{0}]", id)); }
            SetPageMetaData();
            return View(place);
        }

        [ModeratorActionFilter]
        public ActionResult EditClub(int id)
        {
            Club club = new CFController().GetClub(id);
            if (club == null) { throw new Exception(string.Format("No club for id [{0}]", id)); }
            SetPageMetaData();
            return View(club);
        }

        [ModeratorActionFilter]
        public ActionResult EditClubLogo(int id)
        {
            Club club = new CFController().GetClub(id);
            if (club == null) { throw new Exception(string.Format("No club for id [{0}]", id)); }
            SetPageMetaData();
            return View(club);
        }

        [ModeratorActionFilter]
        public ActionResult EditAreaTags(int id)
        {
            Place place = new CFController().GetPlace(id);
            if (place == null) { throw new Exception(string.Format("No place for id [{0}]", id)); }
            SetPageMetaData();
            return View(place);
        }
        

    }
}
