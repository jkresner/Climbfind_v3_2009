using System;
using ClimbFind.Content;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Enum;
using ClimbFind.Model.Objects;
using ClimbFind.Helpers;

namespace ClimbFind.Controller
{
    public partial class CFController
    {
        public AreaTag AddAreaTag(AreaTag tag)
        {           
            //-- Send app notification email
            CFLogger.RecordModerateAddAreaTag(CurrentClimber.ID, tag.Name, tag.CountryID);

            AreaTag newTag = new AreaTagDA().Insert(tag);

            CFDataCache.CacheAllAreaTags();

            return newTag;
        }

        public AreaTag UpdateAreaTag(AreaTag tag)
        {
            //-- Send app notification email
            CFLogger.RecordModerateEditAreaTag(CurrentClimber.ID, tag.Name, tag.CountryID);
            
            AreaTag newTag = new AreaTagDA().Update(tag);

            CFDataCache.CacheAllAreaTags();

            return newTag;
        }

        public Place AddOutdoorPlace(Place outdoorPlace)
        {
            outdoorPlace.MessageBoardID = InsertNewMessageBoard();
            outdoorPlace.FriendlyUrlName = outdoorPlace.Name.GetFriendlyUrlName();
            PlaceDA placeDA = new PlaceDA();
            Place place = placeDA.Insert(outdoorPlace);
            OutdoorPlaceDA outdoorPlaceDA = new OutdoorPlaceDA();

            outdoorPlaceDA.Insert(new OutdoorPlace { ID = place.ID, DescriptionImageFile = "default.jpg" });

            AddPlaceAreaTag(place.ID, GetAreaTagForCountry((Nation)place.CountryID).ID);

            //-- Send app notification email
            CFLogger.RecordModerateAddPlace(CurrentClimber.ID, outdoorPlace.Name, outdoorPlace.CountryID, outdoorPlace.ClimbfindUrl);

            //-- Refresh the cache
            CFDataCache.CacheAllPlaces();
            //-- Not sure why outdoor places isn't cached?

            return place;
        }


        public Place AddIndoorPlace(Place indoorPlace, string address, string contactNumber, string website, 
            bool hasBoulder, bool hasLead, bool hasTopRope)
        {
            indoorPlace.MessageBoardID = InsertNewMessageBoard();
            indoorPlace.FriendlyUrlName = indoorPlace.Name.GetFriendlyUrlName();

            PlaceDA placeDA = new PlaceDA();

            Place place = placeDA.Insert(indoorPlace);

            IndoorPlaceDA indoorPlaceDA = new IndoorPlaceDA();

            indoorPlaceDA.Insert(new IndoorPlace { ID = place.ID, Address = address, MapAddress = address, Contact = contactNumber, 
             HasBoulder = hasBoulder, HasLead = hasLead, HasTopRope = hasTopRope, LogoImageFile = "Default.jpg", Latitude=0, Longitude=0, Website = website });

            AddPlaceAreaTag(place.ID, GetAreaTagForCountry((Nation)place.CountryID).ID);

            //-- Send app notification email
            CFLogger.RecordModerateAddPlace(CurrentClimber.ID, indoorPlace.Name, indoorPlace.CountryID, indoorPlace.ClimbfindUrl);

            //-- Refresh the cache
            CFDataCache.CacheAllIndoorPlaces();

            return place;
        }

        public Place UpdatePlaceCoordinates(Place place)
        {
            //-- Send app notification email
            CFLogger.RecordModerateEdit(CurrentClimber.ID, string.Format("{0} updated {1}[c{2}] coordinates at {3}",
                CurrentClimber.Email, place.Name, place.CountryID, place.ClimbfindUrl));

            return new PlaceDA().Update(place);
        }

        public OutdoorPlace UpdateOutdoorPlace(OutdoorPlace outdoorPlace)
        {
            OutdoorPlaceDA outdoorPlaceDA = new OutdoorPlaceDA();
            outdoorPlace.DescriptionLastUpdated = DateTime.Now;
            outdoorPlace.DescriptionByUserID = CurrentClimber.ID;
            outdoorPlace.FriendlyUrlName = outdoorPlace.Name.GetFriendlyUrlName();

            outdoorPlaceDA.Update(outdoorPlace);

            PlaceDA placeDA = new PlaceDA();
            placeDA.Update(outdoorPlace);

            //-- Send app notification email
            CFLogger.RecordModerateEdit(CurrentClimber.ID, string.Format("{0} updated {1}[c{2}] details at {3}", 
                CurrentClimber.Email, outdoorPlace.Name, outdoorPlace.CountryID, outdoorPlace.ClimbfindUrl));

            return outdoorPlace;
        }

        public IndoorPlace UpdateIndoorPlace(IndoorPlace place)
        {
            IndoorPlaceDA indoorPlaceDA = new IndoorPlaceDA();
            place.FriendlyUrlName = place.Name.GetFriendlyUrlName();

            indoorPlaceDA.Update(place);

            PlaceDA placeDA = new PlaceDA();
            placeDA.Update(place);

            //-- Send app notification email
            CFLogger.RecordModerateEdit(CurrentClimber.ID, string.Format("{0} updated {1}[c{2}] details at {3}", 
                CurrentClimber.Email, place.Name, place.CountryID, place.ClimbfindUrl));

            return place;
        }


        public void SaveIndoorPlaceLogo(IndoorPlace place, string imageFileName, byte[] imageBytes)
        {
            place.LogoImageFile = ImageManager.SaveIndoorPlaceLogo(imageFileName, imageBytes, place.ID, place.FriendlyUrlName);
            new IndoorPlaceDA().Update(place);

            Place basePlace = new PlaceDA().GetByID(place.ID);
            basePlace.PrimaryImageFile = place.LogoImageFile;
            new PlaceDA().Update(basePlace);

            //-- Refresh the cache
            CFDataCache.CacheAllIndoorPlaces();
        }


        public void SaveClubLogo(Club club, string imageFileName, byte[] imageBytes)
        {
            club.LogoImageFile = ImageManager.SaveClubLogo(imageFileName, imageBytes, club.ID, club.FriendlyUrlName);
            new ClubDA().Update(club);
            CFDataCache.CacheAllClubs();
        }


        public void SaveOutdoorPlacePicture1(OutdoorPlace place, string imageFileName, byte[] imageBytes)
        {
            place.DescriptionImageFile = ImageManager.SaveOutdoorPlaceImage(imageFileName, imageBytes, place.ID, place.FriendlyUrlName);
            place.DescriptionImageFileByUserID = CurrentClimber.ID;
            SaveOutdoorPlacePicture(place);

            Place basePlace = new PlaceDA().GetByID(place.ID);
            basePlace.PrimaryImageFile = place.DescriptionImageFile;
            new PlaceDA().Update(basePlace);        
        }

        public void SaveOutdoorPlacePicture2(OutdoorPlace place, string imageFileName, byte[] imageBytes)
        {
            place.DescriptionImageFile2 = ImageManager.SaveOutdoorPlaceImage(imageFileName, imageBytes, place.ID, place.FriendlyUrlName);
            place.DescriptionImageFile2ByUserID = CurrentClimber.ID; 
            SaveOutdoorPlacePicture(place);
        }
        
        public void SaveOutdoorPlacePicture3(OutdoorPlace place, string imageFileName, byte[] imageBytes)
        {
            place.DescriptionImageFile3 = ImageManager.SaveOutdoorPlaceImage(imageFileName, imageBytes, place.ID, place.FriendlyUrlName);
            place.DescriptionImageFile3ByUserID = CurrentClimber.ID;
            SaveOutdoorPlacePicture(place); 
        }

        private void SaveOutdoorPlacePicture(OutdoorPlace place)
        {
            OutdoorPlaceDA da = new OutdoorPlaceDA();
            da.Update(place);
            CFLogger.RecordModerateEdit(CurrentClimber.ID, string.Format("Changed picture for outdoor place {0}[{1}]", place.Name, place.ID));
        }


        public OutdoorCrag AddOutdoorCrag(OutdoorCrag crag, OutdoorPlace place)
        {
            crag.MessageBoardID = InsertNewMessageBoard();
            crag.ID = Guid.NewGuid();

            OutdoorCragDA da = new OutdoorCragDA();

            OutdoorCrag newCrag = da.Insert(crag);

            //-- Send app notification email
            CFLogger.RecordModerateAddCrag(CurrentClimber.ID, newCrag.Name, place.CountryID, newCrag.ClimbfindUrl);

            return newCrag;
        }



        public void SaveOutdoorCragPicture1(OutdoorCrag crag, string imageFileName, byte[] imageBytes)
        {
            crag.DescriptionImageFile1 = ImageManager.SaveOutdoorCragImage(imageFileName, imageBytes, crag.ID, crag.FriendlyUrlName);
            crag.DescriptionImageFile1ByUserID = CurrentClimber.ID;
            SaveOutdoorCragPicture(crag);
        }

        public void SaveOutdoorCragPicture2(OutdoorCrag crag, string imageFileName, byte[] imageBytes)
        {
            crag.DescriptionImageFile2 = ImageManager.SaveOutdoorCragImage(imageFileName, imageBytes, crag.ID, crag.FriendlyUrlName);
            crag.DescriptionImageFile2ByUserID = CurrentClimber.ID;
            SaveOutdoorCragPicture(crag);
        }

        public void SaveOutdoorCragPicture3(OutdoorCrag crag, string imageFileName, byte[] imageBytes)
        {
            crag.DescriptionImageFile3 = ImageManager.SaveOutdoorCragImage(imageFileName, imageBytes, crag.ID, crag.FriendlyUrlName);
            crag.DescriptionImageFile3ByUserID = CurrentClimber.ID;
            SaveOutdoorCragPicture(crag);
        }

        private void SaveOutdoorCragPicture(OutdoorCrag crag)
        {
            OutdoorCragDA da = new OutdoorCragDA();
            da.Update(crag);
            CFLogger.RecordModerateEdit(CurrentClimber.ID, string.Format("Changed picture for outdoor crag {0}[{1}]", crag.Name, crag.ID));
        }


        public void DeleteOutdoorCragCompletely(Guid cragID)
        {
            OutdoorCrag crag = new OutdoorCragDA().GetByID(cragID);
            new OutdoorCragDA().Delete(cragID);
            CFLogger.RecordModerateDeleteCrag(CurrentClimber.ID, crag.Name, crag.ClimbfindUrl); 
        }
    }
}
