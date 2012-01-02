using System;
using System.Linq;
using System.Collections.Generic;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Enum;
using ClimbFind.Model.Objects;
using ClimbFind.Mail;
using ClimbFind.Model.Objects.Interfaces;

namespace ClimbFind.Controller
{
    public partial class CFController
    {
        public FeedClimbingPost SaveFeedPost(FeedClimbingPost newPost)
        {
            newPost.PostedDateTime = DateTime.Now;
            FeedClimbingPost post = new FeedClimbingPostDA().Insert(newPost);

            List<ClimberProfile> usersSubscribedToPlace 
                = new ClimberProfileDA().GetPartnerEmailSubscribedUsers(newPost.PlaceID);

            Place place = CFDataCache.GetPlace(newPost.PlaceID);
            ClimberProfile poster = CFDataCache.GetClimberFromCache(newPost.UserID);
            foreach (ClimberProfile cp in usersSubscribedToPlace)
            {
                MailMan.SendPartnerFeedPostNotificationEmail(cp, poster, post, place.Name);
            }
        
            return post;
        }

        public FeedClimbingPost SaveFeedIntroductionPost(FeedClimbingPost newPost)
        {
            //-- Add that place to user's profile
            List<int> placeIDs = (from c in GetPlacesUserClimbs(newPost.UserID) select c.ID).ToList();
            if (!placeIDs.Contains(newPost.PlaceID)) { SavePlaceUserClimbsAt(newPost.UserID, newPost.PlaceID); }
            
            //-- Save the post
            newPost.PostedDateTime = DateTime.Now;
            newPost.ClimbingDateTime = DateTime.Now;
            newPost.TagID = 52;
            FeedClimbingPost post = new FeedClimbingPostDA().Insert(newPost);
       
            //-- Send off notifications
            List<ClimberProfile> usersSubscribedToPlace
                = new ClimberProfileDA().GetPartnerEmailSubscribedUsers(newPost.PlaceID);
            
            Place place = CFDataCache.GetPlace(newPost.PlaceID);
            ClimberProfile poster = CFDataCache.GetClimberFromCache(newPost.UserID);
            foreach (ClimberProfile cp in usersSubscribedToPlace)
            {
                MailMan.SendFeedPostIntroductionNotificationEmail(cp, poster, post, place.Name);
            }
            
            //-- Subscribe them to this place too
            SubscribeToPartnerCallsByEmail(newPost.UserID, place.ID);

            return post;
        }

        public FeedClimbingPost GetFeedClimbingPost(int id)
        {
            return new FeedClimbingPostDA().GetByID(id);
        }

        public FeedPostComment GetFeedPostComment(int id)
        {
            return new FeedPostCommentDA().GetByID(id);
        }

        public List<FeedClimbingPost> GetPostsByUser(Guid userID, int number)
        {
            return new FeedClimbingPostDA().GetPostsByUser(userID, number);
        }

        public List<FeedClimbingPost> GetPostsByPlace(int placeID, int number)
        {
            return new FeedClimbingPostDA().GetLatestPlacePosts(number, placeID, null, FeedView.Posted);
        }

        public List<FeedClimbingPost> GetPostsBySettings(FeedSettings settings, FeedView order, int number)
        {
            if (order == FeedView.Movies) { return new List<FeedClimbingPost>(); }
            
            if (settings.CurrentChannelType == (byte)FeedChannel.Area)
            {
                return new FeedClimbingPostDA().GetLatestAreaPosts(number, settings.AreaID.Value, settings.TagID, order);
            }
            else if (settings.CurrentChannelType == (byte)FeedChannel.Place)
            {
                return new FeedClimbingPostDA().GetLatestPlacePosts(number, settings.PlaceID.Value, settings.TagID, order);
            }
            else if (settings.CurrentChannelType == (byte)FeedChannel.Climbers)
            {
                List<Guid> userIDsBeingWatched = (from c in settings.WatchedClimbers select c.WatchedUserID).ToList();
                return new FeedClimbingPostDA().GetLatestWatchedClimberPosts(number, userIDsBeingWatched, settings.TagID, order);
            }
            else
            {
                return new FeedClimbingPostDA().GetLatestPosts(number, settings.TagID, order);
            }
        }


        public List<FeedPartnerCallPost> GetFeedPartnerCallPostsBySettings(FeedSettings settings, int count)
        {
            if (settings.CurrentChannelType == (byte)FeedChannel.Place)
            {
                return new PartnerCallDA().GetLatestFeedPartnerCallPostsForPlace(settings.PlaceID.Value, count);
            }
            if (settings.CurrentChannelType == (byte)FeedChannel.Area)
            {
                List<PartnerCall> calls = new PartnerCallDA().GetPartnerCallsForAreaTag(settings.AreaID.Value, count, null);
                return (from c in calls select new FeedPartnerCallPost { Call = c }).ToList(); 
            }
            else 
            {
                List<PartnerCall> calls = new PartnerCallDA().GetLatestPartnerCalls(count, PartnerCallPlaceType.Both);
                return (from c in calls select new FeedPartnerCallPost { Call = c }).ToList();
            }
        }

        public FeedSettings GetUsersFeedViewSettings(Guid userID)
        {
            FeedSettings settings = new FeedSettingsDA().GetByID(userID);
            if (settings == null) { 
                return new FeedSettingsDA().Insert(new FeedSettings { 
                    ID = userID, 
                    NotifyOnPostComment =true, 
                    NotifyOnPostsICommentedOn = true, 
                    PostPrivacySettings = (byte)FeedPostPrivacy.PostsVisibleToEveryone }); }
            return settings;
        }




        public List<FeedClimberChannelRequest> GetClimbersIHaveRequested(Guid userID)
        {
            return new FeedClimberChannelRequestDA().GetClimbersNotAcceptedRequestFromUser(userID); 
        }

        public List<FeedClimberChannelRequest> GetClimbersUserIsWatching(Guid userID)
        {
            return new FeedClimberChannelRequestDA().GetClimbersUserIsWatching(userID); 
        }

        public List<FeedClimberChannelRequest> GetClimbersWatchingMe(Guid userID)
        {
            return new FeedClimberChannelRequestDA().GetClimbersWatchingMe(userID); 
        }

        

        public void SendClimberWatchRequest(Guid watchedUserID, Guid watchingUserID)
        {
            FeedClimberChannelRequest watchedClimberEntry = new FeedClimberChannelRequestDA().Insert(
                new FeedClimberChannelRequest() { WatchedUserID=watchedUserID, 
                    WatchingUserID = watchingUserID, RequestedDateTime = DateTime.Now});

            MailMan.SendWatchRequestEmail(watchedClimberEntry.ID, CFDataCache.GetClimberFromCache(watchingUserID),
                CFDataCache.GetClimberFromCache(watchedUserID));
        }

        
        public FeedClimberChannelRequest GetClimberWatchEntry(Guid watchingUserID, Guid watchedUserID)
        {
            return new FeedClimberChannelRequestDA().GetClimberWatchEntry(watchingUserID, watchedUserID);
        }

        public FeedClimberChannelRequest GetClimberWatchEntry(int id)
        {
            return new FeedClimberChannelRequestDA().GetByID(id);
        }

        public List<FeedClimberChannelRequest> GetUnrepliedWatchRequests(Guid watchedUserID)
        {
            return new FeedClimberChannelRequestDA().GetUnrepliedWatchRequests(watchedUserID);
        }
        


        public void AcceptWatchRequest(FeedClimberChannelRequest watchEntry)
        {
            if (watchEntry.WatchedUserID != CurrentClimber.ID)
            {
                throw new Exception("Cannot accept channel request that was not made for you");
            }
            
            if (!watchEntry.ApprovedDateTime.HasValue || watchEntry.RejectedDateTime.HasValue)
            {
                watchEntry.RejectedDateTime = null;
                watchEntry.ApprovedDateTime = DateTime.Now;
                new FeedClimberChannelRequestDA().Update(watchEntry);
            }            
        }
        

        public FeedSettings UpdateUsersFeedViewSettings(FeedSettings settings)
        {
            return new FeedSettingsDA().Update(settings);
        }


        public FeedPostComment SaveFeedPostComment(FeedPostComment comment)
        {
            comment.PostedDateTime = DateTime.Now;
            FeedPostComment newComment = new FeedPostCommentDA().Insert(comment);
            FeedClimbingPost post = new FeedClimbingPostDA().GetByID(comment.FeedPostID);
 
            //-- Send notification to the poster
            FeedSettings postersFeedSettings = GetUsersFeedViewSettings(post.UserID);
            if (postersFeedSettings.NotifyOnPostComment && comment.UserID != post.UserID)
            {
                MailMan.SendCommentOnMyFeedPostNotification(post.ID, comment.User, post.User, comment.Message );
            }

            List<Guid> uniqueCommentingUserIDs = (from c in post.Comments where c.UserID != post.UserID select c.UserID).Distinct().ToList();

            //-- Send notifications to other commentors
            foreach (Guid userID in uniqueCommentingUserIDs)
            {
                FeedSettings commentorsFeedSettings = GetUsersFeedViewSettings(userID);
                if (commentorsFeedSettings.NotifyOnPostsICommentedOn && comment.UserID != userID)
                {
                    MailMan.SendCommentOnAFeedPostICommentedOnNotification(post.ID, comment.User, post.User, 
                        CFDataCache.GetClimberFromCache(userID), comment.Message);
                }
            }

            return newComment;
        }

        public void DeleteFeedClimbingPost(FeedClimbingPost post)
        {
            new FeedClimbingPostDA().Delete(post.ID);
        }


        public void DeleteFeedPostComment(FeedPostComment comment)
        {
            new FeedPostCommentDA().Delete(comment.ID);
        }


        public FeedSettings UpdateFeedSettingsIfNecessary(Guid userID, FeedChannel channel, int? areaID, int? placeID)
        {
            return new FeedSettingsDA().UpdateIfNecessary(userID, channel, areaID, placeID);
        }



        public List<IFeedItem> GetUsersActivity(Guid userID)
        {
            List<IFeedItem> FeedItems = new List<IFeedItem>();
            List<FeedMoviePost> MoviePosts = GetFeedMoviesForUser(userID, 3);
            List<FeedPartnerCallPost> PartnerCallPosts = GetUsersPartnerCallFeedPost(userID, 5);
            foreach (FeedMoviePost p in MoviePosts) { p.Comments = GetCommentsForMedia(p.PlaceMedia.MessageBoardID); }

            int totalPosts = 20;
            int remaining = totalPosts - (MoviePosts.Count + PartnerCallPosts.Count);
            List<FeedClimbingPost> ClimbingPosts = GetPostsByUser(userID, remaining);

            foreach (FeedClimbingPost cp in ClimbingPosts) { FeedItems.Add(cp); }
            foreach (FeedMoviePost mp in MoviePosts) { FeedItems.Add(mp); }
            foreach (FeedPartnerCallPost pcp in PartnerCallPosts) 
            {
                pcp.Comments = (from c in pcp.Call.Replies
                                select new FeedPostComment { Message = c.Message, PostedDateTime = c.ReplyDateTime, UserID = c.ReplyingUserID }).ToList();
                FeedItems.Add(pcp); 
            }
            return (from c in FeedItems orderby c.PostedDateTime descending select c).ToList();
        }



        public List<IFeedItem> GetPlacesLatestFeedActivity(int placeID)
        {
            List<IFeedItem> FeedItems = new List<IFeedItem>();
            List<FeedMoviePost> MoviePosts = GetFeedMoviesForPlace(placeID, 5);
            List<FeedPartnerCallPost> PartnerCallPosts = GetPlacesPartnerCallFeedPost(placeID, 8);
            foreach (FeedMoviePost p in MoviePosts) { p.Comments = GetCommentsForMedia(p.PlaceMedia.MessageBoardID); }

            int totalPosts = 25;
            int remaining = totalPosts - (MoviePosts.Count + PartnerCallPosts.Count);
            List<FeedClimbingPost> ClimbingPosts = GetPostsByPlace(placeID, remaining);

            foreach (FeedClimbingPost cp in ClimbingPosts) { FeedItems.Add(cp); }
            foreach (FeedMoviePost mp in MoviePosts) { FeedItems.Add(mp); }
            foreach (FeedPartnerCallPost pcp in PartnerCallPosts) { FeedItems.Add(pcp); }
            return (from c in FeedItems orderby c.PostedDateTime descending select c).ToList();
        }

        public List<IFeedItem> GetPlacesAllFeedActivity(int placeID)
        {
            List<IFeedItem> FeedItems = new List<IFeedItem>();
            List<FeedMoviePost> MoviePosts = GetFeedMoviesForPlace(placeID, 15);
            List<FeedPartnerCallPost> PartnerCallPosts = GetPlacesPartnerCallFeedPost(placeID, 100);
            foreach (FeedMoviePost p in MoviePosts) { p.Comments = GetCommentsForMedia(p.PlaceMedia.MessageBoardID); }

            int totalPosts = 200;
            int remaining = totalPosts - (MoviePosts.Count + PartnerCallPosts.Count);
            List<FeedClimbingPost> ClimbingPosts = GetPostsByPlace(placeID, remaining);

            foreach (FeedClimbingPost cp in ClimbingPosts) { FeedItems.Add(cp); }
            foreach (FeedMoviePost mp in MoviePosts) { FeedItems.Add(mp); }
            foreach (FeedPartnerCallPost pcp in PartnerCallPosts) { FeedItems.Add(pcp); }
            return (from c in FeedItems orderby c.PostedDateTime descending select c).ToList();
        }

        public List<IPartnerPageItem> GetPlacesPartnerPageFeedActivity(int placeID)
        {
			List<IPartnerPageItem> FeedItems = new List<IPartnerPageItem>();
			
			List<FeedPartnerCallPost> PartnerCallPosts = GetPlacesPartnerCallFeedPost(placeID, 100);
			
			int totalPosts = 20;
			int remaining = totalPosts - (PartnerCallPosts.Count);
			List<FeedClimbingPost> ClimbingPosts = GetPostsByPlace(placeID, remaining);

			foreach (FeedClimbingPost cp in ClimbingPosts) { FeedItems.Add(cp); }
			foreach (FeedPartnerCallPost pcp in PartnerCallPosts) { FeedItems.Add(pcp); }
			return (from c in FeedItems orderby c.PostedDateTime descending select c).ToList();
		}
		


    }
}
