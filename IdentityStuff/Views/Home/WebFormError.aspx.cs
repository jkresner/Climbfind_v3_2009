using System;
using System.Web.Mvc;
using ClimbFind.Controller;
using ClimbFind.Web.UI;

namespace IdentityStuff.Views.Home
{
    public partial class WebFormError : ClimbFindViewPage<HandleErrorInfo> 
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            ViewData["PageTitle"] = "Error";

            Guid currentUserID = Guid.Empty;
            if (UserLoggedIn) { currentUserID = UserID; }

            if (!Page.IsPostBack)
            {
                string pageName = this.Page.GetType().ToString().Replace("ASP.views_", "").Replace("_aspx", "");
                CFLogger.RecordPageView(currentUserID, pageName);
            }
        }    
    }
}

