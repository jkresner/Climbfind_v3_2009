using System;
using System.Web.Mvc;
using ClimbFind.Controller;
using IdentityStuff.Controllers.ActionFilters;

namespace ClimbFind.Web.Mvc.Controllers
{
    [HandleError(View = "Error")]
    [AdminActionFilter]
    public class AdminController : BaseController
    {
        public ActionResult GenerateUrlGonePage() { return View(); }
        public ActionResult LogList() { return View(); }
        public ActionResult GenerateSiteMap() { return View(); }
        public ActionResult GuidGenerator() { return View(); }
        public ActionResult ExceptionsList() { return View(); }
        public ActionResult PlaceList() { return View(); }
        public ActionResult ClubsList() { return View(); }
        public ActionResult UsersList() { return View(); }
        public ActionResult MessageBoardPosts() { return View(); }
        public ActionResult Feedback() { return View(); }

        public ActionResult DeleteOutdoorPlaceCompletely(int id)
        {
            controller.DeleteOutdoorPlaceCompletely(id);
            return RedirectToAction("PlaceList");
        }

        public ActionResult DeleteIndoorPlaceCompletely(int id)
        {
            controller.DeleteIndoorPlaceCompletely(id);
            return RedirectToAction("PlaceList");
        }

        public ActionResult DeleteUserCompletely(Guid id)
        {
            controller.DeleteUserCompletely(id);           
            return RedirectToAction("UsersList");
        }

        public ActionResult DeleteFeedback(int id)
        {
            controller.DeleteFeedback(id);
            return RedirectToAction("Feedback");
        }

        public ActionResult DeleteClubCompletely(int id)
        {
            controller.DeleteClub(id);
            return RedirectToAction("ClubsList");
        }

        public ActionResult GiveUserModeratorRights(Guid id)
        {
            controller.GiveUserModeratorRights(id);
            return RedirectToAction("UsersList");
        }

        public ActionResult TakeUserModeratorRights(Guid id)
        {
            controller.TakeUserModeratorRights(id);
            return RedirectToAction("UsersList");
        }

		public ActionResult DeleteCachedDiskImages()
		{
			return View();
		}      
    }
}
