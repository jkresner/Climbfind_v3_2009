using System;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.Profile;
using VAMAjaxManager = PeterBlum.VAM.AJAXManager;
using IdentityStuff.UI;
using ClimbFind.Model.DataAccess;

namespace ClimbFind.Web.UI
{
    public abstract class BaseViewPage<T> : System.Web.Mvc.ViewPage<T> where T : class
    {
        public bool UserLoggedIn { get { return User.Identity.IsAuthenticated; } }
        public MembershipUser CFUser { get { return Membership.GetUser(); } }
        //public Guid UserID { get { return new Guid(CFUser.ProviderUserKey.ToString()); } }

        public Guid UserID { get { return CFProfile.UserID; } }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            PeterBlum.VAM.Globals.Page.ControlErrorCssClass = "inputError";
            PeterBlum.VAM.Globals.Page.CheckBoxErrorCssClass = "inputError";
            PeterBlum.VAM.Globals.Page.ListErrorCssClass = "inputError";           
        }

        protected void RedirectTo(string uri)
        {
            Response.Redirect(uri, false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="fileName"></param>
        protected void RegisterJavaScriptFile(string key, string fileName)
        {
            this.ClientScript.RegisterClientScriptInclude(key, ResolveClientUrl("~/js/" + fileName));
        }

        /// <summary>
        /// 
        /// </summary>
        protected void RegisterForPeterBlumAJAX()
        {
            Control scriptManager = this.Master.FindControl("ScriptManager");
            Control updatePanel = this.Master.FindControl("PageUP");

            VAMAjaxManager.UsingMicrosoftAJAX(scriptManager, updatePanel);
            VAMAjaxManager.Current.AllInAJAXUpdate = true;
            VAMAjaxManager.PreregisterForAJAX(VAMAjaxManager.FeatureList.Validators);
            VAMAjaxManager.PreregisterForAJAX(VAMAjaxManager.FeatureList.TextBoxes);
        }



        


        
    }
}
