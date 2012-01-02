using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using ClimbFind.Model.Enum;
using ClimbFind.Model.Objects;

namespace ClimbFind.Model.DataAccess
{
    public static class CFDataCache
    {
        //-- Properties
        private static readonly Cache cache;
        private static readonly TimeSpan _20_Min_Span_ForClimberInCahce = new TimeSpan(0, 20, 0);

        public delegate object PlaceGetterDelegate(Place place);
        public delegate object IndoorPlaceGetterDelegate(IndoorPlace place);

        public static List<FeedTag> AllFeedTags { get; set; }
        public static List<Club> AllClubs { get; set; }
        public static List<Place> AllPlaces { get; set; }
        public static List<IndoorPlace> AllIndoorPlaces { get; set; }
        public static List<OutdoorPlace> AllOutdoorPlaces { get; set; }
        public static List<AreaTag> AllAreaTags { get; set; }
        public static List<ClimberProfilePartnerStatus> AllPartnerStatus { get; set; }

        private static Dictionary<int, IndoorPlace> indoorPlaceDIC = new Dictionary<int, IndoorPlace>();
        private static Dictionary<int, Place> placeDIC = new Dictionary<int, Place>();
        private static Dictionary<int, ClimberProfilePartnerStatus> partnerStatusDIC = new Dictionary<int, ClimberProfilePartnerStatus>();
        private static Dictionary<int, Club> clubDIC = new Dictionary<int, Club>();
        private static Dictionary<int, AreaTag> areaDIC = new Dictionary<int, AreaTag>();

        //-- Contructor

        static CFDataCache()
        {
            HttpRuntime httpRT = new HttpRuntime();
            cache = HttpRuntime.Cache;

            //-- Note CacheAllIndoorPlaces does CacheAllPlaces too and we don't want to do it twice on app start
            //CacheAllPlaces(); 
            CacheAllIndoorPlaces();

            CacheAllClubs();

            CacheAllAreaTags();
            CacheAllFeedTags();


            AllPartnerStatus = new ClimberProfilePartnerStatusDA().GetAll();

            foreach (ClimberProfilePartnerStatus status in AllPartnerStatus)
            {
                partnerStatusDIC.Add(status.ID, status);
            }

            foreach (AreaTag a in AllAreaTags)
            {
                areaDIC.Add(a.ID, a);
            }
        }

        //-- Methods

        public static O GetIndoorPlaceProp<O>(IndoorPlaceGetterDelegate getMethod, int placeID) where O : class
        {
            IndoorPlace place = indoorPlaceDIC[placeID];
            return (O)getMethod.DynamicInvoke(place);
        }

        public static O GetPlaceProp<O>(PlaceGetterDelegate getMethod, int placeID) where O : class
        {
            Place place = placeDIC[placeID];
            return (O)getMethod.DynamicInvoke(place);
        }

        public static string GetPartnerStatusName(int id)
        {
            return partnerStatusDIC[id].Name;
        }

        public static Place GetPlace(int placeID)
        {
            return placeDIC[placeID];
        }

        public static AreaTag GetAreaTag(int id)
        {
            return areaDIC[id];
        }

        public static Club GetClub(int id)
        {
            return clubDIC[id];
        }

        public static void Initialize() { }

        public static void CacheAllAreaTags()
        {
            AllAreaTags = (from c in new AreaTagDA().GetAll() orderby c.FriendlyUrlName select c).ToList();
        }


        private static void CacheAllFeedTags()
        {
            AllFeedTags = (from c in new FeedTagDA().GetAll() orderby c.Name select c).ToList();
        }


        public static void CacheAllClubs()
        {
            AllClubs = new ClubDA().GetAll();

            clubDIC.Clear();
            foreach (Club club in AllClubs)
            {
                clubDIC.Add(club.ID, club);
            }
        }


        public static void CacheAllPlaces()
        {
            AllPlaces = new PlaceDA().GetAll();

            placeDIC.Clear();
            foreach (Place place in AllPlaces)
            {
                placeDIC.Add(place.ID, place);
            }
        }

        //-- Not really sure why Outdoor Places are not cached the same way indoor are
        public static void CacheAllOutdoorPlaces()
        {
            CacheAllPlaces();
        }

        public static void CacheAllIndoorPlaces()
        {
            indoorPlaceDIC = new Dictionary<int, IndoorPlace>();

            AllIndoorPlaces = new IndoorPlaceDA().GetAll();

            foreach (IndoorPlace p in AllIndoorPlaces) { indoorPlaceDIC.Add(p.ID, p); }

            CacheAllPlaces();
        }

        public static ClimberProfile GetClimberFromCache(Guid id)
        {
            string key = "climber-" + id.ToString();
            ClimberProfile cachedObject = (ClimberProfile)cache.Get(key);
            if (cachedObject == null)
            {
                //read the object from the db
                ClimberProfileDA da = new ClimberProfileDA();
                cachedObject = da.GetByID(id);
                cache.Insert(key, cachedObject, null, Cache.NoAbsoluteExpiration, _20_Min_Span_ForClimberInCahce, CacheItemPriority.NotRemovable, null);
            }
            return cachedObject;
        }

        public static void FlushClimberFromCache(Guid id)
        {
            string key = "climber-" + id.ToString();
            cache.Remove(key);
        }

        //private static IOOObject getObjectFromCache<IOOObject, TIPPDataAccessor>(int id, string key, TimeSpan cacheTimeSpan)
        //    where TIPPDataAccessor : IPPDataAccessor<IOOObject>, new()
        //    where TIPPObject : IPPObject
        //{
        //    string localKey = key + id.ToString();
        //    TIPPObject cachedObject = (TIPPObject)cache.Get(key);	// read from cache
        //    if (cachedObject == null)
        //    {
        //        // read the object from the db
        //        TIPPDataAccessor da = new TIPPDataAccessor();
        //        cachedObject = da.getObjectByID(id);
        //        cache.Insert(localKey, cachedObject, null, Cache.NoAbsoluteExpiration, cacheTimeSpan, CacheItemPriority.NotRemovable, null);
        //    }
        //    return cachedObject;
        //}


    }
}
