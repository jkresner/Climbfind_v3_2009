using ClimbFind.Model.Objects;
using ClimbFind.Model.Objects.Interfaces;
using ClimbFind.Content;
using ClimbFind.Model.Enum;

namespace IdentityStuff.UI
{
    public static class PageMetaInfoGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        public static string GetTitle(IClimbingPlace place)
        {
            if (place.IsIndoor) { return string.Format("Indoor rock climbing at {0} & {1} climbing partners - Climbfind.com", place.Name, place.ShortName); }
            else { return string.Format("Outdoor rock climbing at {0} & {1} climbing partners - Climbfind.com", place.Name, place.ShortName); }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GetMetaDescription(IClimbingPlace place)
        {
            if ( string.IsNullOrEmpty(place.MetaDescription )) 
            {
                if (place.IsIndoor) { return string.Format("Info on indoor rock climbing at {0} in {2} including people who climb at {1}, people looking for {0} climbing partners and media related to {1}", place.Name, place.ShortName, FlagList.GetCountryName((Nation)place.CountryID)); }
                else { return string.Format("Info on outdoor rock climbing around {0} in {2} including people who climb around {1}, people looking for climbing partners in {0} and media related to {1}", place.Name, place.ShortName, FlagList.GetCountryName((Nation)place.CountryID)); }
            }         
            else { return place.MetaDescription; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GetMetaKeywords(IClimbingPlace place)
        {
            if (string.IsNullOrEmpty(place.MetaKeywords)) 
            {
                if (place.IsIndoor) { return string.Format("Indoor climbing, rock climbing gym {0}, {1}", ((IndoorPlace)place).Address, place.Name); }
                else { return string.Format("Outdoor rock climbing, {0}", place.Name); }
            }
            else { return place.MetaKeywords; }
        }


        /// <summary>
        /// 
        /// </summary>
        public static string GetTitle(AreaTag area, bool forIndoor)
        {
            if (forIndoor) { return string.Format("Indoor rock climbing in {0} - Climbfind.com", area.ParagraphName); }
            else { return string.Format("Outdoor rock climbing around {0} - Climbfind.com", area.ParagraphName); }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GetMetaDescription(AreaTag area, bool forIndoor)
        {
            if (forIndoor) 
            {
                return string.Format("Indoor rock climbing gyms in {0}, {0} mountaineering clubs, climbing clubs {0}", area.ParagraphName); 
            }
            else 
            { 
                return string.Format("Outdoor rock climbing  locations in {0}", area.ParagraphName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GetMetaKeywords(AreaTag area, bool forIndoor)
        {
            if (forIndoor)
            {
                return string.Format("Indoor rock climbing, climbing gym {0}, find rock climbing partners {0}", area.ParagraphName); 
            }
            else
            {
                return string.Format("Outdoor rock climbing, climbing locations in {0}, find outdoor climbing partners {0}", area.ParagraphName); 
            }
        }

        //public static string GetTitle(OutdoorPlace place)
        //{
        //    return string.Format("Outdoor rock climbing at {0} - Climbfind.com", place.Name);
        //}

        //public static string GetTitle(IndoorPlace place)
        //{
        //    return string.Format("Indoor rock climbing at {0} - Climbfind.com", place.Name);
        //}

        //public static string GetMetaDescription(OutdoorPlace place)
        //{
        //    if (string.IsNullOrEmpty(place.MetaDescription)) { return string.Format("Climb outdoors at {0} - Climbfind.com", place.Name); }
        //    else { return place.MetaDescription; }             
        //}

        //public static string GetMetaDescription(IndoorPlace place)
        //{
        //    if (string.IsNullOrEmpty(place.MetaDescription)) { return string.Format("Climb indoors at {0} - Climbfind.com", place.Name); }
        //    else { return place.MetaDescription; }
        //}

        //public static string GetMetaKeywords(OutdoorPlace place)
        //{
        //    if (string.IsNullOrEmpty(place.MetaKeywords)) { return string.Format("Outdoor rock climbing, {0}", place.Name); }
        //    else { return place.MetaKeywords; }
        //}

        //public static string GetMetaKeywords(IndoorPlace place)
        //{
        //    if (string.IsNullOrEmpty(place.MetaKeywords)) { return string.Format("Indoor climbing, rock climbing gym {0}, {1}", place.Address, place.Name); }
        //    else { return place.MetaKeywords; }
        //}
    }
}
