using System;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using ClimbFind.Model.Objects;
using ClimbFind.Model.Objects.Interfaces;
using IdentityStuff.UI;
using System.Web.Mvc;
using ClimbFind.Controller;

namespace ClimbFind.Web.Mvc.Controllers
{
    public enum PageRobots { NoIndexNoFollow, NoIndexFollow, IndexNoFollow, IndexFollow }
    
    public abstract class BaseController : System.Web.Mvc.Controller
    {
        public CFController controller { get { return new CFController(); } }
      
        public bool AllowLazyMetaData { get { return true; } }
        
        public IPrincipal CurrentUser { get { return HttpContext.User;} }
        public bool UserAuthenticated { get { return CurrentUser.Identity.IsAuthenticated; } }
        public Guid UserID { get { return (Guid)Membership.GetUser().ProviderUserKey; } }

        private string GetRobotsDefinition(PageRobots pageRobots)
        {
            if (pageRobots == PageRobots.IndexFollow) { return "index, follow"; }
            else if (pageRobots == PageRobots.NoIndexFollow) { return "noindex, follow"; }
            else if (pageRobots == PageRobots.IndexNoFollow) { return "index, nofollow"; }
            else { return "noindex, nofollow"; }
        }

        public void SetPageMetaData()
        {
            if (!AllowLazyMetaData) { throw new Exception("AllowLazyMetaData has been set to false"); }
            
            ViewData["PageTitle"] = "Welcome to Climbfind - Find and share your passion for rock climbing";
            ViewData["PageDescription"] = "Find rock climbing partners to climb indoor and outdoor at the location where you climb, when you want to climb. Join climbing groups and co-ordinate with other climbing enthusiasts.";
            ViewData["PageKeywords"] = "Indoor rock climbing partners, climb partner, rock climbing community, bouldering friends";
            ViewData["PageRobots"] = "noindex, nofollow";
        }


        public void SetPageMetaData(string title, string description, string keywords, PageRobots pageRobots)
        {
            ViewData["PageTitle"] = title;
            ViewData["PageDescription"] = description;
            ViewData["PageKeywords"] = keywords;
            ViewData["PageRobots"] = GetRobotsDefinition(pageRobots);
        }

        public void SetPageMetaData(IClimbingPlace place)
        {
            ViewData["PageTitle"] = PageMetaInfoGenerator.GetTitle(place);
            ViewData["PageDescription"] = PageMetaInfoGenerator.GetMetaDescription(place);
            ViewData["PageKeywords"] = PageMetaInfoGenerator.GetMetaKeywords(place);
            ViewData["PageRobots"] = GetRobotsDefinition(PageRobots.IndexFollow);
        }

        public void SetPageMetaData(AreaTag area, bool forIndoor)
        {           
            ViewData["PageTitle"] = PageMetaInfoGenerator.GetTitle(area, forIndoor);
            ViewData["PageDescription"] = PageMetaInfoGenerator.GetMetaDescription(area, forIndoor);
            ViewData["PageKeywords"] = PageMetaInfoGenerator.GetMetaKeywords(area, forIndoor);
            ViewData["PageRobots"] = GetRobotsDefinition(PageRobots.IndexFollow);
        }

        public ViewResult NoMetaView()
        {
            SetPageMetaData();
            return View();
        }

        public ViewResult NoMetaView(object model)
        {
            SetPageMetaData();
            return View(model);
        }


        public ViewResult PageGoneView()
        {
            SetPageMetaData("410 Page Gone", "", "", PageRobots.NoIndexFollow);
            HttpContext.Response.Status = "410 Page Gone";
            return View("UrlGone");
        }
    }
}
