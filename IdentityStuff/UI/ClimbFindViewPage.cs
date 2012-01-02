using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using ClimbFind.Controller;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Controllers;
using IdentityStuff.UI.Controls;
using ClimbFind.Model.DataAccess;

namespace ClimbFind.Web.UI
{
    public abstract class ClimbFindViewPage<T> : BaseViewPage<T> where T : class
    {
        protected CFController cfController = new CFController();
        
        protected ClimberProfile CurrentClimber { get { return CFDataCache.GetClimberFromCache(UserID); } }

        public bool UserIsModerator 
        {
            get
            {
                if (!UserLoggedIn) { return false; }
                else
                {
                    return cfController.GetClimberProfile(UserID).IsModerator;
                }
            }
        }
    
    
        public UserSettings UsersSearchSettings { get 
            { return new CFController().GetUserSearchSettings(UserID); } }
        
        protected void Page_InitComplete(object sender, EventArgs e)
        {
            PeterBlum.VAM.Globals.UsingAltHttpHandler(this.Page);

            if (!Page.IsPostBack && UserLoggedIn)
            {
                string pageName = this.Page.GetType().ToString().Replace("ASP.views_", "").Replace("_aspx", "");
                CFLogger.RecordPageView(UserID, pageName);
            }
        }

        protected void RedirectToThankYouPage(string message, string returnUrl)
        {
            //-- TODO

            //-- Add message

            //-- Add Return Url Path
            Response.Redirect("~/Thankyou", false);
        }
 

        protected void RedirectTo<C>(Expression<Action<C>> action) 
            where C : System.Web.Mvc.Controller
        {
            Response.Redirect( this.Html.BuildUrlFromExpression<C>(action) , false);            
        }

        protected string ResolveLinkTo<C>(Expression<Action<C>> action)
            where C : System.Web.Mvc.Controller
        {
            return this.Html.BuildUrlFromExpression<C>(action);
        }

        public BreadCrumb<C> Crumb<C>(string text, Expression<Action<C>> linkAction) where C : BaseController
        {
            return new BreadCrumb<C>(this.ViewContext, text, linkAction);
        }

        public string GetPlaceLink(int placeID)
        {
            return string.Format("<a href='{0}'>{1}</a>",
                CFDataCache.GetPlaceProp<string>(c => c.ClimbfindUrl, placeID),
                CFDataCache.GetPlaceProp<string>(c => c.Name, placeID));
        }
    }
}
