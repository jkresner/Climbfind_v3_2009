using System;
using System.Collections.Generic;
using System.Web;
using ClimbFind.Helpers;
using ClimbFind.Mail;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Enum;
using ClimbFind.Model.Objects;

namespace ClimbFind.Controller
{
    public static class CFLogger
    {
        public static string UsersEmail { get { return HttpContext.Current.User.Identity.Name; } }
        private static List<string> ModeratorsToRecieveCragNotifications = new List<string>(),
            ModeratorsToRecievePlaceNotifications = new List<string>(),
            AdminsToRecieveRegistrationNotifications = new List<string>();

        private static LogEventDA da { get; set; }
        private static LogExceptionEventDA exDA { get; set; }

        static CFLogger()   
        {
            da = new LogEventDA();
            exDA = new LogExceptionEventDA();

            AdminsToRecieveRegistrationNotifications.Add("jkresner@yahoo.com.au");
            
            ModeratorsToRecievePlaceNotifications.Add("jkresner@yahoo.com.au");
        }



        public static void Delete(int id)
        {
            da.Delete(id);        
        }

        public static void DeleteException(int id)
        {
            exDA.Delete(id);
        }
      
        public static void Archive(int id)
        {
            LogEvent logEvent = da.GetByID(id);
            logEvent.Archived = true;
            da.Update(logEvent);
        }

        public static void ArchiveException(int id)
        {
            LogExceptionEvent logEvent = exDA.GetByID(id);
            logEvent.Archived = true;
            exDA.Update(logEvent);
        }


        

        public static void RecordPageView(Guid userID, string pageName)
        {
            string message = String.Format("{0} viewed {1}", UsersEmail, pageName);
            LogEvent logEvent = new LogEvent(userID, CFLogEventType.PageView, message);
            da.Insert(logEvent);
        }


        public static void RecordRegistration(Guid userID, string emailAddress)
        {
            string message = string.Format("{0} registered, profile at http://cf3.climbfind.com/climber-profile/{1}", emailAddress, userID);
            da.Insert(new LogEvent(userID, CFLogEventType.Registration, message));
            foreach (string email in AdminsToRecieveRegistrationNotifications)
            {
                MailMan.SendAppEventEmail(CFLogEventType.Registration, message, emailAddress, userID, email);
            }
        }

        public static void RecordRegistrationOnJoinPage(Guid userID, string emailAddress, string fullName)
        {
            string message = string.Format("{0} {1} registered on join page profile at http://cf3.climbfind.com/climber-profile/{2}", 
                fullName, emailAddress, userID);
            da.Insert(new LogEvent(userID, CFLogEventType.Registration, message));

            foreach (string email in AdminsToRecieveRegistrationNotifications)
            {
                MailMan.SendAppEventEmail(CFLogEventType.Registration, message, emailAddress, userID, email);
            }
        }

        public static void RecordDeleteAccount(Guid userID, string fullName, string emailAddress)
        {
            string message = string.Format("{0}[{1}] deleted their account", fullName, emailAddress, userID);
            da.Insert(new LogEvent(userID, CFLogEventType.DeleteAccount, message));
            foreach (string email in AdminsToRecieveRegistrationNotifications)
            {
                MailMan.SendAppEventEmail(CFLogEventType.DeleteAccount, message, emailAddress, userID, email);
            }
        }

        public static void RecordSignIn(Guid userID, string emailAddress)
        {
            string message = emailAddress + " signed in";
            da.Insert(new LogEvent(userID, CFLogEventType.SignIn, message));
        }

        public static void RecordPartnerCallCreate(Guid userID, List<int> placeIDs)
        {
            string placesString = "";
            foreach (int placeID in placeIDs) { placesString += string.Format("{0}", placeID); }

            string messsage = String.Format("{0} posted partnerCall for place[{1}]", UsersEmail, placesString);
            da.Insert(new LogEvent(userID, CFLogEventType.PartnerCallCreate, messsage));
        }


        public static void RecordPartnerCallEmailSubscription(Guid userID, int placeID, string action)
        {
            string messsage = String.Format("{0},{1} partnerCalls for place[{2}]", UsersEmail, action, placeID);
            da.Insert(new LogEvent(userID, CFLogEventType.PartnerCallEmailSubscribe, messsage));
        }

        public static void RecordPartnerCallRSSSubscription(Guid userID, int placeID, string action)
        {
            string messsage = String.Format("{0},{1} partnerCalls for place[{2}]", UsersEmail, action, placeID);
            da.Insert(new LogEvent(userID, CFLogEventType.PartnerCallRSSSubscribe, messsage));
        }

        public static void RecordPartnerCallUnSubscribe(Guid userID, int placeID, string action)
        {
            string messsage = String.Format("{0},{1} partnerCalls for place[{2}]", UsersEmail, action, placeID);
            da.Insert(new LogEvent(userID, CFLogEventType.PartnerCallUnsubscribe, messsage));
        }

        public static void RecordClubMeetCreate(Guid userID, Guid clubID, List<int> placeIDs, DateTime meetUpDateTime)
        {
            string placesString = "";
            foreach (int placeID in placeIDs) { placesString += string.Format("{0}", placeID); }

            string messsage = String.Format("{0} posted club meet for club[{1}] place[{2}] @ {3}", UsersEmail, clubID, placesString, meetUpDateTime);
            da.Insert(new LogEvent(userID, CFLogEventType.PartnerCallCreate, messsage));
        }

        public static void RecordPartnerCallReply(Guid userID, Guid partnerCallID)
        {
            string message = String.Format("{0} replied to partnerCall[{1}]", 
                        UsersEmail, partnerCallID);

            da.Insert(new LogEvent(userID, CFLogEventType.PartnerCallReply, message));
        }

        public static void RecordPartnerCallDelete(Guid userID, Guid partnerCallID, string reason, int numberOfPeople)
        {
            string message = String.Format("{0} deleted partnerCall[{1}] beacuse {2}, had [{3}] replies", UsersEmail, partnerCallID, reason, numberOfPeople);
            da.Insert(new LogEvent(userID, CFLogEventType.PartnerCallDelete, message));
            MailMan.SendAppEventEmail(CFLogEventType.PartnerCallDelete, message, UsersEmail, userID, "jkresner@yahoo.com.au");
        }


        public static void RecordGroupPageView(Guid userID, string groupName, Guid groupID)
        {
            string messsage = String.Format("{0} viewed group {1}[2]", UsersEmail, groupName, groupID);
            da.Insert(new LogEvent(userID, CFLogEventType.GroupPageView, messsage));
        }


        public static void RecordClubCreate(Guid userID, string clubName, int clubID)
        {
            string messsage = String.Format("{0} created club {1}[2]", UsersEmail, clubName, clubID);
            da.Insert(new LogEvent(userID, CFLogEventType.ClubCreate, messsage));
        }

        public static void RecordClubJoin(Guid userID, string clubName, int clubID)
        {
            string messsage = String.Format("{0} self joined club {1}[2]", UsersEmail, clubName, clubID);
            da.Insert(new LogEvent(userID, CFLogEventType.ClubJoin, messsage));
        }

        public static void RecordClubLeave(Guid userID, string clubName, int clubID)
        {
            string messsage = String.Format("{0} left club {1}[2]", UsersEmail, clubName, clubID);
            da.Insert(new LogEvent(userID, CFLogEventType.ClubLeave, messsage));
        }
        


        public static void RecordModerateEdit(Guid userID, string action)
        {
            string messsage = String.Format("{0} {1}", UsersEmail, action);
            da.Insert(new LogEvent(userID, CFLogEventType.ModerateEdit, messsage));
        }

        public static void RecordModerateAddPlace(Guid userID, string placeName, int countryID, string placeUrl)
        {
            string message = string.Format("Added place {1}[c{2}] <a href='http://cf3.climbfind.com{3}'>http://cf3.climbfind.com{3}</a>", UsersEmail, placeName, countryID, placeUrl);
            da.Insert(new LogEvent(userID, CFLogEventType.ModerateAddPlace, message));

            foreach (string email in ModeratorsToRecievePlaceNotifications)
            {
                MailMan.SendAppEventEmail(CFLogEventType.ModerateAddPlace, message, UsersEmail, userID, email);
            }         
        }

        public static void RecordModerateDeletePlace(Guid userID, string placeName, int countryID, string placeUrl)
        {
            string message = string.Format("Deleted place {1}[c{2}] <a href='http://cf3.climbfind.com{3}'>http://cf3.climbfind.com{3}</a>", UsersEmail, placeName, countryID, placeUrl);
            da.Insert(new LogEvent(userID, CFLogEventType.ModerateDeletePlace, message));

            foreach (string email in ModeratorsToRecievePlaceNotifications)
            {
                MailMan.SendAppEventEmail(CFLogEventType.ModerateDeletePlace, message, UsersEmail, userID, email);
            }
        }

        public static void RecordModerateAddCrag(Guid userID, string cragName, int countryID, string cragUrl)
        {
            string message = string.Format("Added crag {1}[c{2}] <a href='http://cf3.climbfind.com{3}'>http://cf3.climbfind.com{3}</a>", UsersEmail, cragName, countryID, cragUrl);
            da.Insert(new LogEvent(userID, CFLogEventType.ModerateAddCrag, message));

            foreach (string email in ModeratorsToRecieveCragNotifications)
            {
                MailMan.SendAppEventEmail(CFLogEventType.ModerateAddCrag, message, UsersEmail, userID, email);
            } 
        }

        public static void RecordModerateDeleteCrag(Guid userID, string cragName, string cragUrl)
        {
            string message = string.Format("Deleted crag {1} <a href='http://cf3.climbfind.com{2}'>http://cf3.climbfind.com{2}</a>", UsersEmail, cragName, cragUrl);
            da.Insert(new LogEvent(userID, CFLogEventType.ModerateDeleteCrag, message));

            foreach (string email in ModeratorsToRecieveCragNotifications)
            {
                MailMan.SendAppEventEmail(CFLogEventType.ModerateDeleteCrag, message, UsersEmail, userID, email);
            }
        }

        public static void RecordModerateAddAreaTag(Guid userID, string areaName, int countryID)
        {
            string message = string.Format("{0} added area tag {1}[c{2}]", UsersEmail, areaName, countryID);
            da.Insert(new LogEvent(userID, CFLogEventType.ModerateAddAreaTag, message));
        }

        public static void RecordModerateEditAreaTag(Guid userID, string areaName, int countryID)
        {
            string message = string.Format("{0} edited area tag {1}[c{2}]", UsersEmail, areaName, countryID);
            da.Insert(new LogEvent(userID, CFLogEventType.ModerateEditAreaTag, message));
        }

        public static void RecordBooktopiaAdClick(Guid userID, string bookname, string isbn)
        {
            string messsage = String.Format("{0} click book ad {1}[{2}]", UsersEmail, bookname, isbn);
            da.Insert(new LogEvent(userID, CFLogEventType.AdClickBooktopia, messsage));
        }

        /// <summary>
        /// 
        /// </summary>
        public static List<LogEvent> GetAll()
        {
            return da.GetAll();
        }

        public static List<LogEvent> GetLast10000()
        {
            return da.GetLastN(10000);
        }

        //public static List<LogEvent> GetFirst2500()
        //{
        //    return da.GetFirst2500();
        //}

        

        /// <summary>
        /// 
        /// </summary>
        public static LogEvent GetByID(int id)
        {
            return da.GetByID(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<LogExceptionEvent> GetAllExceptions()
        {
            return exDA.GetAll();
        }

        public static List<LogExceptionEvent> GetLast30Exceptions()
        {
            return exDA.GetLastNExceptions(30);
        }

        /// <summary>
        /// 
        /// </summary>
        public static List<Feedback> GetAllFeedback()
        {
            return new FeedbackDA().GetAll();
        }

        /// <summary>
        /// 
        /// </summary>
        public static List<Feedback> GetPublishedFeedback()
        {
            List<Feedback> feedback = new FeedbackDA().GetAllPublishedFeedback();
            feedback.Reverse();
            return feedback;
        }


        public static void SaveFeedback(Guid userID, string comment)
        {
            ClimberProfile climberProfile = new ClimberProfileDA().GetByID(userID);
            
            new FeedbackDA().Insert(new Feedback
            {
                DateTimePosted = DateTime.Now,
                UserID = userID,
                FeedbackFromUser = comment,
                ResponseFromAdmin = ""
            });

            MailMan.SendFeedbackAlertEmail(climberProfile.Email, climberProfile.FullName, comment);
        }

        public static void SaveFeedbackReview(int feedbackID, bool published, string reviewComment)
        {
            FeedbackDA da = new FeedbackDA();
            
            Feedback feedback = da.GetByID(feedbackID);
            
            if (!feedback.DateTimeFirstReplied.HasValue)
            {
                feedback.DateTimeFirstReplied = DateTime.Now;
            }
            feedback.DateTimeLastReviewed = DateTime.Now;
            feedback.ResponseFromAdmin = reviewComment;
            feedback.Published = published;

            da.Update(feedback);
        }

        /// <summary>
        /// 
        /// </summary>
        public static List<LogEvent> Get(Guid userID, CFLogEventType eventType)
        {
            return da.Get(userID, eventType);
        }

        public static void RecordException(Exception ex, string extraMSGContext)
        {
            Guid userID = new Guid();
            string email = "anonymous";

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                email = HttpContext.Current.User.Identity.Name;            
                userID = new CFController().GetClimberProfileByEmail(email).ID;
            }

            MailMan.SendAppExceptionEmail(ex, email);

            LogExceptionEvent exceptionEvent = exDA.Insert(
                new LogExceptionEvent
                {
                    Browser = HttpContext.Current.Request.Browser.Browser.ToString() + " v" + HttpContext.Current.Request.Browser.Version.ToString(),
                    ExceptionDateTime = DateTime.Now,
                    InnerMessage = extraMSGContext + ", " + ex.Message,
                    IP = HttpContext.Current.Request.UserHostName.Take(15), //Try see if the length of this field is causing the truncated exception
                    Url = HttpContext.Current.Request.Url.ToString(),
                    UserEmail = email,
                    Reviewed = false,
                    UserID = userID,
                    StackTrace = ex.StackTrace.ToString()
                });

            string messsage = String.Format("{0} experienced exception[{1}]: {2}", UsersEmail, exceptionEvent.ID, ex.Message).Take(254);
            da.Insert(new LogEvent(userID, CFLogEventType.Exception, messsage.Take(254)));

        }

        public static void RecordException(Exception ex)
        {
            RecordException(ex, "");
        }
    }
}
