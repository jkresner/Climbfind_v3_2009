using System.Web.Mvc;

namespace ClimbFind.Web.Mvc.Views.Home
{
    public partial class ThankYou : ViewPage
    {
        public string ReturnUrl 
        {
            get
            {
                if (Page.Request.UrlReferrer != null)
                {
                    return Page.Request.UrlReferrer.ToString();
                }
                else
                {
                    return "/";
                }
            }
        }
        
    }
}
