using System;
using System.Web.Mvc;
using ClimbFind.Controller;
using ClimbFind.Web.Mvc.Models.ViewData;
using IdentityStuff.Controllers.ActionFilters;
using ClimbFind.Model.Objects;
using System.Collections.Generic;

namespace ClimbFind.Web.Mvc.Controllers
{
    [HandleError(View = "Error")]
    public class PartnerCallsController : BaseController
    {       
        public ActionResult ByPlace()
        {
            SetPageMetaData("Search for a rock climbing partner by where you want to climb - Climbfind.com",
                "Find climbing partners at your rock climbing gym, climbing centre or nearest outdoor climbing location",
                "Rock climbing partner, climbing partners, outdoor climbing friends", PageRobots.IndexFollow);

            return View();
        }


        public ActionResult PartnerAreaWidget(string countryUrl, string areaNameUrl)
        {
            AreaTag area = new CFController().GetAreaTagByCountryUrlAndName(countryUrl, areaNameUrl);
            if (area == null) { return RedirectToAction("Index"); }
            else
            {
                SetPageMetaData("Partner Area Widget: " + area.Name, "", "", PageRobots.NoIndexNoFollow);
                return View(area);
            }             
        }


        public ActionResult CustomVWPartnerWidget(string Site)
        {
            List<int> vws = new List<int>() { 316, 317, 318, 319 };
            List<PartnerCall> vwPartnerCalls = new CFController().GetPartnerCallsForPlaceCombo(vws, 7);
            return View("PartnerCustomWidget", vwPartnerCalls);
        }

        public ActionResult CustomHangarPartnerWidget(string Site)
        {
            List<int> hanger18s = new List<int>() { 410, 420, 1218 };
            List<PartnerCall> hangarPartnerCalls = new CFController().GetPartnerCallsForPlaceCombo(hanger18s, 7);
            return View("PartnerCustomWidget", hangarPartnerCalls);
        }

        [LoginFilter(LoginMessage = "To post a call for partners, please login or register an account")]
        public ActionResult New()
        {
            //SetPageMetaData();
            
            //return View();
            return Content("You can no longer post partner calls on this site, please use www.climbfind.com");
        }

        public ActionResult Index()
        {
            return RedirectToAction("PostACall");
        }

        public ActionResult PostACall()
        {
            if (UserAuthenticated) { return RedirectToAction("New"); }
            else 
            {
                SetPageMetaData(
                    "Post an ad for rock climbing patners - Climbfind.com",
                    "Info on how you can find a climbing partner using Climbfind's partner call mechanism which is like posting an ad for climbing partners",
                    "Climbing partners, indoor climbing partner, outdoor climbing friend, climb gym partner", PageRobots.IndexNoFollow);
                return View("About"); 
            }
        }


        [LoginFilter(LoginMessage = "To post a call for partners, please login or register an account")]
        public ActionResult Edit(Guid id)
        {
            //PartnerCallEditViewData viewData = new PartnerCallEditViewData(id);
            
            ////-- Check that the call belongs to the user who is trying to edit it
            //if (viewData.Current.ClimberProfileID != UserID) { throw new Exception("User trying to edit call that does not belong to them."); } 
            SetPageMetaData();
            return View("UrlGone");
        }

        [LoginFilter]
        public ActionResult ConfirmDelete(Guid id)
        {
            PartnerCall call = new CFController().GetPartnerCall(id);

            if (call.ClimberProfileID != UserID) { throw new Exception(string.Format("You cannot delete someone else's call callID[{0}]", id)); }
            
            SetPageMetaData();

            return View(call);
        }


        
        [LoginFilter(LoginMessage = "To reply to a partner call, please login or register an account")]
        public ActionResult Reply(Guid id)
        {
            PartnerCallReplyViewData viewData = new PartnerCallReplyViewData(id);

            if (viewData.Current == null) { return PageGoneView(); }
            else
            {
                if (viewData.PartnerCallPoster.ID == UserID) { return RedirectToAction("Me", "ClimberProfiles"); }
                else
                {
                    SetPageMetaData();
                    return View(viewData);
                }
            }
        }

        [LoginFilter]
        public ActionResult ShowReply(Guid id)
        {
            SetPageMetaData();

            return View(new PartnerCallShowReplyViewData(id));
        }


        public ActionResult List()
        {
            SetPageMetaData(
                "Climbing partners - Climbfind.com", 
                "People looking for indoor rock climbing partners and outdoor climb buddies", 
                "Climb partner, indoor climbing partners, outdoor rock climbers, bouldering partners", PageRobots.IndexFollow);

            return View(new ISessionViewData());
        }


        public ActionResult Subscribe(string location, string name)
        {
            Place place = new CFController().GetPlace(location, name);

            if (place == null) { return RedirectToAction("Index"); }
            else
            {
                SetPageMetaData();
                return View(place);
            }
        }

        [LoginFilter(LoginMessage = "You must log in to set your partner call subscriptions")]
        public ActionResult Notifications() { return NoMetaView(); }

    }
}
