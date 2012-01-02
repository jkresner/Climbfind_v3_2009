using System;
using ClimbFind.Controller;
using ClimbFind.Model.Objects;
using ClimbFind.Model.DataAccess;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace ClimbFind.Web.UI
{
    public class ClimbFindViewUserControl : BaseViewUserControl
    {
        public CFController cf = new CFController();
        
        public bool UserIsModerator
        {
            get
            {
                if (!UserLoggedIn) { return false; }
                else
                {
                    return new CFController().GetClimberProfile(UserID).IsModerator;
                }
            }
        } 
        
        public UserSettings UsersSearchSettings { get 
            { return new CFController().GetUserSearchSettings(UserID); } }
        
        protected void Page_InitComplete(object sender, EventArgs e)
        {
        }

        public string GetPlaceLink(int placeID)
        {
            return string.Format("<img src='{0}' /><a href='{1}'>{2}</a>",
                CFDataCache.GetPlaceProp<string>(c => c.FlagImageUrl2, placeID),
                CFDataCache.GetPlaceProp<string>(c => c.ClimbfindUrl, placeID),
                CFDataCache.GetPlaceProp<string>(c => c.Name, placeID));
        }

        protected void RedirectTo<C>(Expression<Action<C>> action)
            where C : System.Web.Mvc.Controller
        {
            Response.Redirect(this.Html.BuildUrlFromExpression<C>(action), false);
        }
    }
}
