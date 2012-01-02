using System;
using System.Collections.Generic;
using ClimbFind.Content;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Enum;
using ClimbFind.Model.Objects.Interfaces;
using System.Linq;
using ClimbFind.Controller;


namespace ClimbFind.Model.Objects
{
    public class PartnerCall : ClimbFind.Model.LinqToSqlMapping.PartnerCall
    {
        public Guid CreatorUserID { get { return base.ClimberProfileID; } }
        public string CreatorFullName { get { return CFDataCache.GetClimberFromCache(CreatorUserID).FullName;} }
        public string CreatorProfilePictureFile { get { return CFDataCache.GetClimberFromCache(CreatorUserID).ProfilePictureFile;} }

        

        public List<int> PlaceIDs { get; set; }

        public string FirstPlaceFullQualifiedUrl
        {
            get
            {
                return string.Format("{0}{1}",
                    CFSettings.WebAddress.TrimEnd(new char[] { '/' })
                    , CFDataCache.GetPlaceProp<string>(p => p.ClimbfindUrl, PlaceIDs[0]));
            }
        }

        public string PlacesClimbfindUrls 
        {
            get
            {
                string htmlUrls = "";
                foreach (int placeID in PlaceIDs.Take(6))
                {
                    htmlUrls += string.Format("<a href='{0}' target='_blank'>{1}</a>, ",
                        CFDataCache.GetPlaceProp<string>(p=>p.ClimbfindUrl, placeID),
                        CFDataCache.GetPlaceProp<string>(p=>p.ShortName, placeID));
                }

                return htmlUrls.Substring(0, htmlUrls.Length - 2);
            }
        }

        public string PlacesNamesString
        {
            get
            {
                if (PlaceIDs.Count == 1) { return CFDataCache.GetPlaceProp<string>(p => p.ShortName, PlaceIDs[0]); }
                else
                {
                    string names = "";
                    int i = 0;
                    while (i < PlaceIDs.Count-1)
                    {
                        names += string.Format("{0}, ",
                            CFDataCache.GetPlaceProp<string>(p => p.ShortName, PlaceIDs[i]));
                        i++;
                    }
                    return names = names.Substring(0, names.Length - 2) +" & " + 
                            CFDataCache.GetPlaceProp<string>(p => p.ShortName, PlaceIDs[PlaceIDs.Count-1]);
                }
            }
        }

        public string FlagImageUrl
        {
            get
            {
                return CFDataCache.GetPlaceProp<string>(p => p.FlagImageUrl2, PlaceIDs[0]);
            }
        }

        public List<PartnerCallReply> Replies { get; set; }
        
        public string ProfilePictureFileUrl 
        {
            get
            {
                return ImageManager.GetThumnailUrl(CreatorUserID, CreatorProfilePictureFile, ImageType.CPinPS);
            }
        }

        public string ProfilePictureUrlFull 
        {
            get
            {
                return ImageManager.GetThumnailUrl(CreatorUserID, CreatorProfilePictureFile, ImageType.CP);
            }
        }


        
        public string GetClimbingTypesEnglsihString()
        {
            List<string> cTypesString = new List<string>();
            if (ToTopRope) { cTypesString.Add("top rope"); }
            if (ToLeadClimb) { cTypesString.Add("lead climb"); }
            if (ToBoulder) { cTypesString.Add("boulder"); }
            if (ToTrad) { cTypesString.Add("trad climb"); }
            if (ToAlpine) { cTypesString.Add("alpine climb"); }

            if (cTypesString.Count == 1) { return cTypesString[0]; }
            else if (cTypesString.Count > 1)
            {
                string s = cTypesString[0];
                for (int i = 1; i < cTypesString.Count; i++) { s += " or " + cTypesString[i]; }
                return s;
            }
            return "";
        }
    }

}
