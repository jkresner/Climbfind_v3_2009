using System.Web.Mvc;

namespace ClimbFind.Web.Mvc.Controllers
{
    [HandleError(View="Error")]
    public class SharedController : BaseController
    {
        public ActionResult PageNotFound()
        {
            SetPageMetaData("", "", "", PageRobots.NoIndexFollow);
            return View("PageNotFound");
        }
                
        public ActionResult FullSizeImage(string imageSource, string fileExtension)
        {
            string safeImageSource = imageSource + "." + fileExtension;
            return View("FullSizeImage", "", safeImageSource);
        }
    }
}
