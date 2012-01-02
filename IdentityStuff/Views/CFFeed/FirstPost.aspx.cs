using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClimbFind.Web.UI;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.Mvc.Controllers;

namespace IdentityStuff.Views.CFFeed
{
    public partial class FirstPost : ClimbFindViewPage<ISessionViewData>
    {
        protected void SavePost_Click(Object sender, EventArgs e)
        {
            if (PeterBlum.VAM.Globals.Page.IsValid)
            {
                int placeID = int.Parse(PID.Text);
                cfController.SaveFeedIntroductionPost(
                  new FeedClimbingPost
                  {
                      Message = MessageTxB.Text,
                      PlaceID = placeID,
                      UserID = UserID
                  }
                );

                RedirectTo<HomeController>(c => c.Index());
            }
        }
    }
}
