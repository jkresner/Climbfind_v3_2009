using System;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;

namespace ClimbFind.Web.Mvc.Views.ClimberProfiles
{
    public partial class ConfirmDeleteMe : ClimbFindViewPage<ISessionViewData>
    {        
        protected ClimberProfile me;

        protected void Page_Init(object sender, EventArgs e)
        {           
            me = cfController.GetClimberProfile(UserID);
        }

        protected void DeleteMe_Click(object sender, EventArgs e)
        {
            cfController.DeleteMeCompletely(UserID, me.FullName, me.Email);

            Response.Redirect("~/Home/Logout", false);
        }
    }
}
