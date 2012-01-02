using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Objects;
using LinqToSql_IndoorPlace = ClimbFind.Model.LinqToSqlMapping.PlaceIndoorDetail;
using LinqToSql_Place = ClimbFind.Model.LinqToSqlMapping.Place;

namespace ClimbFind.Model.DataAccess
{
    public class IndoorPlaceDA : AbstractBaseDA<IndoorPlace, LinqToSql_IndoorPlace, int>
    {
        /// <summary>
        /// 
        /// </summary>
        protected override IndoorPlace MapLinqTypeToOOType(LinqToSql_IndoorPlace o)
        {
            IndoorPlace o2 = new IndoorPlace();
            MapValues(o2, o.GetProperyNameAndValues());
            MapValues(o2, o.Place.GetProperyNameAndValues());

            if (String.IsNullOrEmpty(o2.ShortName)) { o2.ShortName = o2.Name; }

            return (o2);
        }

        /// <summary>
        /// 
        /// </summary>
        public IndoorPlace GetByUrl(string friendlyUrlLocation, string friendlyUrlName)
        {
            LinqToSql_Place place = (from c in ctx.Places where c.FriendlyUrlLocation == friendlyUrlLocation
                                && c.FriendlyUrlName == friendlyUrlName select c).SingleOrDefault();
            
            if (place == default(LinqToSql_Place)) { return null; }
            else { return GetByID(place.ID); }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<IndoorPlace> GetPlacesInArea(int areaID)
        {
            //List<int> placeIDsInArea = (from c in ctx.PlacesInAreas where c.AreaTagID == areaID select c.PlaceID).ToList();

            //return MapList((from c in ctx.PlaceIndoorDetails where placeIDsInArea.Contains(c.ID) select c).ToList());

            return MapList((from pia in ctx.PlacesInAreas
                            from ip in ctx.PlaceIndoorDetails
                            where pia.AreaTagID == areaID && pia.PlaceID == ip.ID
                            select ip).ToList());
        }
    }
}
