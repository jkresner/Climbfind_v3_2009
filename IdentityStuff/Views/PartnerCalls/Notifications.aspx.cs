using System;
using System.Linq;
using System.Web.UI;
using ClimbFind.Web.Mvc.Controllers;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;
using System.Collections.Generic;
using ClimbFind.Model.Enum;
using ClimbFind.Model.Objects;
using ClimbFind.Model.DataAccess;


namespace ClimbFind.Web.Mvc
{
    public partial class Notifications : ClimbFindViewPage<LoginViewData>
    {
        public List<PartnerCallSubscription> PartnerCallSubscriptions { get; set; }
        public List<PartnerCallSubscription> ActivePartnerCallSubscriptions { get; set; }

        
        protected void Page_Init(object sender, EventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            PartnerCallSubscriptions = cfController.GetUsersPartnerCallSubscriptions(UserID);
            ActivePartnerCallSubscriptions = (from c in PartnerCallSubscriptions where c.Email | c.RSS select c).ToList();
        }

    }
}
