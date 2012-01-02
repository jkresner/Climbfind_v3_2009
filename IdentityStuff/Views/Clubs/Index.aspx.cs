using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;
using System.Text;
using ClimbFind.Content;
using ClimbFind.Model.Enum;

namespace IdentityStuff.Views.Clubs
{
    public partial class Index : ClimbFindViewPage<ISessionViewData>
    {
        public List<Club> Clubs { get; set; }
        protected List<short> countriesWithClubs;

        protected void Page_Load(Object sender, EventArgs e)
        {
            Clubs = (from c in cfController.GetAllClubs() orderby c.CountryID, c.Name select c).ToList();
            countriesWithClubs = (from c in Clubs select c.CountryID).Distinct().ToList();
        }

        protected string getCountrysClubs(short countryID)
        {

            List<Club> countrysClubs = (from c in Clubs where c.CountryID == countryID orderby c.Name select c).ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<div style='clear:both;padding-top:20px'><img src=\"/images/UI/flags/{0}\" alt=\"{1} rock climbing clubs, mountaineering clubs in {1}\" /> <b>{1}</b><br /><br />", FlagList.GetFlag((Nation)countryID), FlagList.GetCountryName((Nation)countryID));
             
            int i = 1;              
            sb.Append("<div>"); //-- first row open div

            foreach (Club c in countrysClubs) 
            {
                sb.AppendFormat(@"<div class=""SingleProfileInList""><img src=""{0}"" /><div><a href='{1}'>{2}</a></div></div>", c.LogoMiniImageUrl, c.ClimbfindUrl, c.Name);
                if (i++ % 4 == 0) { sb.Append("</div><div style='clear:both'>"); }                
            }

            sb.Append("</div>"); // close last row div
            sb.Append("</div>"); // close all div
            
            return sb.ToString();
        }
    }
}
