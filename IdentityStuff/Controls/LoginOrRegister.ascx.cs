using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClimbFind.Controller;

namespace ClimbFind.Web.Mvc.Controls
{
    public partial class LoginOrRegister : System.Web.Mvc.ViewUserControl
    {
        public string LoginEmail { get; set; }

        public string ReturnUrl 
        {
            get { return LoginUC.DestinationPageUrl; }
            set { LoginUC.DestinationPageUrl = value; } 
        }
        
        protected void Page_Init(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ReturnUrl))
            {
                LoginUC.DestinationPageUrl = this.Page.Request.Url.ToString();    
            }

            if (!String.IsNullOrEmpty(LoginEmail)) { LoginUC.UserName = LoginEmail; }
        }

        protected void Page_Load(object sender, EventArgs e) {}

        protected void LogLogin(object sender, EventArgs e)
        {           
            MembershipUser CFUser = Membership.GetUser(LoginUC.UserName); 
            Guid userID = new Guid(CFUser.ProviderUserKey.ToString());

            CheckBox RemmemberMeCB = LoginUC.FindControl("RemmemberMe") as CheckBox;
            if (RemmemberMeCB.Checked) { FormsAuthentication.SetAuthCookie(LoginUC.UserName, true); }

            CFLogger.RecordSignIn(userID, CFUser.Email);
        }
        

    }
}
