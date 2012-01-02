using System;
using System.Collections.Generic;
using ClimbFind.Content;
using ClimbFind.Controller;
using ClimbFind.Model.Enum;


namespace ClimbFind.Model.Objects
{
    public class ClimberProfile : ClimbFind.Model.LinqToSqlMapping.ClimberProfile
    {
        public List<Place> PlacesUserClimbs { get; set; }  
        
        public string GradeLowerUK { get { return (ClimbingGradeLower.ToString()); } }
        public string GradeLowerUS { get { return (ClimbingGradeLower.ToString()); } }
        public string GradeLowerEU { get { return (ClimbingGradeLower.ToString()); } }

        public string Sex 
        { 
            get 
            {
                if (IsMale == true) { return "Male"; }
                if (IsMale == false) { return "Female"; }
                return "Unknown";
            } 
        }

        public string HisHerString
        {
            get
            {
                if (IsMale == true) { return "his"; }
                if (IsMale == false) { return "her"; }
                return "their";
            }
        }

        public string FlagImageUrl
        {
            get
            {
                return "~/images/ui/flags/" + FlagList.GetFlag((Nation)Nationality); 
            }
        }


        public string FlagImageUrl_Absolute
        {
            get
            {
                return CFSettings.WebAddress + "images/ui/flags/" + FlagList.GetFlag((Nation)Nationality);
            }
        }


        public string ProfilePictureUrl 
        { 
            get 
            { 
                return ImageManager.GetThumnailUrl(ID, ProfilePictureFile, ImageType.CPinPF);
            } 
        }

        public string ProfilePictureUrlFull
        {
            get
            {
                return ImageManager.GetThumnailUrl(ID, ProfilePictureFile, ImageType.CP);
            }
        }

        public string ProfilePictureUrlMini
        {
            get
            {
                return CFSettings.WebAddress.TrimEnd(new char[] { '/' }) + ImageManager.GetThumnailUrl(ID, ProfilePictureFile, ImageType.CPinMB);
            }
        }

        public string ContactNumber
        {
            get
            {
                if (String.IsNullOrEmpty(ContractPhoneNumber)) { return "Not supplied"; }
                else { return ContractPhoneNumber; }
            }
        }
    
        public string NationalityString
        {
            get
            {
                return FlagList.GetCountryName((Nation)Nationality);
            }
        }

        public bool IsUnfinished { get { return IsDefault || ImageNotUploaded; } }
        public bool IsDefault { get { return FullName == "Unknown" ;} }
        public bool ImageNotUploaded { get { return String.IsNullOrEmpty(ProfilePictureFile) || ProfilePictureFile == "Default.jpg"; } }
    }
}
