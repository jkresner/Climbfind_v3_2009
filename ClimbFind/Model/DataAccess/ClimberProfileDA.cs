using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web.Security;
using ClimbFind.Model.Enum;
using ClimbFind.Model.Objects;
using LinqToSql_ClimberProfile = ClimbFind.Model.LinqToSqlMapping.ClimberProfile;
using LinqToSql_PlaceUserClimb = ClimbFind.Model.LinqToSqlMapping.PlaceUserClimb;
using Linq_PCS = ClimbFind.Model.LinqToSqlMapping.PartnerCallSubscription;


namespace ClimbFind.Model.DataAccess
{
    public class ClimberProfileDA : AbstractBaseDA<ClimberProfile, LinqToSql_ClimberProfile, Guid>
    {
        public ClimberProfileDA() : base() { }
        public ClimberProfileDA(IDATransactionContext transactionContext) : base(transactionContext) { }

        /// <summary>
        ///
        /// </summary>
        protected override ClimberProfile MapLinqTypeToOOType(LinqToSql_ClimberProfile o)
        {
            ClimberProfile o2 = new ClimberProfile();
            MapValues(o2, o.GetProperyNameAndValues());

            return (o2);
        }

        /// <summary>
        /// Altername get method to retrieve a profile by user's email instead of Guid UserID
        /// </summary>
        public ClimberProfile GetClimberProfile(string email)
        {
            return MapType((from c in ctx.ClimberProfiles where c.Email == email select c).SingleOrDefault());
        }


        /// <summary>
        /// 
        /// </summary>
        public List<ClimberProfile> GetClimbersThatClimbAtPlace(int placeID)
        {
            return MapList((from puc in ctx.PlaceUserClimbs
                            from cp in EntityTable
                            where puc.PlaceID == placeID
                            && cp.ID == puc.UserID
                            select cp).ToList());
        }


        /// <summary>
        /// 
        /// </summary>
        public void DeletePlaceUserClimbsAt(Guid userID, int placeID)
        {
             ctx.PlaceUserClimbs.DeleteOnSubmit((
                            from c in ctx.PlaceUserClimbs where c.PlaceID == placeID
                            && c.UserID == userID select c).SingleOrDefault());

             CommitChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        public void InsertPlaceUserClimbsAt(Guid userID, int placeID)
        {
            ctx.PlaceUserClimbs.InsertOnSubmit(new LinqToSql_PlaceUserClimb { UserID = userID, PlaceID = placeID } );

            CommitChanges();
        }
      

        /// <summary>
        /// Creates a default profile
        /// </summary>
        public ClimberProfile CreateDefaultClimberProfile(Guid userID, string email, Guid messageBoardID)
        {
            return Insert(new LinqToSql_ClimberProfile
            {
                ID = userID,
                Email = email,
                FullName = "Unknown",
                NickName = "Unknown",
                ClimbingLevel = "Unknown",
                ProfilePictureFile = "Default.jpg",
                Nationality = (byte)Nation.Unknown,
                MessageBoardID = messageBoardID
            });
        }


        public List<ClimberProfile> GetClubMembers(int clubID)
        {
            return MapList((from uic in ctx.UserInClubs
                    from cp in ctx.ClimberProfiles
                    where uic.ClubID == clubID && uic.UserID == cp.ID
                    select cp).ToList());
        }


        public Dictionary<ClimberProfile, int> GetPartnerCallEmailSubscribedUsers(List<int> placeIDs)
        {
            var query = from pcs in ctx.PartnerCallSubscriptions from cp in ctx.ClimberProfiles
                         where placeIDs.Contains(pcs.PlaceID) && pcs.Email == true && pcs.UserID == cp.ID
                         select new KeyValuePair<ClimberProfile, int>(MapType(cp), pcs.PlaceID);

            //-- Gives us only one result per user so they don't get multiple email notifications
            //-- for one partner call when a call is made for more than one place they are suscribed to
            List<Guid> distinctUserIDs = new List<Guid>();
            Dictionary<ClimberProfile, int> dic = new Dictionary<ClimberProfile, int>();

            foreach (KeyValuePair<ClimberProfile, int> result in query)
            {
                if (distinctUserIDs.Contains(result.Key.ID)) {}
                else 
                {
                    dic.Add(result.Key, result.Value);
                    distinctUserIDs.Add(result.Key.ID);
                }
            }
            return dic;
        }

        public List<ClimberProfile> GetPartnerEmailSubscribedUsers(int placeID)
        {
            return MapList((from pcs in ctx.PartnerCallSubscriptions
                            from cp in ctx.ClimberProfiles
                            where placeID == pcs.PlaceID && pcs.Email == true && pcs.UserID == cp.ID
                            select cp).ToList());
        }


        /// <summary>
        /// Altername get method to retrieve a profile by user's email instead of Guid UserID
        /// </summary>
        public List<ClimberProfile> Search(string name)
        {
            string lowerName = name.ToLower();
            
            var query = from c in ctx.ClimberProfiles where c.FullName.Contains(lowerName) || c.NickName.Contains(lowerName) select c;

            return MapList(query.ToList());
        }

        /// <summary>
        /// Altername get method to retrieve a profile by user's email instead of Guid UserID
        /// </summary>
        public List<ClimberProfile> Search(string climbingLevel, bool? isMale, int placeID, byte partnerStatusID)
        {
            var query = from c in ctx.ClimberProfiles select c;

            //-- Climbing ability filter
            if (climbingLevel != "Any") { query = from c in ctx.ClimberProfiles where c.ClimbingLevel == climbingLevel select c; }
            
            //-- Sex filter
            if (isMale.HasValue) { query = from c in query where c.IsMale == isMale select c; }

            //-- Partner status filter
            if (partnerStatusID != 0)
            {
                query = from c in query where c.PartnerStatusID == partnerStatusID select c;
            }            

            //-- Place filter
            if (placeID != 0) 
            {
                List<Guid> userIDsWhoClimbAtPlace = (from c in ctx.PlaceUserClimbs where c.PlaceID == placeID select c.UserID).ToList();
                query = from c in query where userIDsWhoClimbAtPlace.Contains(c.ID) select c;
            }

            return MapList(query.ToList());
        }


        /// <summary>
        /// Removed a user and all assocaited data from the database
        /// </summary>
        public void DeleteUserCompletely(Guid userID)
        {
            DeleteAllRelatedPartnersCallsAndReplies(userID);

            //-- Delete all posts and associated FK comments will go too from Cascade rule.
            new FeedClimberChannelRequestDA().DeleteAllRequestsForUser(userID);
            
            List<FeedPostComment> comments = new FeedPostCommentDA().GetUsersComments(userID);
            foreach (FeedPostComment c in comments) { new FeedPostCommentDA().Delete(c.ID); }
            
            List<FeedClimbingPost> posts = new FeedClimbingPostDA().GetUsersPosts(userID);
            foreach (FeedClimbingPost p in posts) { new FeedClimbingPostDA().Delete(p.ID);}

            ctx.Feedbacks.DeleteAllOnSubmit(from c in ctx.Feedbacks where c.UserID == userID select c);

            //-- Will have to build something smart here to delete a group and all it's associated childen...          
            ctx.PartnerCalls.DeleteAllOnSubmit(from c in ctx.PartnerCalls where c.ClimberProfileID == userID select c);
            ctx.PartnerCallSubscriptions.DeleteAllOnSubmit(from c in ctx.PartnerCallSubscriptions where c.UserID == userID select c);

            ctx.PlaceUserClimbs.DeleteAllOnSubmit(from c in ctx.PlaceUserClimbs where c.UserID == userID select c);
            ctx.UserMessages.DeleteAllOnSubmit(from c in ctx.UserMessages where c.ReceivingUserID == userID || c.SendingUserID == userID select c);

            ctx.UserSettings.DeleteAllOnSubmit(from c in ctx.UserSettings where c.ID == userID select c);
            ctx.MessageBoardMessages.DeleteAllOnSubmit(from c in ctx.MessageBoardMessages where c.UserID == userID select c);
            ctx.ClimberProfileExtendeds.DeleteAllOnSubmit(from c in ctx.ClimberProfileExtendeds where c.ID == userID select c);

            ctx.ClimberProfiles.DeleteAllOnSubmit(from c in ctx.ClimberProfiles where c.ID == userID select c);

            //-- TODO: consider if it is worth deleting a users images?
            //-- Deal with removing the message boards and child messages too:
            //ctx.MessageBoards.DeleteAllOnSubmit(from c in ctx.MessageBoards where c. == userID select c);

            ctx.SubmitChanges(ConflictMode.FailOnFirstConflict);

            Membership.DeleteUser(Membership.GetUser(userID).UserName);
        }


        private void DeleteAllRelatedPartnersCallsAndReplies(Guid userID)
        {
            //-- Delete all the replies made by the user
            ctx.PartnerCallReplies.DeleteAllOnSubmit(from c in ctx.PartnerCallReplies where c.ReplyingUserID == userID select c);

            //-- Delete all the replies to calls made by the user
            List<Guid> partnerCallIDsToDelete = (from c in ctx.PartnerCalls where c.ClimberProfileID == userID select c.ID).ToList();
            ctx.PartnerCallReplies.DeleteAllOnSubmit(from c in ctx.PartnerCallReplies where partnerCallIDsToDelete.Contains(c.PartnerCallID) select c);

            //-- Delete all calls made by the user
            ctx.PartnerCalls.DeleteAllOnSubmit(from c in ctx.PartnerCalls where c.ClimberProfileID == userID select c);
        }
    }

}
