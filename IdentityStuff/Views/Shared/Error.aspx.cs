using System;
using System.Web.Mvc;
using ClimbFind.Controller;
using ClimbFind.Web.UI;
using ClimbFind.Exceptions;

namespace IdentityStuff.Views.Shared
{
    public partial class Error : ClimbFindViewPage<HandleErrorInfo> 
    {
        public Exception exception { get { return getBaseException(ViewData.Model.Exception);} }

        protected new void Page_PreInit(object sender, EventArgs e)
        {
            ViewData["PageTitle"] = "Error";
            ViewData["PageRobots"] = "noindex, follow";

            string relativeUrl = "/" + Page.Request.Url.ToString().Replace(CFSettings.WebAddress, "");
            if (!IsPostBack)
            {
                if (exception.ShouldRecord(relativeUrl))
                {
                    CFLogger.RecordException(exception);
                }
            }
            else
            {
                //-- This is important to log too because for some reason it means it is a web forms error.
                if (exception.ShouldRecord(relativeUrl))
                {
                    CFLogger.RecordException(exception);
                }
            }

            base.Page_PreInit(sender, e);
        }
    

	    //--------------------------------------------------------------------------------//

	    private static Exception getBaseException(Exception appException)
	    {
		    Exception baseException = appException;

		    //-- Navigate down to find the first PPBusinessLogicException
		    while (baseException.InnerException != null)
		    {
			    baseException = baseException.InnerException;
		    }

		    return (baseException);
	    }    
    
    }


}




	//--------------------------------------------------------------------------------//
	
    //public static void HandleException(Exception appException, bool clear)
    //{
    //    Exception baseException = getBaseException(appException);

    //    if (!handleIfSpecialException(baseException))
    //    {
    //        string browser = getFullBrowserName();
    //        string url = HttpContext.Current.Request.Url.ToString();
    //        string user = getUser();
    //        string fullMSG = appException.ToString();

    //        string source = baseException.Source;
    //        string innerMSG = baseException.Message;
    //        string exceptionType = baseException.GetType().ToString();

    //        string queryString = "";

    //        /* Live error Behavior */
    //        if (PPApp.AppMode != ApplicationMode.Development)
    //        {
    //            new PPEvent_Exception(source, appException);

    //            queryString = getPartErrorRedirectQueryString(user, url, exceptionType, innerMSG);
    //        }
    //        else
    //        {
    //            new PPEvent_Exception(source, appException);

    //            queryString = getFullErrorRedirectQueryString(browser, source, user,
    //                 exceptionType, innerMSG, url, fullMSG, "DEV Base Page");
    //        }

    //        if (clear) { HttpContext.Current.Server.ClearError(); }
			
    //        redirectToErrorPage(queryString);
    //    }
    //}

	
