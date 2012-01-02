using System.Web.Mvc;
using System.Linq;
using ClimbFind.Content;
using ClimbFind.Controller;
using ClimbFind.Model.Enum;
using ClimbFind.Model.Objects;
using IdentityStuff.Controllers.ActionFilters;
using ClimbFind.Web.Mvc.Views.PartnerCalls;
using System.Collections.Generic;
using ClimbFind.Model.DataAccess;
using ClimbFind.Helpers;

namespace ClimbFind.Web.Mvc.Controllers
{
    [HandleError(View = "Error")]
    public class PlacesController : BaseController
    {
        public ActionResult Index()
        {
            SetPageMetaData("Find indoor rock climbing gyms and outdoor climbing locations - Climbfind.com",
                "Find rock climbing gyms in your area, find outdoor rock climbing places",
                "Rock climbing routes, indoor climbing gyms", PageRobots.IndexFollow);

            return View();
        }


        public ActionResult Outdoor()
        {
            SetPageMetaData("Find outdoor climbing locations around the world - Climbfind.com",
                "Find outdoor rock climbing around the world",
                "Rock climbing routes, climbing crags", PageRobots.IndexFollow);

            return View();
        }


        public ActionResult Indoor()
        {
            SetPageMetaData("Find indoor climbing gyms and indoor climbing centres around the world - Climbfind.com",
                "Find indoor rock climbing locations around the world",
                "Rock climbing gyms, climbing centres, indoor climbing, indoor bouldering", PageRobots.IndexFollow);

            return View();
        }

        private ActionResult RenderAreaPage(AreaTag area)
        {
            if (area == default(AreaTag)) { return RedirectToAction("Index"); }
            else
            {
                string title = string.Format("Rock climbing around {0}, climbing gyms in {0}, {0} outdoor climbing & climbing clubs around {0}", area.ParagraphName);
                string description = string.Format("Information about indoor climbing in {0}, find places to climb outdoors in {0} and mountaineering clubs around", area.ParagraphName);
                string keywords = string.Format("{0} indoor climbing walls, climb outdoors {0}, {0} climbing partners, Bouldering {0}, {0} Climbing Information, Map of {0} climbs, {0} climbing clubs", area.Name);

                SetPageMetaData(title, description, keywords, PageRobots.IndexFollow);
                return View("AreaPage", area);
            }
        }

        public ActionResult CountryAreaPage(string countryUrl)
        {
            AreaTag area = new CFController().GetAreaTagForCountry(countryUrl);
            return RenderAreaPage(area);
        }


        public ActionResult AreaPage(string countryUrl, string areaNameUrl)
        {
            AreaTag area = new CFController().GetAreaTagByCountryUrlAndName(countryUrl, areaNameUrl);
            return RenderAreaPage(area);
        }
        
        public ActionResult DetailOutdoor(string location, string name)
        {
            OutdoorPlace place = new CFController().GetOutdoorPlace(location, name);

            if (place == null) { return RedirectToAction("Index"); }
            else
            {
                SetPageMetaData(place);
                return View(place);
            }   
        }

        public ActionResult DetailCrag(string location, string placename, string cragname)
        {
            OutdoorPlace place = new CFController().GetOutdoorPlace(location, placename);
            if (place == null) { return RedirectToAction("Index"); }
            else
            {
                OutdoorCrag crag = new CFController().GetCrag(place.ID, cragname);
                if (crag == null) { return RedirectToAction("Index"); }
                else
                {
                    string country = FlagList.GetCountryName((Nation)place.CountryID);
                    string title = string.Format("{0}, Climbing at {1} - {2} Outdoor Rock Climbing - Climbfind.com", crag.Name, place.Name, country);
                    string description = string.Format("Infomation about {0} in {1} at {2} including the history of {0}, access to {0}, routes on {0}, movies & discussion.", crag.Name, country, place.Name);
                    string keywords = string.Format("Climbing {0}, {0} routes, Rock Climbing {1}", crag.Name, country);
                    //-- TODO: fix up the meta data
                    SetPageMetaData(title, description, keywords, PageRobots.IndexFollow);
                    return View(crag);
                }
            }   
        }

        

        public ActionResult DetailIndoor(string location, string name)
        {
            IndoorPlace place = new CFController().GetIndoorPlace(location, name);

            if (place == null) { return RedirectToAction("Index"); }
            else
            {
                SetPageMetaData(place);
                return View(place);
            }          
        }

        //-- TODO: add caching vary by param
        [LoginFilter(LoginMessage = "To view all regulars at a place, please login or register an account")]
        public ActionResult Regulars(string location, string name)
        {
            Place place = new CFController().GetPlace(location, name);

            if (place == null) { return RedirectToAction("Index"); }
            else
            {
                SetPageMetaData();
                return View(place);
            }  
        }


        public ActionResult SeekingPartnersRSS(string location, string name)
        {
            Place place = new CFController().GetPlace(location, name);

            if (place == null) { return RedirectToAction("Index"); }
            else
            {
                return View(place);
            }
        }

        public ActionResult SeekingPartners(string location, string name)
        {
            Place place = new CFController().GetPlace(location, name);

            if (place == null) { return RedirectToAction("Index"); }
            else
            {
                string title = string.Format("People seeking climbing partners at {0} - Climbfind.com", place.Name);
                string description = string.Format("A list of climbing enthusiasts seeking friends to climb with at {0}", place.ShortName);
                string keywords = string.Format("{0} Climbing partners, partner at {1}", place.ShortName, place.Name);

                SetPageMetaData(title, description, keywords, PageRobots.IndexNoFollow);
                return View(place);
            }
        }

        public ActionResult WorldMap()
        {
            string title = "World map of climbing gyms, climbing walls and outdoor rock climbing locations - Climbfind.com";
            string description = "A map of the world detailing climbing gyms, climbing centres, indoor climbing wall, outdoor climbing locations, crags, boulders and more";
            string keywords = "Indoor climbing gyms, climbing centres, outdoor climbing locations, bouldering, crags";

            SetPageMetaData(title, description, keywords, PageRobots.IndexFollow);
            return View();
        }


        public ActionResult PartnerWidget(string location, string name)
        {
            Place place = new CFController().GetPlace(location, name);

            if (place == null) { return RedirectToAction("Index"); }
            else if (place.ID == 316) { return RedirectToAction("CustomVWPartnerWidget", "PartnerCalls", new { Site = Request.QueryString["Site"].ToString() }); }
			else if (placeIDsOnPartnerWidget2.Contains(place.ID)) //-- Adrenaline Climbing
            {
            	return View("PartnerWidget2", place);
            }
            else
            {
                SetPageMetaData("Partner Widget: " + place.Name, "", "", PageRobots.NoIndexNoFollow);
                return View(place);
            }
        }

		private List<int> placeIDsOnPartnerWidget2 = new List<int>()
		                                             	{
		                                             		844 //Adrenaline Climbing
		                                             	};


        //-- Deprecated action methods.

        //[OutputCache(Duration = 3600, VaryByParam = "location")]
        public ActionResult ListIndoor(string location)
        {
            return RedirectToAction("Index");
        }

        //[OutputCache(Duration = 3600, VaryByParam = "location")]
        public ActionResult ListOutdoor(string location)
        {
            return RedirectToAction("Index");
        }


        public ActionResult FilterSearch(string q, int limit, string timestamp)
        {
            List<Place> places = (from c in CFDataCache.AllPlaces where c.Name.ContainsCaseInsensitive(q) ||
                                      c.ShortName.ContainsCaseInsensitive(q) orderby c.CountryID
                                  select c).Take(limit).ToList();

            if (places.Count == 0)
            {
                places.Add(new Place
                {
                    ID = -1,
                    CountryID = 0,
                    Name = string.Format("No result for {0} - Add to Climbfind?", q)
                });
            }

            return View(places);
        }

        public ActionResult FilterAreaSearch(string q, int limit, string timestamp)
        {
            List<AreaTag> areas = (from c in CFDataCache.AllAreaTags
                                  where c.Name.ContainsCaseInsensitive(q) ||
                                      c.ParagraphName.ContainsCaseInsensitive(q)
                                  orderby c.CountryID
                                  select c).Take(limit).ToList();

            if (areas.Count == 0)
            {
                areas.Add(new AreaTag
                {
                    ID = -1,
                    CountryID = 0,
                    Name = string.Format("No result for {0} - Add to Climbfind?", q)
                });
            }

            return View(areas);
        }

        public ActionResult FilterCountryAreaSearch(short CID, string q, int limit, string timestamp)
        {
            List<AreaTag> areas = (from c in CFDataCache.AllAreaTags
                                   where (c.Name.ContainsCaseInsensitive(q) ||
                                       c.ParagraphName.ContainsCaseInsensitive(q))
                                        && c.CountryID == CID
                                   orderby c.Name
                                   select c).Take(limit).ToList();

            if (areas.Count == 0)
            {
                areas.Add(new AreaTag
                {
                    ID = -1,
                    CountryID = 0,
                    Name = string.Format("No result for {0} - Add to Climbfind?", q)
                });
            }

            return View("FilterAreaSearch", areas);
        }


        public ActionResult FilterSearchOutdoor(string q, int limit, string timestamp)
        {
            List<Place> places = (from c in CFDataCache.AllPlaces
                                  where !c.IsIndoor &&     
                                      (c.Name.ContainsCaseInsensitive(q) ||
                                      c.ShortName.ContainsCaseInsensitive(q))
                                  orderby c.CountryID
                                  select c).Take(limit).ToList();

            return View("FilterSearch", places);
        }

        public ActionResult FilterSearchIndoor(string q, int limit, string timestamp)
        {
            List<Place> places = (from c in CFDataCache.AllPlaces
                                  where c.IsIndoor &&
                                      (c.Name.ContainsCaseInsensitive(q) ||
                                      c.ShortName.ContainsCaseInsensitive(q))
                                  orderby c.CountryID
                                  select c).Take(limit).ToList();

            return View("FilterSearch", places);
        }

        public ActionResult FilterGoTo(string q, int limit, string timestamp)
        {
            List<Place> places = (from c in CFDataCache.AllPlaces
                                  where c.Name.ContainsCaseInsensitive(q) ||
                                      c.ShortName.ContainsCaseInsensitive(q)
                                  orderby c.CountryID
                                  select c).Take(limit).ToList();

            return View(places);
        }      
    }
}
