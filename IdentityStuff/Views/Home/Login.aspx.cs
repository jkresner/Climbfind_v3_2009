using System;
using System.Web.UI;
using ClimbFind.Web.Mvc.Controllers;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;

namespace ClimbFind.Web.Mvc
{
    public partial class Login : ClimbFindViewPage<LoginViewData>
    {
        /// <summary>
        /// Page_InitComplete we have this here so we don't log the page view event for this page
        /// </summary>
        protected void Page_InitComplete(object sender, EventArgs e)
        {
            PeterBlum.VAM.Globals.UsingAltHttpHandler(this.Page);
        }
        
        public string ReturnUrl
        {
            get
            {
                if (String.IsNullOrEmpty(ViewData.Model.ReturnUrl))
                {
                    return ResolveLinkTo<CFFeedController>(c => c.NewPostPlace());                  
                }
                else
                {
                    return ViewData.Model.ReturnUrl;
                }
            }
        }
        
        public string LoginReason { get { return ViewData.Model.LoginReason; } }

        protected void Page_Init(object sender, EventArgs e)
        {
            //-- If we have some querystring values, put them into a form and make a postback

            //ReturnUrlHD.Value = ReturnUrl;
            //MessaageHD.Value = ViewData.Model.LoginReason; 
       

            //-- If we have no from values or querystring values, set default from values
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (UserLoggedIn) { RedirectTo(ReturnUrl); }

                LoginOrRegisterUC.ReturnUrl = ReturnUrl;
            }
        }
    }
}
