using System.Web.Mvc;

namespace ClimbFind.Web.Mvc.Controllers
{
    [HandleError(View="Error")]
    public class BlogController : BaseController
    {
        public ActionResult Index()
        {
            SetPageMetaData("2009 Climbfind USA Canada Roadtrip", 
                "Tales of two Australian's on a mission to connect the climbing world", "Climbfind Roadtrip, Climbing Roadtrip, Canada Climbing, USA Climbing", PageRobots.IndexFollow);
            return View();
        }



        public ActionResult Industry()
        {
            SetPageMetaData("Climbfind Climbing Industry Blog",
                "Information on the climbing industry and using the internet to promote climbing", "climbing industry", PageRobots.IndexFollow);
            return View();
        }

    }
}
