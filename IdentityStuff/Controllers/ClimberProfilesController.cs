using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ClimbFind.Controller;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Models.ViewData;
using IdentityStuff.Controllers.ActionFilters;
using IdentityStuff.Models.ViewData;
using ClimbFind.Model.DataAccess;

namespace ClimbFind.Web.Mvc.Controllers
{
    [HandleError(View = "Error", Order=2)] 
    public class ClimberProfilesController : BaseController
    {
        public ActionResult All()
        {
            SetPageMetaData();
            return View();
        }

        public ActionResult AllWhatILike()
        {
            SetPageMetaData();
            return View();
        }
        

        [LoginFilter(LoginMessage = "To view and edit your profile, please login or register an account")]
        public ActionResult Me()
        {
            SetPageMetaData();

            return View(new ClimberProfileViewData());       
        }

        [LoginFilter(LoginMessage = "To view and edit your profile, please login or register an account")]
        public ActionResult ConfirmDeleteMe()
        {
            SetPageMetaData();
            return View( new ISessionViewData());
        }


        [LoginFilter(LoginMessage = "To view and edit your profile, please login or register an account")]
        public ActionResult Edit()
        {
            ClimberProfile climberProfile =  new CFController().GetClimberProfile(UserID);
            if (climberProfile.IsDefault) { return RedirectToAction("EditFirstTime"); }
            SetPageMetaData();

            return View(new ClimberProfileViewData());
        }

        [LoginFilter(LoginMessage = "To view and edit your profile, please login or register an account")]
        public ActionResult EditFirstTime()
        {
            SetPageMetaData();
            return View(new ClimberProfileViewData());
        }

        [LoginFilter]
        public ActionResult EditPartnerStatus()
        {
            SetPageMetaData();
            return View(new ClimberProfileViewData());
        }

        [LoginFilter]
        public ActionResult UpdatePartnerStatus()
        {
            CFController cf = new CFController();

            byte statusID = byte.Parse(Request.Form["PartnerStatus"].ToString());

            ClimberProfile profile = cf.GetClimberProfile(UserID);
            cf.SaveClimberProfilePartnerStatus(profile, (byte)statusID);
            
            return RedirectToAction("Me");
        }


        
        [LoginFilter(LoginMessage = "Please login to verify your email address")]
        public ActionResult VerifyEmailAddress(Guid id)
        {
            if (id != Guid.Empty)
            {
                CFController cf = new CFController();
                cf.VerifyUsersEmailAddress(UserID, id);
            }
            SetPageMetaData();
            return View(new ISessionViewData());
        }


        [LoginFilter]
        public ActionResult EditIndoorPlaces()
        {
            SetPageMetaData();
            return View(new ClimberProfileViewData());
        }

        [LoginFilter]
        public ActionResult EditOutdoorPlaces()
        {
            SetPageMetaData();
            return View(new ClimberProfileViewData());
        }

        [LoginFilter]
        public ActionResult EditExtendedProfile()
        {
            SetPageMetaData();

            return View(new ClimberProfileViewData());
        }

        [LoginFilter]
        public ActionResult EditPicture()
        {
            SetPageMetaData();
            return View(new ClimberProfileViewData());
        }

        [LoginFilter(LoginMessage = "To view a profile, please login or register an account")]
        [ProfileCompleteActionFilter]
        public ActionResult Detail(Guid id)
        {
            if (id == UserID) { return RedirectToAction("Me"); }
            else
            {
                ClimberProfileViewData viewData = new ClimberProfileViewData(id);
                if (viewData.Profile != null)
                {
                    SetPageMetaData();
                    return View(viewData);
                }
                else
                {
                    return PageGoneView();
                }
            }
        }

        [LoginFilter(LoginMessage = "To write a message to another user, please login or register an account")]
        public ActionResult WriteMessage(Guid id)
        {
            ClimberProfile cp = controller.GetClimberProfile(UserID);
            if (cp.EmailVerified)
            {
                ClimberProfile userToWriteMsgTo = controller.GetClimberProfile(id);
                if (userToWriteMsgTo == null) { return PageGoneView(); }
                else
                {
                    SetPageMetaData();
                    return View(new ClimberProfilesWriteMessageViewData { ClimberProfileToSendMessageID = id });
                }
            }
            else
            {
                return RedirectToAction("VerifyEmailAddress", new { id = Guid.Empty });
            }
        }

        [LoginFilter(LoginMessage = "To delete a message, please login or register an account")]
        public ActionResult SenderDeleteUserMessage(Guid id)
        {
            new CFController().SenderDeleteMessage(id);
            
            return RedirectToAction("Sent", "Home");
        }

        [LoginFilter(LoginMessage = "To delete a message, please login or register an account")]
        public ActionResult ReceiverDeleteUserMessage(Guid id)
        {
            new CFController().ReceiverDeleteMessage(id);

            return RedirectToAction("Inbox", "Home");
        } 

        public ActionResult DetailShort(Guid id)
        {
            SetPageMetaData();

            return View(new CFController().GetClimberProfile(id));
        }

        [LoginFilter(LoginMessage = "To add a place to your profile, please login or register an account")]
        public ActionResult AddPlaceToPlacesUserClimbs(int placeID)
        {
            new CFController().SavePlaceUserClimbsAt(UserID, placeID);
            
            Place place = new CFController().GetPlace(placeID);

            if (place.IsIndoor)
            {
                return RedirectToAction("DetailIndoor", "Places", new { location = place.FriendlyUrlLocation, name = place.FriendlyUrlName });
            }
            else  
            {
                return RedirectToAction("DetailOutdoor", "Places", new { location = place.FriendlyUrlLocation, name = place.FriendlyUrlName });
            }
        }


        [LoginFilter(LoginMessage = "To search through almost 2000 climber profiles, login or register an account")]
        public ActionResult Search()
        {
            SetPageMetaData();

            return View(new ISessionViewData());
        }


        public ActionResult Bloggers()
        {
            return NoMetaView();
        }

        public ActionResult Moderators()
        {
            return NoMetaView();
        }
    }
}
