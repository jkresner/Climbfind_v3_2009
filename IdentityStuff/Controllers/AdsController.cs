using System.Web.Mvc;
using IdentityStuff.Controllers.ActionFilters;
using ClimbFind.Controller;
using ClimbFind.Model.Objects;

namespace ClimbFind.Web.Mvc.Controllers
{
    [HandleError(View = "Error")]
    public class AdsController : BaseController
    {
        public ActionResult Index()
        {
            SetPageMetaData();
            return View();      
        }

        [LoginFilter(LoginMessage="Please login to purchase advertising")]
        public ActionResult Purchase()
        {
            SetPageMetaData();
            return View();
        }

        [LoginFilter(LoginMessage = "Please login to purchase advertising")]
        public ActionResult Report(int id)
        {
            AdClient client = controller.GetAdClient(id);
            
            SetPageMetaData();
            return View(client);
        }

        public ActionResult Record(int adID, string srcUrl, string destinationUrl)
        {
            new CFController().RecordAdClick(adID, srcUrl);

            Response.Redirect("http://"+destinationUrl, false);

            return null;
        }
    }
}
