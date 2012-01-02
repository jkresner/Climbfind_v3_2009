using System;
using ClimbFind.Content;
using ClimbFind.Helpers;
using ClimbFind.Model.Enum;

namespace ClimbFind.Model.Objects
{
    public class Club : ClimbFind.Model.LinqToSqlMapping.Club
    {
        public new string ShortName 
        {
         get { if (String.IsNullOrEmpty( base.ShortName)) { return Name; } else { return base.ShortName; } }          
         set { base.ShortName = value; } 
        }
        
        public string ClimbfindUrl { get { return string.Format("/rock-climbing-clubs/{0}/{1}", FriendlyCountryUrl, FriendlyUrlName); } }
        
        public string FriendlyCountryUrl { get { return ((Nation)CountryID).GetCountryFriendlyUrl(); } }

        public string Country { get { return FlagList.GetCountryName((Nation)CountryID); } }

        public string FlagImageUrl
        {
            get
            {
                return "/images/ui/flags/" + FlagList.GetFlag((Nation)CountryID);
            }
        }

        public string LogoImageUrl 
        { 
            get 
            { 
                return "/images/clubs/logos/" + LogoImageFile;
            } 
        }


        public string LogoMiniImageUrl
        {
            get
            {
                return "/images/clubs/logos/half/" + LogoImageFile;
            }
        } 

    }
}
