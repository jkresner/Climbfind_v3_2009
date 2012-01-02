using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Enum;
using ClimbFind.Model.Objects;
using LinqToSql_PlaceOutdoorCrag = ClimbFind.Model.LinqToSqlMapping.PlaceOutdoorCrag;

namespace ClimbFind.Model.DataAccess
{
    public class OutdoorCragDA : AbstractBaseDA<OutdoorCrag, LinqToSql_PlaceOutdoorCrag, Guid>
    {
        protected override OutdoorCrag MapLinqTypeToOOType(LinqToSql_PlaceOutdoorCrag o)
        {
            OutdoorCrag o2 = new OutdoorCrag();
            MapValues(o2, o.GetProperyNameAndValues());

            o2.FriendlyUrlLocation = o.PlaceOutdoorDetail.Place.FriendlyUrlLocation;
            o2.FriendlyUrlPlaceName = o.PlaceOutdoorDetail.Place.FriendlyUrlName;

            return (o2);
        }
     
        /// <summary>
        /// 
        /// </summary>
        public List<OutdoorCrag> GetCragsAtPlace(int placeID)
        {
            return MapList((from c in ctx.PlaceOutdoorCrags where c.PlaceID == placeID select c).ToList());
        }


        public OutdoorCrag Get(int placeID, string friendlyUrlName)
        {
            LinqToSql_PlaceOutdoorCrag crag = (from c in ctx.PlaceOutdoorCrags
                                               where c.PlaceID == placeID
                                         && c.FriendlyUrlName == friendlyUrlName
                                     select c).SingleOrDefault();

            if (crag == default(LinqToSql_PlaceOutdoorCrag)) { return null; }
            else { return MapType(crag); }
        }
    }
}
