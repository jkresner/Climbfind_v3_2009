using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Enum;
using ClimbFind.Model.Objects;
using LinqToSql_AreaTag = ClimbFind.Model.LinqToSqlMapping.AreaTag;

namespace ClimbFind.Model.DataAccess
{
    public class AreaTagDA : AbstractBaseDA<AreaTag, LinqToSql_AreaTag, int>
    {
        public AreaTag GetAreaTagByFriendlyUrlName(Nation nation, string friendlyUrlName)
        {
            return MapType((from c in ctx.AreaTags where c.CountryID == (short)nation && c.FriendlyUrlName == friendlyUrlName select c).SingleOrDefault());
        }

        public List<AreaTag> GetAreaTagsForAPlace(int placeID)
        {
            var query = from pia in ctx.PlacesInAreas
                        from a in ctx.AreaTags
                        where pia.PlaceID == placeID
                            && a.ID == pia.AreaTagID
                        select a;                  
            
            return MapList((query).ToList());
        }


        public bool AreaTagsForPlaceExists(int placeID, int areaID)
        {
            return (from pia in ctx.PlacesInAreas
                        where pia.PlaceID == placeID
                            && areaID == pia.AreaTagID
                        select pia).Count() > 0;
        }

        
        public List<AreaTag> Search(string name)
        {
            string lowerName = name.ToLower();

            var query = from c in ctx.AreaTags where c.Name.Contains(lowerName) select c;

            return MapList(query.ToList());
        }


        public List<AreaTag> GetAreaTagsForAClub(int clubID)
        {
            var query = from cia in ctx.ClubInAreas
                        from a in ctx.AreaTags
                        where cia.ClubID == clubID
                            && a.ID == cia.AreaTagID
                        select a;

            return MapList((query).ToList());
        }

        public AreaTag GetCountrysAreaTag(Nation nation)
        {
            return MapType((from c in ctx.AreaTags where c.CountryID == (short)nation && c.IsCountry select c).SingleOrDefault());
        }       
    }
}
