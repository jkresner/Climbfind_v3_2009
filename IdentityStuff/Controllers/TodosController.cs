using System;
using System.Web.Mvc;
using ClimbFind.Controller;
using ClimbFind.Model.Objects;
using IdentityStuff.Controllers.ActionFilters;

namespace ClimbFind.Web.Mvc.Controllers
{
    [HandleError(View = "Error")]
    public partial class TodosController : BaseController
    {       
        [LoginFilter]
        public ActionResult Index()
        {
            return NoMetaView();
        }

        [LoginFilter]
        public ActionResult List()
        {
            return NoMetaView();
        }

        [LoginFilter]
        public ActionResult Done(int id)
        {
            return NoMetaView();
        }

        [LoginFilter]
        public ActionResult Hide(int id)
        {
            return NoMetaView();
        }
    }
}
