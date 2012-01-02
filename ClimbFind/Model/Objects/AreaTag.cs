using ClimbFind.Content;
using ClimbFind.Helpers;
using ClimbFind.Model.Enum;

namespace ClimbFind.Model.Objects
{
    public class AreaTag : ClimbFind.Model.LinqToSqlMapping.AreaTag
    {
        public string ClimbfindUrl { get {
            if (!IsCountry)
            {
                return string.Format("/climbing-around/{0}/{1}", ((Nation)CountryID).GetCountryFriendlyUrl(), this.FriendlyUrlName);
            }
            else
            {
                return string.Format("/climbing-around/{0}", ((Nation)CountryID).GetCountryFriendlyUrl());

            }

            } 
        }

        public string FlagImageUrl
        {
            get
            {
                return "/images/ui/flags/" + FlagList.GetFlag((Nation)CountryID);
            }
        }

        public string CountryName
        {
            get
            {
                return FlagList.GetCountryName((Nation)CountryID);
            }
        }
    }
}
