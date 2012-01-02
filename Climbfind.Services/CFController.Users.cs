using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Content;
using ClimbFind.Mail;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Enum;
using ClimbFind.Model.Objects;
using ClimbFind.Exceptions;
using System.Web.Security;
using ClimbFind.Model.Objects.Interfaces;


namespace ClimbFind.Controller
{
    public partial class CFController
    {       
        /// <summary>
        /// User stuff
        /// </summary>        
        
        public ClimberProfile GetClimberProfile(Guid userID)
        {
            ClimberProfileDA da = new ClimberProfileDA();

            ClimberProfile profile = da.GetByID(userID);
            if (profile != null) { return profile; }
            else 
            {
                MembershipUser u = Membership.GetUser(userID);
                if (u == null) { return null; }
                else
                {
                    return da.CreateDefaultClimberProfile(userID, User.Name, InsertNewMessageBoard());
                }
            }
        }


        public ClimberProfileExtended GetExtendedClimberProfile(Guid userID)
        {
            ClimberProfileExtendedDA da = new ClimberProfileExtendedDA();

            ClimberProfileExtended extendedProfile = da.GetByID(userID);
            if (extendedProfile != null) { return extendedProfile; }
            else
            {
                return da.Insert( new ClimberProfileExtended { ID = userID } );
            }
        }

        public ClimberProfileExtended UpdateExtendedClimberProfile(ClimberProfileExtended extendedProfile)
        {
            ClimberProfileExtendedDA da = new ClimberProfileExtendedDA();

            return da.Update(extendedProfile);
        }


        public List<ClimberProfileExtended> GetExtendedProfilesWithLike()
        {
            ClimberProfileExtendedDA da = new ClimberProfileExtendedDA();

            return da.GetExtendedProfilesWithLike();
        }

        public ClimberProfile CreateClimberProfile(Guid userID, string email, string fullName, string nickName, bool isMale,
            Nation nationality, string climbingLevel)
        {
            ClimberProfileDA da = new ClimberProfileDA();

            return da.Insert(new ClimberProfile
            {
                ID = userID,
                Email = email,
                FullName = fullName,
                NickName = nickName,
                IsMale = isMale,
                Nationality = (byte)nationality,
                ClimbingLevel = climbingLevel,
                ProfilePictureFile = "Default.jpg",
                MessageBoardID = InsertNewMessageBoard()
            });
        }

        public ClimberProfile GetClimberProfileByEmail(string email)
        {
            return new ClimberProfileDA().GetClimberProfile(email);        
        }


        /// <summary>
        /// 
        /// </summary>
        public List<ClimberProfile> GetClimbersThatClimbAtPlace(int placeID)
        {
            return new ClimberProfileDA().GetClimbersThatClimbAtPlace(placeID);
        }

        /// <summary>
        /// 
        /// </summary>
        public List<ClimberProfile> GetRandomSampleClimbersWithPics(List<ClimberProfile> allProfilesAtPlace, int number)
        {
            List<ClimberProfile> profilesWithPics = (from c in allProfilesAtPlace where !c.ImageNotUploaded select c).ToList();

            if (profilesWithPics.Count > number) { return profilesWithPics.RandomSample(number); }
            else { return allProfilesAtPlace.RandomSample(number); }
        }



        public void SaveClimberProfilePartnerStatus(ClimberProfile profile, byte partnerStatusID)
        {
            profile.PartnerStatusID = partnerStatusID;
            ClimberProfileDA da = new ClimberProfileDA();
            da.Update(profile);
        }

        public void SaveClimberProfile(ClimberProfile profile, string fullName, string nickName, bool isMale,
            Nation nationality, string climbingLevel, string contactPhoneNumber, bool showMessageBoard)
        {
            ClimberProfileDA da = new ClimberProfileDA();

            profile.FullName = fullName;
            profile.NickName = nickName;
            profile.IsMale = isMale;
            profile.Nationality = (byte)nationality;
            profile.ClimbingLevel = climbingLevel;
            profile.ContractPhoneNumber = contactPhoneNumber;
            profile.ClimbingGradeLower = 1;
            profile.ClimbingGradeUpper = 2;

            da.Update(profile);

            UpdateMessageBoardVisibility(profile.MessageBoardID, showMessageBoard);

            CFDataCache.FlushClimberFromCache(profile.ID);
        }

        public void SavePlaceUserClimbsAt(Guid userID, int newPlaceID)
        {
            List<int> listOfPlace = (from c in new CFController().GetPlacesUserClimbs(userID) select c.ID).ToList();

            if (!listOfPlace.Contains(newPlaceID))
            {
                listOfPlace.Add(newPlaceID);
                new CFController().SavePlacesUserClimbsAt(userID, listOfPlace);
            }
        }

        public void SavePlacesUserClimbsAt(Guid userID, List<int> newPlaceIDs)
        {
            List<int> previousPlaceIDs = new PlaceDA().GetPlacesUserClimbsAt(userID).Select(c => c.ID).ToList();

            ClimberProfileDA cpDA = new ClimberProfileDA();

            //-- Delete places user no longer climbs at
            foreach (int pid in previousPlaceIDs)
            {
                if (!newPlaceIDs.Contains(pid)) { cpDA.DeletePlaceUserClimbsAt(userID, pid); }
            }

            //-- Insert places user now climbs at that they didn't before
            foreach (int pid in newPlaceIDs)
            {
                if (!previousPlaceIDs.Contains(pid)) { cpDA.InsertPlaceUserClimbsAt(userID, pid); }
            }               
        }

        public void SaveClimberProfilePicture(ClimberProfile profile, string imageFileName, byte[] imageBytes)
        {
            ClimberProfileDA da = new ClimberProfileDA();
            
            string newImageName = ImageManager.SaveRawTypeImage(imageFileName, imageBytes, profile.ID, ImageType.CP);

            profile.ProfilePictureFile = newImageName;

            da.Update(profile);

            CFDataCache.FlushClimberFromCache(profile.ID);
        }


        public UserSettings GetUserSearchSettings(Guid userID)
        {
            UserSettingsDA da = new UserSettingsDA();
            UserSettings settings = da.GetByID(userID);
            if (settings != null) { return settings; }
            else { return da.Insert(new UserSettings { ID = userID, PartnerSearchPlaceID = 0, PartnerSearchArea = "England, London & South East" }); }
            //-- TODO: fix this 0 value above...
        }


        public UserSettings UpdateUserSettingsDefaultSearchPlace(Guid userID, int placeID)
        {
            UserSettingsDA da = new UserSettingsDA();
            UserSettings settings = da.GetByID(userID);
            settings.PartnerSearchPlaceID = placeID;
            return da.Update(settings);
        }

        public UserSettings UpdateUserSettingsDefaultSearchArea(Guid userID, string areaName)
        {
            UserSettingsDA da = new UserSettingsDA();
            UserSettings settings = da.GetByID(userID);
            settings.PartnerSearchArea = areaName;
            return da.Update(settings);
        }


        public UserSettings UpdateUserSettingsDefaultSearchCountry(Guid userID, short countryID)
        {
            UserSettingsDA da = new UserSettingsDA();
            UserSettings settings = da.GetByID(userID);
            settings.PartnerSearchCountryID = countryID;
            return da.Update(settings);
        }

        public UserSettings UpdateUserSettingsDefaultSearchPlaceType(Guid userID, PlaceType placeType)
        {
            UserSettingsDA da = new UserSettingsDA();
            UserSettings settings = da.GetByID(userID);
            settings.PartnerSearchPlaceType = placeType;
            return da.Update(settings);
        }

        public UserSettings UpdateUserHomePartnerCallCountries(Guid userID, HomePartnerCallCountries countires)
        {
            UserSettingsDA da = new UserSettingsDA();
            UserSettings settings = da.GetByID(userID);
            settings.HomePartnerCallCountries = (short)countires;
            return da.Update(settings);
        }


        public void SendMessage(ClimberProfile receiver, string subject, string message)
        {
            UserMessage msg = new UserMessageDA().Insert(
                new UserMessage
                {
                    ID = Guid.NewGuid(),
                    ReceivingUserID = receiver.ID,
                    SendingUserID = CurrentClimber.ID,
                    Subject = subject,
                    SentDateTime = DateTime.Now,
                    Message = message
                });

            MailMan.SendUserMessageEmail(CurrentClimber, receiver, subject, message, msg.ID);
        }

        public void SenderDeleteMessage(Guid id)
        {
            UserMessage message = new UserMessageDA().GetByID(id);

            if (message.SendingUserID != CurrentClimber.ID) { throw new Exception("You cannot delete a message that was not sent by you... messageID" + id.ToString()); }

            message.SenderDeleted = true;

            new UserMessageDA().Update(message);
        }


        public void ReceiverDeleteMessage(Guid id)
        {
            UserMessage message = new UserMessageDA().GetByID(id);

            if (message.ReceivingUserID != CurrentClimber.ID) { throw new Exception("You cannot delete a message that was not receieved by you... messageID" + id.ToString()); }

            message.ReceiverDeleted = true;

            new UserMessageDA().Update(message);
        }



        public UserMessage GetUserMessage(Guid id)
        {
            return new UserMessageDA().GetByID(id);
        }



        public List<UserMessage> GetUsersInboxMessages()
        {
            return new UserMessageDA().GetByUserID(CurrentClimber.ID);
        }

        public List<UserMessage> GetUsersSentMessages()
        {
            return new UserMessageDA().GetUsersSentMessages(CurrentClimber.ID);
        }
        

        public void SendMessageBoardNotification(Guid recievingUserID, string message)
        {
            if (CurrentClimber.ID != recievingUserID)
            {
                ClimberProfile receiver = GetClimberProfile(recievingUserID);
                
                MailMan.SendMessageboardNotificationEmail(CurrentClimber, receiver, message);
            }   
 
            //CFLogger.re
            //-- ToDO: consider logging message post.
        }


        public void DeleteMeCompletely(Guid userID, string fullName, string email)
        {
            if (CurrentClimber.ID != userID) { throw new Exception("You can only delete your own account"); }
            new ClimberProfileDA().DeleteUserCompletely(userID);
            CFLogger.RecordDeleteAccount(userID, fullName, email);

            CFDataCache.FlushClimberFromCache(userID);
        }


        public List<ClimberProfile> SearchClimberProfiles(string climbingLevel, bool? isMale, int placeID, byte partnerStatusID)
        {
            return new ClimberProfileDA().Search(climbingLevel, isMale, placeID, partnerStatusID);
        }


        public List<ClimberProfile> SearchClimberProfiles(string name)
        {
            return new ClimberProfileDA().Search(name);
        }


        /// <summary>
        /// User the users' messageboardID as theverification mechanism
        /// </summary>
        public void SendVerifyEmailAddressEmail(ClimberProfile cp)
        {
            cp.EmailVerificationSent = true;
            new ClimberProfileDA().Update(cp);
            MailMan.SendVerifyEmailAddressEmail(cp);
        }

        /// <summary>
        /// User the users' messageboardID as theverification mechanism
        /// </summary>
        public bool VerifyUsersEmailAddress(Guid userID, Guid messageBoardID)
        {
            ClimberProfile cp = new ClimberProfileDA().GetByID(userID);

            if (cp.MessageBoardID == messageBoardID)
            {
                cp.EmailVerified = true;
                new ClimberProfileDA().Update(cp);
                return true;
            }
            else
            {
                throw new UserEmailVerificationFailedException(string.Format("User[{0}] failed verification with code[{1}]", cp.Email, messageBoardID));
            }
        }


    }
}
