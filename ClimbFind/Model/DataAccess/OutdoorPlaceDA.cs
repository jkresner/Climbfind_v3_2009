using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Objects;
using LinqToSql_OutdoorPlace = ClimbFind.Model.LinqToSqlMapping.PlaceOutdoorDetail;
using LinqToSql_Place = ClimbFind.Model.LinqToSqlMapping.Place;
using LinqToSql_PlaceOutdoorAuthority = ClimbFind.Model.LinqToSqlMapping.PlaceOutdoorAuthority;


namespace ClimbFind.Model.DataAccess
{
    public class OutdoorPlaceDA : AbstractBaseDA<OutdoorPlace, LinqToSql_OutdoorPlace, int>
    {
        protected override OutdoorPlace MapLinqTypeToOOType(LinqToSql_OutdoorPlace o)
        {
            OutdoorPlace o2 = new OutdoorPlace();
            MapValues(o2, o.GetProperyNameAndValues());
            MapValues(o2, o.Place.GetProperyNameAndValues());

            if (String.IsNullOrEmpty(o2.ShortName)) { o2.ShortName = o2.Name; }

            return (o2);
        }

        /// <summary>
        /// 
        /// </summary>
        public OutdoorPlace GetByUrl(string friendlyUrlLocation, string friendlyUrlName)
        {
            LinqToSql_Place place = (from c in ctx.Places
                                     where c.FriendlyUrlLocation == friendlyUrlLocation
                                         && c.FriendlyUrlName == friendlyUrlName
                                     select c).SingleOrDefault();

            if (place == default(LinqToSql_Place)) { return null; }
            else { return GetByID(place.ID); }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<OutdoorPlace> GetPlacesInArea(int areaID)
        {
            //List<int> placeIDsInArea = (from c in ctx.PlacesInAreas where c.AreaTagID == areaID select c.PlaceID).ToList();

            //return MapList((from c in ctx.PlaceOutdoorDetails where placeIDsInArea.Contains(c.ID) select c).ToList());
            return MapList((from pia in ctx.PlacesInAreas
                            from op in ctx.PlaceOutdoorDetails
                            where pia.AreaTagID == areaID && pia.PlaceID == op.ID
                            select op).ToList());
        }

        /// <summary>
        /// 
        /// </summary>
        public List<OutdoorPlaceAuthority> GetPlacesAuthoritySites(int placeID)
        {
            return (from c in ctx.PlaceOutdoorAuthorities where c.PlaceID == placeID select 
                     new OutdoorPlaceAuthority { ID = c.ID, Name = c.Name, PlaceID = c.PlaceID, Url = c.Url }).ToList();
        }  

        public void InsertAuthoritySite(OutdoorPlaceAuthority site)
        {
            ctx.PlaceOutdoorAuthorities.InsertOnSubmit( new LinqToSql_PlaceOutdoorAuthority
             { Name = site.Name, Url = site.Url, PlaceID = site.PlaceID });
 
            CommitChanges();
        }

        public void DeleteAuthoritySite(int siteID)
        {
            ctx.PlaceOutdoorAuthorities.DeleteOnSubmit(
                (from c in ctx.PlaceOutdoorAuthorities where c.ID == siteID select c).SingleOrDefault());

            CommitChanges();
        }
        

    }
}
