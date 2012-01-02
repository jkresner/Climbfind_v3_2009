using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Controller;
using ClimbFind.Model.Objects;
using ClimbFind.Model.Enum;
using System.Text;
using ClimbFind.Content;
using ClimbFind.Model.DataAccess;

namespace IdentityStuff.Views.Places
{
    public partial class IndexCache : System.Web.Mvc.ViewUserControl
    {
        public List<AreaTag> Areas { get; set; }
        public Dictionary<AreaTag, int> IndoorAreasAndPlaceCount { get; set; }
        public Dictionary<AreaTag, int> OutdoorAreasAndPlaceCount { get; set; }
        public List<OutdoorPlace> AllOutdoorPlaces { get; set; }
        protected List<short> countriesWithLocations;


        protected void Page_Init(Object s, EventArgs e)
        {
            CFController cfController = new CFController();
            
            Areas = cfController.GetAllAreaTags();
            IndoorAreasAndPlaceCount = cfController.GetAreaNamesAndPlaceCount(true);
            OutdoorAreasAndPlaceCount = cfController.GetAreaNamesAndPlaceCount(false);

            countriesWithLocations = (from c in CFDataCache.AllPlaces
                                      select c.CountryID).Distinct().ToList();

            countriesWithLocations.Remove((short)Nation.Canada);
            countriesWithLocations.Remove((short)Nation.UnitedStates);
            countriesWithLocations.Remove((short)Nation.England);
            countriesWithLocations.Remove((short)Nation.Australia);

            List<AreaTag> tags = (from c in countriesWithLocations
                                      from at in CFDataCache.AllAreaTags
                                      where c == at.CountryID
                                      && at.IsCountry
                                      select at).ToList();

            countriesWithLocations = (from c in tags
                                      orderby c.Name ascending
                                      select (short)c.CountryID).ToList();
        }

        protected string GetCountriesSetOfAreaPages(Nation nation)
        {
            List<AreaTag> subAreaTags = (from c in IndoorAreasAndPlaceCount.Keys where c.CountryID == (short)nation && !c.IsCountry select c).ToList();
            AreaTag countryAreaTags = (from c in IndoorAreasAndPlaceCount.Keys where c.CountryID == (short)nation && c.IsCountry select c).SingleOrDefault();

            StringBuilder sb = new StringBuilder("<div>");
            sb.AppendFormat("<img src=\"/images/UI/flags/{0}\" alt=\"Rock climbing gyms in {1}, {1} indoor climbing walls and outdoor climbing around {1}\" /><b> ", FlagList.GetFlag(nation), FlagList.GetCountryName(nation));
            sb.AppendFormat(GetAreaPage(countryAreaTags));
            sb.Append("</b></div>");
            sb.Append("<div style=\"font-size:10px;padding:2px 0px 8px 10px\">");
            foreach (AreaTag tag in subAreaTags) 
            {
                sb.AppendFormat(GetAreaPage(tag));
                sb.Append("<br />");
            }

            sb.Append("</div>");

            return sb.ToString();
        }


        protected string GetAreaPage(AreaTag areaTag)
        {
            //-- TODO: make title better
            string title = string.Format("Indoor climbing {0}, outdoor rock climbing {0} & climbing clubs around {0}", areaTag.ParagraphName);

            return string.Format("<a href='{0}' title='{1}'>{2}</a> ({3}/{4})", areaTag.ClimbfindUrl, 
                title, areaTag.ParagraphName, IndoorAreasAndPlaceCount[areaTag], OutdoorAreasAndPlaceCount[areaTag]);
        }
    }
}
