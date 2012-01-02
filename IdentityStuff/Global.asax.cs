using System;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ClimbFind.Controller;
using ClimbFind.Model.DataAccess;
using ClimbFind.Exceptions;
using ClimbFind.Web.Mvc.Controllers;
using System.IO;
using System.Text;

namespace IdentityStuff
{
    public class GlobalApplication : System.Web.HttpApplication
    {
        private static void RegisterHomeRoute(RouteCollection routes, string action)
        {
            routes.MapRoute(
                action,                                  
                action,                           
                new { controller = "Home", action = action } 
            );
        }
        
        public static void RegisterRoutes(RouteCollection routes)
        {            
            routes.IgnoreRoute("ToolTip/{resource}.html");

            routes.IgnoreRoute("Blogfiles/{resource}.html");
            routes.IgnoreRoute("Blogfiles/{resource}.xml");
     
            routes.IgnoreRoute("{resource}.html");
            routes.IgnoreRoute("{resource}.ico");
            routes.IgnoreRoute("{resource}.xml");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Login",                                  // Route name
                "Login/{message}/{returnController}/{returnAction}",          
                new { controller = "Home", action = "Login", message = "", 
                    returnController = "",
                    returnAction = "" }  // Parameter defaults
            );

            routes.MapRoute(
                "PartnerSearch",                                  // Route name
                "search-for-rock-climbing-partners",                           // URL with parameters
                new { controller = "PartnerCalls", action = "ByPlace" }  // Parameter defaults
            );

            routes.MapRoute(
                "LatestPartnerCalls",                                  // Route name
                "climbing-partners",                           // URL with parameters
                new { controller = "PartnerCalls", action = "List" }  // Parameter defaults
            );

            routes.MapRoute(
                "PartnerCallsNew",                                  // Route name
                "post-an-ad-for-rock-climbing-partners",                           // URL with parameters
                new { controller = "PartnerCalls", action = "PostACall" }  // Parameter defaults
            );


            routes.MapRoute(
                "AcceptWatchRequest",                                  // Route name
                "join-climbers-channel/{id}",                           // URL with parameters
                new { controller = "CFFeed", action = "AcceptWatchRequest", id = "id" }  // Parameter defaults
            );


            routes.MapRoute(
                "ClimberProfile",                                  // Route name
                "climber-profile/{id}",                           // URL with parameters
                new { controller = "ClimberProfiles", action = "Detail", id = "{id}" }  // Parameter defaults
            );

            routes.MapRoute(
                "write-message",                                  // Route name
                "write-message/{id}",                           // URL with parameters
                new { controller = "ClimberProfiles", action = "WriteMessage", id = "{is}" }  // Parameter defaults
            );

            routes.MapRoute(
                "DeclineGroupClimbingSession",                                  // Route name
                "DeclineGroupClimbingSession/{id}",                           // URL with parameters
                new { controller = "Groups", action = "RollCallReply", rsvpStatus = "D", id = "id" }  // Parameter defaults
            );
            
            routes.MapRoute(
                "OutdoorPlacesList",                                  // Route name
                "Places/outdoor-rock-climbing",                           // URL with parameters
                new { controller = "Places", action = "Outdoor" }  // Parameter defaults
            );

            routes.MapRoute(
                "OutdoorPlaceList",                                  // Route name
                "places/outdoor-rock-climbing/{location}",                           // URL with parameters
                new { controller = "Places", action = "ListOutdoor", location = "{location}" }  // Parameter defaults
            );

            routes.MapRoute(
                "CountryAreaPage",                                  // Route name
                "climbing-around/{countryUrl}",                           // URL with parameters
                new { controller = "Places", action = "CountryAreaPage", countryUrl = "{countryUrl}" }  // Parameter defaults
            );

            routes.MapRoute(
                "AreaPage",                                  // Route name
                "climbing-around/{countryUrl}/{areaNameUrl}",                           // URL with parameters
                new { controller = "Places", action = "AreaPage", countryUrl = "{countryUrl}", areaNameUrl = "{areaNameUrl}" }  // Parameter defaults
            );

            routes.MapRoute(
                "IndoorPlaceList",                                  // Route name
                "places/indoor-rock-climbing-gyms/{location}",                           // URL with parameters
                new { controller = "Places", action = "ListIndoor", location = "{location}" }  // Parameter defaults
            );

            routes.MapRoute(
                "OutdoorPlace",                                  // Route name
                "places/outdoor-rock-climbing/{location}/{name}",                           // URL with parameters
                new { controller = "Places", action = "DetailOutdoor", location = "{location}", name = "{name}",  }  // Parameter defaults
            );

            routes.MapRoute(
                "DetailCrag",                                  // Route name
                "places/outdoor-rock-climbing/{location}/{placename}/{cragname}",                           // URL with parameters
                new { controller = "Places", action = "DetailCrag", location = "{location}", placename = "{placename}", cragname = "{cragname}" }  // Parameter defaults
            );

            routes.MapRoute(
                "PlaceDetail",                                  // Route name
                "places/indoor-rock-climbing-gyms/{location}/{name}",                           // URL with parameters
                new { controller = "Places", action = "DetailIndoor", location = "{location}", name = "{name}" }  // Parameter defaults
            );

            routes.MapRoute(
                "ClubDetail",                                  // Route name
                "rock-climbing-clubs/{country}/{friendlyUrlName}",                           // URL with parameters
                new { controller = "Clubs", action = "Detail", country = "{country}", friendlyUrlName = "{friendlyUrlName}" }  // Parameter defaults
            );

            routes.MapRoute(
                "FeatureArticle",                                  // Route name
                "Feature-Article/{date}/{friendlyUrl}",                           // URL with parameters
                new { controller = "News", action = "FeatureArticle", date = "{date}", friendlyUrl = "{friendlyUrl}" }  // Parameter defaults
            );

            routes.MapRoute(
                "Competition",                                  // Route name
                "News/Competitions/{date}/{friendlyUrl}",                           // URL with parameters
                new { controller = "News", action = "Competitions", date = "{date}", friendlyUrl = "{friendlyUrl}" }  // Parameter defaults
            );

            routes.MapRoute(
                "Competitions",                                  // Route name
                "Competitions",                           // URL with parameters
                new { controller = "News", action = "CompetitionsList" }  // Parameter defaults
            );

            routes.MapRoute(
                "Jobs",                                  // Route name
                "climbing-jobs",                           // URL with parameters
                new { controller = "Home", action = "Jobs" }  // Parameter defaults
            );

            routes.MapRoute(
                "2008UKRoadtrip",                                  // Route name
                "2008-UK-Roadtrip",                           // URL with parameters
                new { controller = "News", action = "Climbfind_Roadtrip_2008_11" }  // Parameter defaults
            );

            routes.MapRoute(
                "2009USCandaRoadtrip",                                  // Route name
                "2009-Climbfind-USA-Canada-Road-Trip",                           // URL with parameters
                new { controller = "Blog", action = "Index" }  // Parameter defaults
            );

            routes.MapRoute(
                "IndustryBlog",                                  // Route name
                "Industry-Blog",                           // URL with parameters
                new { controller = "Blog", action = "Industry" }  // Parameter defaults
            );

            routes.MapRoute(
                "Regulars",                                  // Route name
                "all-regular-climbers/{location}/{name}",                           // URL with parameters
                new { controller = "Places", action = "Regulars", location = "{location}", name = "{name}" }  // Parameter defaults
            );

            routes.MapRoute(
                "PlacePartners",                                  // Route name
                "people-looking-for-climbing-partners/{location}/{name}",                           // URL with parameters
                new { controller = "Places", action = "SeekingPartners", location = "{location}", name = "{name}" }  // Parameter defaults
            );

            
            routes.MapRoute(
                "ForIndoorClimbingBusinesses",                                  // Route name
                "introduction-for-climbing-centers",                           // URL with parameters
                new { controller = "Home", action = "ForIndoorClimbingBusinesses" }  // Parameter defaults
            );


            routes.MapRoute(
                "SubscribeToPartnerCalls",                                  // Route name
                "PartnerCalls/Subscribe/{location}/{name}",                           // URL with parameters
                new { controller = "PartnerCalls", action = "Subscribe", location = "{location}", name = "{name}" }  // Parameter defaults
            );

            routes.MapRoute(
                "PlacePartnersRSS",                                  // Route name
                "partners-rss-feed/{location}/{name}",                           // URL with parameters
                new { controller = "Places", action = "SeekingPartnersRSS", location = "{location}", name = "{name}" }  // Parameter defaults
            );

            routes.MapRoute(
                "AboutPartnerWidget2",                                  // Route name
                "partner-page",                           // URL with parameters
                new { controller = "Home", action = "AboutPartnerWidget" }  // Parameter defaults
            );


            routes.MapRoute(
                "AboutPartnerWidget",                                  // Route name
                "partner-widget",                           // URL with parameters
                new { controller = "Home", action = "AboutPartnerWidget" }  // Parameter defaults
            );

            routes.MapRoute(
                "AboutProfileExample",                                  // Route name
                "example-profile",                           // URL with parameters
                new { controller = "Home", action = "AboutProfileExample" }  // Parameter defaults
            );

            routes.MapRoute(
                "PartnerWidget",                                  // Route name
                "partner-widget/{location}/{name}",                           // URL with parameters
                new { controller = "Places", action = "PartnerWidget", location = "{location}", name = "{name}" }  // Parameter defaults
            );

            routes.MapRoute(
                "PartnerAreaWidget",                                  // Route name
                "partner-areawidget/{countryUrl}/{areaNameUrl}",                           // URL with parameters
                new { controller = "PartnerCalls", action = "PartnerAreaWidget", countryUrl = "{countryUrl}", areaNameUrl = "{areaNameUrl}" }  // Parameter defaults
            );

            routes.MapRoute(
                "PageNotFound",                                  // Route name
                "PageNotFound",                           // URL with parameters
                new { controller = "Shared", action = "PageNotFound" }  // Parameter defaults
            );

            routes.MapRoute(
                "SiteSearch",                                  // Route name
                "Search/{searchstr}",                           // URL with parameters
                new { controller = "Home", action = "Search" }  // Parameter defaults
            );

            routes.MapRoute(
                "UsersOnClimbfind",                             // Route name
                "users-on-climbfind",                          // URL with parameters
                new { controller = "Places", action = "AllPlaceRegulars" }  // Parameter defaults
            );


            routes.MapRoute(
                "Community",                             // Route name
                "our-community",                          // URL with parameters
                new { controller = "ClimberProfiles", action = "All" }  // Parameter defaults
            );

            routes.MapRoute(
                "WorldMap",                             // Route name
                "world-climbing-map",                          // URL with parameters
                new { controller = "Places", action = "WorldMap" }  // Parameter defaults
            );

            routes.MapRoute(
                "GradeChart",                             // Route name
                "Climbing-Grade-Comparison-Chart-Converter",                          // URL with parameters
                new { controller = "Home", action = "GradeConverter" }  // Parameter defaults
            );
            
            RegisterHomeRoute(routes, "Glossary");
            RegisterHomeRoute(routes, "About");
            RegisterHomeRoute(routes, "Help");
            RegisterHomeRoute(routes, "Find");
            RegisterHomeRoute(routes, "Join");
            RegisterHomeRoute(routes, "Feedback");
            RegisterHomeRoute(routes, "ForgottenPassword");
            RegisterHomeRoute(routes, "ThankYou");
            RegisterHomeRoute(routes, "Friends");
            RegisterHomeRoute(routes, "Pomote");
            RegisterHomeRoute(routes, "Search");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );



        }

        protected void Application_Start()
        {
            var god = new ClimberProfileDA().GetByID(new Guid("a9646cc3-18cb-4a62-8402-5263ba8b3476"));
            
            CFDataCache.Initialize();
            
            PeterBlum.VAM.Globals.Suite_LicenseKey = ConfigurationManager.AppSettings.Get("VAMSuite_LicenseKey");           
            
            RegisterRoutes(RouteTable.Routes);
        }


        void Application_Error(Object sender, EventArgs e)
        {
            try
            {
                string relativeUrl = HttpContext.Current.Request.RawUrl;
                Exception exception = getBaseException(Server.GetLastError());

                if (exception.ShouldRecord(relativeUrl))
                {
                    CFLogger.RecordException(exception);
                }

                Server.ClearError();

                if (SpecialUrls.Instance.PermanentlyMoved.ContainsKey(relativeUrl))
                {
                    Response.Status = "301 Moved Permanently";
                    Response.AddHeader("Location", SpecialUrls.Instance.PermanentlyMoved[relativeUrl]);
                    Response.Flush();
                    Response.End();
                }
                else if (SpecialUrls.Instance.UrlsGone.Contains(relativeUrl))
                {
                    Response.Status = "410 Gone";
                    Response.WriteFile(Server.MapPath("~/410UrlGone.html"));
                }
                else if (exception.Message.Contains("The controller for path") || exception.Message.Contains("A public action method"))
                {
                    Response.Redirect("~/PageNotFound");
                }
                else
                {
                    Response.Redirect("~/Home/WebFormError");
                }
            }
            catch (Exception ex)
            {
                //TODO: write to text file

                Response.Write("<span class='note'>GLOBAL ENDPOINT: PLEASE EMAIL jkresner@yahoo.com.au IF YOU SEE THIS SCREEN!!!!!!!!!!!!</span>" + ex.ToString());

                /*string newFile = PPApp.AbsoluteAppDir + @"logs\GlobalEndPointExceptions" + " " + DateTime.Now.ToLongDateString() + ".txt";

                Response.Write("Writing to file " + newFile);

                StreamWriter tw = new StreamWriter(newFile);
                tw.WriteLine(ex.ToString());
                tw.Close();*/
            }
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