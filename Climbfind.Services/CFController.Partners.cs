using System;
using System.Linq;
using System.Collections.Generic;
using ClimbFind.Mail;
using ClimbFind.Helpers;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects;
using ClimbFind.Model.Enum;
using System.Threading;
using ClimbFind.Exceptions;

namespace ClimbFind.Controller
{
    public partial class CFController
    {
        public PartnerCallDA pcDA { get { return new PartnerCallDA(); } }
        public PartnerCallSubscriptionDA pcsDA { get { return new PartnerCallSubscriptionDA(); } }


        

        /// <summary>
        /// Getters
        /// </summary>        

        private List<PartnerCall> FilterOutUserDeleted(List<PartnerCall> list)
        {
            return (from c in list where !c.Deleted select c).ToList();
        }


        public List<PartnerCall> GetAllPartnerCalls()
        {
            return FilterOutUserDeleted(pcDA.GetAll()); //-- Used for places with calls page
        }

        public PartnerCall GetPartnerCall(Guid id)
        {
            return pcDA.GetFullPartnerCallDetails(id);
        }

        public List<PartnerCall> GetUsersPartnerCalls(Guid userID)
        {
            return FilterOutUserDeleted(pcDA.GetUsersPartnerCalls(userID));
        }

        public List<FeedPartnerCallPost> GetUsersPartnerCallFeedPost(Guid userID, int count)
        {
            return (from c in GetUsersPartnerCalls(userID) select new FeedPartnerCallPost { Call = c }).Take(count).ToList();
        }

        public List<FeedPartnerCallPost> GetPlacesPartnerCallFeedPost(int placeID, int count)
        {
            return (from c in GetPartnerCallsForPlace(placeID) select new FeedPartnerCallPost { Call = c }).Take(count).ToList();
        }

        public List<FeedPartnerCallPost> GetLatestPartnerCalls(int count)
        {
            return (from c in pcDA.GetLatestPartnerCalls(count, PartnerCallPlaceType.Both) select new FeedPartnerCallPost { Call = c }).ToList();
        }
        

        public List<PartnerCall> GetPartnerCallsForPlace(int placeID)
        {
            return FilterOutUserDeleted(pcDA.GetPartnerCallsForPlace(placeID).GetDistinctUserCalls());
        }

        public List<PartnerCall> GetPartnerCallsForArea(int areaTagID, int number, bool? indoorOnly)
        {
            return FilterOutUserDeleted(pcDA.GetPartnerCallsForAreaTag(areaTagID, number, indoorOnly));
        }

        public List<PartnerCall> GetPartnerCallsForPlaceCombo(List<int> placeIDs, int number)
        {
            return FilterOutUserDeleted(pcDA.GetPartnerCallsForPlaceCombo(placeIDs, number));
        }       
       
        public List<int> GetPlaceIDsWithCalls()
        {
            return pcDA.GetPlaceIDsWithCalls();
        }

        public PartnerCallReply GetPartnerCallReply(Guid id)
        {
            return new PartnerCallReplyDA().GetByID(id);
        }

        public List<PartnerCallReply> GetUserPartnerCallReplies(Guid userID)
        {
            return new PartnerCallReplyDA().GetUserPartnerCallReplies(userID);
        }

        public List<UserMessage> GetUserPartnerCallRepliesAsMessages(Guid userID)
        {
            return new PartnerCallReplyDA().GetUserPartnerCallRepliesAsMessages(userID);
        } 

        public List<UserMessage> GetRepliesToUsersPartnerCalls(Guid userID)
        {
            return new PartnerCallReplyDA().GetRepliesToUsersPartnerCalls(userID);
        }
  

        /// <summary>
        /// Setters
        /// </summary>

        public PartnerCall CreatePartnerCall(PartnerCall call)
        {
            call.ID = Guid.NewGuid();
            call.PostedDateTime = DateTime.Now;
            if (call.IsIndoor) { call.ToTrad = false; call.ToAlpine = false; }

            //-- Check call has places
            if (call.PlaceIDs.Count == 0) { throw new Exception("Cannot post a partner call without any places"); }
            
            //-- Check user does not have an existing same parnter call
            List<PartnerCall> usersCalls = GetUsersPartnerCalls(call.CreatorUserID);
            foreach (PartnerCall c in usersCalls) { if (call.HasSamePlaces(c)) { throw new UserPartnerCallWithSamePlacesExistsException("Duplicate calls for the same places."); } }
            
            pcDA.Insert(call);
            foreach (int placeID in call.PlaceIDs) { pcDA.InsertPlaceUserWantToClimbsAt(call.ID, placeID); }

            //Thread sendEmailsThread = new Thread(SendPartnerCallNotificatioonEmails);
            //-- TODO IMPORTANT START THIS ON A NEW THREAD
            //sendEmailsThread.Start(placeIDs, call);
            SendPartnerCallNotificationEmails(call, call.PlaceIDs);

            CFLogger.RecordPartnerCallCreate(call.CreatorUserID, call.PlaceIDs); 

            return call;
        }


        private void SendPartnerCallNotificationEmails(PartnerCall call, List<int> placeIDs)
        {
            Dictionary<ClimberProfile, int> usersSubscribedToAtLeastOnePlace 
                = new ClimberProfileDA().GetPartnerCallEmailSubscribedUsers(placeIDs);

            foreach (ClimberProfile cp in usersSubscribedToAtLeastOnePlace.Keys)
            {
                if (cp.Email != User.Name)
                {
                    Place place = CFDataCache.GetPlace(usersSubscribedToAtLeastOnePlace[cp]);
                    MailMan.SendPartnerCallNotificationEmail(cp, call, place.Name, call.PlacesNamesString, cp.Email);
                }
            }
        }


        public int GetSubscriptionCountForPlace(int placeID)
        {
            return new ClimberProfileDA().GetPartnerCallEmailSubscribedUsers(new List<int> { placeID }).Count;
        }

        public void DeletePartnerCallByUserAndSaveSurvery(PartnerCall call, string reason, int numberWhoContacted)
        {
            call.Deleted = true;
            CFLogger.RecordPartnerCallDelete(call.CreatorUserID, call.ID, reason, numberWhoContacted);

            new PartnerCallDA().DeleteByUserAndSaveSurvey(call, reason, numberWhoContacted);
        }


        public void ReplyToPartnerCall(Guid partnerCallID, Guid replyingUserID, string message)
        {
            PartnerCall call = new PartnerCallDA().GetByID(partnerCallID);

            if (call.CreatorUserID == replyingUserID) { throw new Exception(string.Format("You cannot reply to your own partner call. call[{0}]", call.ID)); }
            
            PartnerCallReply reply = new PartnerCallReplyDA().Insert( new PartnerCallReply
            {
                ID = Guid.NewGuid(),
                ReplyDateTime = DateTime.Now,
                ReplyingUserID = replyingUserID,
                PartnerCallID = partnerCallID,
                Message = message
            }); 

            ClimberProfile poster = CFDataCache.GetClimberFromCache(call.ClimberProfileID);
            ClimberProfile replyer = CFDataCache.GetClimberFromCache(replyingUserID);

            MailMan.SendReplyToPartnerCall(call, reply, replyer, replyer.Email, poster.Email);

            CFLogger.RecordPartnerCallReply(replyingUserID, partnerCallID);
        }



        public PartnerCallSubscription GetPartnerCallSubscription(Guid userID, int placeID)
        {
            return pcsDA.Get(userID, placeID);
        }

        public List<PartnerCallSubscription> GetUsersPartnerCallSubscriptions(Guid userID)
        {
            return pcsDA.GetUsersPartnerCallSubscriptions(userID);
        }
        


        public void SubscribeToPartnerCallsByEmail(Guid userID, int placeID)
        {
            PartnerCallSubscription subscription = pcsDA.Get(userID, placeID);
            subscription.Email = true;
            pcsDA.Update(subscription);
            CFLogger.RecordPartnerCallEmailSubscription(userID, placeID, "SubscribeToPartnerCallsByEmail");
        }

        public void UnSubscribeToPartnerCallsByEmail(Guid userID, int placeID)
        {
            PartnerCallSubscription subscription = pcsDA.Get(userID, placeID);
            subscription.Email = false;
            pcsDA.Update(subscription);
            CFLogger.RecordPartnerCallUnSubscribe(userID, placeID, "UnSubscribeToPartnerCallsByEmail");
        }

        public void SubscribeToPartnerCallsByRSS(Guid userID, int placeID)
        {
            PartnerCallSubscription subscription = pcsDA.Get(userID, placeID);
            subscription.RSS = true;
            pcsDA.Update(subscription);
            CFLogger.RecordPartnerCallRSSSubscription(userID, placeID, "SubscribeToPartnerCallsByRSS");
        }

        public void UnSubscribeToPartnerCallsByRSS(Guid userID, int placeID)
        {
            PartnerCallSubscription subscription = pcsDA.Get(userID, placeID);
            subscription.RSS = false;
            pcsDA.Update(subscription);
            CFLogger.RecordPartnerCallUnSubscribe(userID, placeID, "UnSubscribeToPartnerCallsByRSS");
        }



        /// <summary>
        /// DEPRECATED METHODS TO REMOVE
        /// </summary>

        public List<PartnerCall> GetLatestIndoorPartnerCallsForHomepage()
        {
            return new PartnerCallDA().GetLatestIndoorPartnerCalls(25, null);
        }

        public List<PartnerCall> GetLatestOutdoorPartnerCallsForHomepage()
        {
            return new PartnerCallDA().GetLatestOutdoorPartnerCalls(25, null);
        }

        public List<PartnerCall> GetLatestIndoorPartnerCallsForHomepage(List<short> countries)
        {
            return new PartnerCallDA().GetLatestIndoorPartnerCalls(25, countries);
        }

        public List<PartnerCall> GetLatestOutdoorPartnerCallsForHomepage(List<short> countries)
        {
            return new PartnerCallDA().GetLatestOutdoorPartnerCalls(25, countries);
        }

    }
}
