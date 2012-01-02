using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Helpers;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Enum;
using ClimbFind.Model.Objects;


namespace ClimbFind.Controller
{
    public partial class CFController
    {       
        /// <summary>
        /// Place stuff
        /// </summary>
        /// 
     
        public Place GetPlace(int id) 
        { 
            return CFDataCache.GetPlace(id); 
        }

        public IndoorPlace GetIndoorPlace(string location, string name) 
        {
            return new IndoorPlaceDA().GetByUrl(location, name);
        }

        /// <summary>
        /// 
        /// </summary>
        public OutdoorPlace GetOutdoorPlace(string location, string name)
        {
            return new OutdoorPlaceDA().GetByUrl(location, name);
        }

        /// <summary>
        /// 
        /// </summary>
        public OutdoorPlace GetOutdoorPlace(int id)
        {
            return new OutdoorPlaceDA().GetByID(id);
        }

        /// <summary>
        /// 
        /// </summary>
        public OutdoorCrag GetCrag(int placeID, string friendlyUrlName)
        {
            return new OutdoorCragDA().Get(placeID, friendlyUrlName);
        }

        public OutdoorCrag GetCrag(Guid cragID)
        {
            return new OutdoorCragDA().GetByID(cragID);
        }

        /// <summary>
        /// 
        /// </summary>
        public IndoorPlace GetIndoorPlace(int id)
        {
            return new IndoorPlaceDA().GetByID(id);
        }    

        /// <summary>
        /// 
        /// </summary>
        public Place GetPlace(string location, string name)
        {            
            return new PlaceDA().GetByUrl(location, name);
        }


        public List<OutdoorPlace> GetAllOutdoorPlaces()
        {
            return new OutdoorPlaceDA().GetAll();
        }

        public List<IndoorPlace> GetAllIndoorPlaces()
        {
            return new IndoorPlaceDA().GetAll();
        }



        /// <summary>
        /// 
        /// </summary>
        public List<Place> GetAllPlaces()
        {
            return CFDataCache.AllPlaces;
        }

        /// <summary>
        /// 
        /// </summary>
        public List<Place> GetCountrysPlaces(short countryID)
        {
            return (from c in GetAllPlaces() where c.CountryID == countryID select c).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        public List<Place> GetPlacesUserClimbs(Guid userID)
        {
            return new PlaceDA().GetPlacesUserClimbsAt(userID);
        }

        public bool UserClimbAtPlace(Guid userID, int placeID)
        {
            return new PlaceDA().UserClimbAtPlace(userID, placeID);
        }



        /// <summary>
        /// 
        /// </summary>
        public List<OutdoorCrag> GetAllOutdoorCrags()
        {
            return new OutdoorCragDA().GetAll();
        }

        public List<Place> GetPlacesInArea(int areaID)
        {
            return new PlaceDA().GetPlacesInArea(areaID);
        }

        public List<IndoorPlace> GetIndoorPlacesInArea(int areaID)
        {
            return new IndoorPlaceDA().GetPlacesInArea(areaID);
        }

        public List<OutdoorPlace> GetOutdoorPlacesInArea(int areaID)
        {
            return new OutdoorPlaceDA().GetPlacesInArea(areaID);
        }

        public List<OutdoorPlaceAuthority> GetOutdoorPlacesAuthoriySites(int placeID)
        {
            return new OutdoorPlaceDA().GetPlacesAuthoritySites(placeID);
        }

        //-- This is shit code, I was full on ribs at jim's place and lazy when writting this...
        public void AddOutdoorPlaceAuthoriySites(OutdoorPlaceAuthority site)
        {
            new OutdoorPlaceDA().InsertAuthoritySite(site);
        }

        public void RemoveOutdoorPlaceAuthoriySites(int siteID)
        {
            new OutdoorPlaceDA().DeleteAuthoritySite(siteID);
        }

        /// <summary>
        /// 
        /// </summary>
        public List<AreaTag> GetAllAreaTags()
        {
            return CFDataCache.AllAreaTags;
        }


        /// <summary>
        /// 
        /// </summary>

        public AreaTag GetAreaTag(int id)
        {
            return new AreaTagDA().GetByID(id);
        }
        
        public List<AreaTag> GetAreaTagsForAPlace(int placeID)
        {
            return new AreaTagDA().GetAreaTagsForAPlace(placeID);
        }

        public bool PlaceBelongsToArea(int placeID, int areaTagID)
        {
            return new AreaTagDA().AreaTagsForPlaceExists(placeID, areaTagID);
        }

        public AreaTag GetAreaTagForCountry(string countryUrl)
        {
            return new AreaTagDA().GetCountrysAreaTag(countryUrl.GetNationFromFriendCountryUrl());
        }

        public AreaTag GetAreaTagForCountry(Nation nation)
        {
            return new AreaTagDA().GetCountrysAreaTag(nation);
        }

        public List<AreaTag> GetAllAreaTagsInCountry(Nation nation)
        {
            return (from c in CFDataCache.AllAreaTags where c.CountryID == (short)nation orderby c.Name select c).ToList();
        }

        public AreaTag GetAreaTagByCountryUrlAndName(string countryUrl, string friendlyUrlName)
        {
            Nation nation = countryUrl.GetNationFromFriendCountryUrl();
            return new AreaTagDA().GetAreaTagByFriendlyUrlName(nation, friendlyUrlName);
        }


        public Dictionary<AreaTag, int> GetAreaNamesAndPlaceCount(bool IsForIndoor)
        {
            List<AreaTag> areas = CFDataCache.AllAreaTags;

            if (IsForIndoor)
            {
                return (from c in areas orderby c.Name select c).ToDictionary(a => a, a => new IndoorPlaceDA().GetPlacesInArea(a.ID).Count);
            }
            else
            {
                return (from c in areas orderby c.Name select c).ToDictionary(a => a, a => new OutdoorPlaceDA().GetPlacesInArea(a.ID).Count);
            }
        }


        
        

        public Dictionary<AreaTag, int> GetAreaNamesAndPlaceCount(Nation nation, bool IsForIndoor)
        {
            List<AreaTag> areas = CFDataCache.AllAreaTags;

            if (IsForIndoor)
            {
                return (from c in areas where c.CountryID == (short)nation orderby c.Name select c).ToDictionary(a => a, a => new IndoorPlaceDA().GetPlacesInArea(a.ID).Count);
            }
            else
            {
                return (from c in areas where c.CountryID == (short)nation orderby c.Name select c).ToDictionary(a => a, a => new OutdoorPlaceDA().GetPlacesInArea(a.ID).Count);
            }
        }

        public Dictionary<AreaTag, int> GetAreaNamesAndClubCount()
        {
            return (from c in CFDataCache.AllAreaTags orderby c.Name select c).ToDictionary(a => a, a => new ClubDA().GetClubsInArea(a.ID).Count);
        }


        public List<OutdoorCrag> GetCragsAtPlace(int placeID)
        {
            return new OutdoorCragDA().GetCragsAtPlace(placeID);
        }

        public OutdoorCrag UpdateOutdoorCrag(OutdoorCrag crag)
        {
            return new OutdoorCragDA().Update(crag);
        }
        


        public void AddPlaceAreaTag(int placeID, int areaTagID)
        {
            List<AreaTag> tagsForPlace = GetAreaTagsForAPlace(placeID);
            foreach (AreaTag t in tagsForPlace) { if (t.ID == areaTagID) { return; } } //Stop adding more than one tag error
            
            new PlaceDA().InsertPlaceArea(placeID, areaTagID);
        }

        public void DeletePlaceAreaTag(int placeID, int areaTagID)
        {
            new PlaceDA().DeletePlaceArea(placeID, areaTagID);
        }


        public List<Place> SearchPlaces(string name)
        {
            return new PlaceDA().Search(name);
        }


        public List<AreaTag> SearchAreas(string name)
        {
            return new AreaTagDA().Search(name);
        }   
    }
}
