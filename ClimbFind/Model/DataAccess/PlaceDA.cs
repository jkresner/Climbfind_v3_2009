using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using ClimbFind.Model.Objects;
using LinqToSql_Place = ClimbFind.Model.LinqToSqlMapping.Place;
using LinqToSql_PlaceArea = ClimbFind.Model.LinqToSqlMapping.PlacesInArea;

namespace ClimbFind.Model.DataAccess
{
    public class PlaceDA : AbstractBaseDA<Place, LinqToSql_Place, int>
    {
        public PlaceDA() : base() { }
        public PlaceDA(IDATransactionContext transactionContext) : base(transactionContext) { }

        /// <summary>
        /// 
        /// </summary>
        public Place GetByUrl(string friendlyUrlLocation, string friendlyUrlName)
        {
            LinqToSql_Place place = (from c in ctx.Places
                                     where c.FriendlyUrlLocation == friendlyUrlLocation
                                         && c.FriendlyUrlName == friendlyUrlName
                                     select c).SingleOrDefault();

            if (place == default(LinqToSql_Place)) { return null; }
            else { return MapType(place); }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<Place> GetPlacesUserClimbsAt(Guid userID)
        {
            return MapList((from puc in ctx.PlaceUserClimbs
                             from p in EntityTable
                             where puc.UserID == userID
                             && p.ID == puc.PlaceID
                             select p).ToList());
        }

        public bool UserClimbAtPlace(Guid userID, int placeID)
        {
            return (from c in ctx.PlaceUserClimbs where c.UserID == userID && c.PlaceID == placeID select c).Count() > 0;
        }
        


        /// <summary>
        /// 
        /// </summary>
        public List<Place> GetCountrysPlaces(Guid userID)
        {
            return MapList((from puc in ctx.PlaceUserClimbs
                            from p in EntityTable
                            where puc.UserID == userID
                            && p.ID == puc.PlaceID
                            select p).ToList());
        }

        public List<Place> Search(string name)
        {
            string lowerName = name.ToLower();

            var query = from c in ctx.Places where c.Name.Contains(lowerName) || c.ShortName.Contains(lowerName) select c;
            var addressQuery = (from c in ctx.Places from ip in ctx.PlaceIndoorDetails where ip.Address.Contains(lowerName) && ip.ID == c.ID select c);
            var superQuery = query.Union(addressQuery);

            return MapList(superQuery.ToList());
        }
       
        /// <summary>
        /// 
        /// </summary>
        public void DeletePlaceArea(int placeID, int areaTagID)
        {
            ctx.PlacesInAreas.DeleteOnSubmit( (from c in ctx.PlacesInAreas 
                                               where c.PlaceID == placeID &&
                                               c.AreaTagID == areaTagID
                                              select c).SingleOrDefault() );

            CommitChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        public void InsertPlaceArea(int placeID, int areaTagID)
        {
            ctx.PlacesInAreas.InsertOnSubmit(new LinqToSql_PlaceArea { AreaTagID = areaTagID, PlaceID = placeID });
            CommitChanges();
        }

        public Place Update(OutdoorPlace outdoorPlace)
        {
            NameValueCollection propsAndVals =  outdoorPlace.GetProperyNameAndValues();
            propsAndVals.Remove("ClimbfindUrl"); // causes exception because it does not have a setter.            
            Place place = MapValues(new Place(), propsAndVals);
            return base.Update(place);
        }

        public Place Update(IndoorPlace indoorPlace)
        {
            NameValueCollection propsAndVals = indoorPlace.GetProperyNameAndValues();
            propsAndVals.Remove("ClimbfindUrl"); // causes exception because it does not have a setter.            
            Place place = MapValues(new Place(), propsAndVals);
            return base.Update(place);
        }

        /// <summary>
        /// 
        /// </summary>
        public List<Place> GetPlacesInArea(int areaID)
        {
            return MapList((from pia in ctx.PlacesInAreas
                            from p in ctx.Places
                            where pia.AreaTagID == areaID && pia.PlaceID == p.ID
                            select p).ToList());
        }
    }
}
