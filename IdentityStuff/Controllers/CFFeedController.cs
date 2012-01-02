using System;
using System.Linq;
using System.Web.Mvc;
using ClimbFind.Controller;
using ClimbFind.Model.Objects;
using IdentityStuff.Controllers.ActionFilters;
using ClimbFind.Model.DataAccess;
using System.Collections.Generic;
using ClimbFind.Model.Enum;
using ClimbFind.Model.Objects.Interfaces;

namespace ClimbFind.Web.Mvc.Controllers
{
    [HandleError(View = "Error")]
    public partial class CFFeedController : BaseController
    {
        [LoginFilter]
        public ActionResult RenderFeed(byte channel, byte view, string area, string place, string tag)
        {
            try
            {
                int temp;
                byte? tagID = null; if (int.TryParse(tag, out temp)) { tagID = (byte)temp; }
                int? areaID = null; if (int.TryParse(area, out temp)) { areaID = temp; }
                int? placeID = null; if (int.TryParse(place, out temp)) { placeID = temp; }
                            
                FeedView feedView = (FeedView)view;
                FeedChannel feedChannel = (FeedChannel)channel;

                return View("FeedItemList",
                    GetFeedItemsForViewSettings(feedChannel, feedView, areaID, placeID, tagID));
            
            }
            catch (Exception ex)
            {
                CFLogger.RecordException(ex);
                SetPageMetaData();
                return View("UrlGone");
            }
        }

        private List<IFeedItem> GetFeedItemsForViewSettings(FeedChannel channel, FeedView view, 
            int? areaID, int? placeID, byte? tagID)
        {
            int numberOfPostsToDisplay = 40;
            int displayClimbingCount = 0, displayPartnerCallCount = 0, displayMovieCount = 0;
            
            FeedSettings settings = controller.UpdateFeedSettingsIfNecessary(UserID, channel, areaID, placeID);
            settings.TagID = tagID; // decided not to persist the tag in the db at this point in time.
            
            //-- Need to do on client side
            //if (Settings.HasPlace) { CurrentPlaceLkB.Text = CurrentFeedPlace.ShortName.Take(12); }
            //if (Settings.HasArea) { CurrentAreaLkB.Text = CurrentFeedArea.Name.Take(12); }
            //if (Settings.TagID.HasValue) { CurrentTagLB.Text = GetTagsString(Settings.TagID.Value); }

            if (view == FeedView.Posted)
            {
                //SelectLkB(PLkB);

                if (settings.TagID.HasValue)
                {
                    displayClimbingCount = numberOfPostsToDisplay;
                }
                else
                {
                    displayClimbingCount = 12;
                    displayPartnerCallCount = 5;
                    displayMovieCount = 3;
                }
            }
            else if (view == FeedView.Movies)
            {
                //SelectLkB(MLkB);
                settings.TagID = null;
                displayMovieCount = 15;
            }
            else if (view == FeedView.Climbing)
            {
                //SelectLkB(DCLkb);
                displayClimbingCount = numberOfPostsToDisplay;
            }
            else if (view == FeedView.PartnerCalls)
            {
                //SelectLkB(PCLkB);
                settings.TagID = null;
                displayPartnerCallCount = 17;
            }

            if (channel == FeedChannel.All)
            {
                //SelectLkB(AllLkB);
            }
            else if (channel == FeedChannel.Area)
            {
                //SelectLkB(CurrentAreaLkB);
                //FeedFocus = CurrentFeedArea.Name;
            }
            else if (channel == FeedChannel.Place)
            {
                //SelectLkB(CurrentPlaceLkB);
                //FeedFocus = CurrentFeedPlace.Name;
            }
            //else if (channel == FeedChannel.Climbers)
            //{
                //SelectLkB(ClLkB);
            //    settings.WatchedClimbers = controller.GetClimbersUserIsWatching(UserID);
                //FeedFocus = "climbers you're watching";
            //}

            List<IFeedItem> FeedItems = new List<IFeedItem>();
            List<FeedMoviePost> MoviePosts = new List<FeedMoviePost>();
            List<FeedPartnerCallPost> PartnerCallPosts = new List<FeedPartnerCallPost>();
            List<FeedClimbingPost> ClimbingPosts = new List<FeedClimbingPost>();

            if (displayClimbingCount > 0) { ClimbingPosts = controller.GetPostsBySettings(settings, view, numberOfPostsToDisplay); }

            //-- Fill the feed if we don't have enough posts
            if (view == FeedView.Posted && !settings.TagID.HasValue)
            {
                if (ClimbingPosts.Count < numberOfPostsToDisplay)
                {
                    byte numberToFill = (byte)(numberOfPostsToDisplay - ClimbingPosts.Count);
                    displayMovieCount++;
                    displayPartnerCallCount = (byte)(numberToFill - 1);
                }
            }

            if (displayMovieCount > 0 && !settings.TagID.HasValue) { MoviePosts = controller.GetFeedMoviesBySettings(settings, displayMovieCount); }
            
            if (displayPartnerCallCount > 0 && 
                (!settings.TagID.HasValue || settings.TagID.Value != 1) &&
                channel != FeedChannel.Climbers) { PartnerCallPosts = controller.GetFeedPartnerCallPostsBySettings(settings, displayPartnerCallCount); }

            foreach (FeedClimbingPost cp in ClimbingPosts) { FeedItems.Add(cp); }
            foreach (FeedMoviePost mp in MoviePosts) { FeedItems.Add(mp); }
            foreach (FeedPartnerCallPost pcp in PartnerCallPosts) { FeedItems.Add(pcp); }
            if (view == FeedView.Posted)
            {
                FeedItems = (from c in FeedItems orderby c.PostedDateTime descending select c).ToList();
            }
            return FeedItems;
        }    
    

        
        [LoginFilter] public ActionResult FindClimbersForWatchList() { return NoMetaView(); }
        [LoginFilter] public ActionResult ClimbersImWatching() { return NoMetaView(); }
        [LoginFilter] public ActionResult ClimbersWatchingMe() { return NoMetaView(); }
        [LoginFilter] public ActionResult AboutFeedTags() { return NoMetaView(); }
        
        [LoginFilter]
        public ActionResult AcceptWatchRequest(int id)
        {
            FeedClimberChannelRequest watchedClimberEntry = new CFController().GetClimberWatchEntry(id);

            new CFController().AcceptWatchRequest(watchedClimberEntry);
            return RedirectToAction("ClimbersWatchingMe");
        }
        

        [LoginFilter]
        public ActionResult RequestToWatchClimber(Guid id)
        {
            FeedClimberChannelRequest watchedClimberEntry = new CFController().GetClimberWatchEntry(UserID, id);

            if (watchedClimberEntry == null)
            {
                new CFController().SendClimberWatchRequest(id, UserID);
            }
            else
            {
                throw new Exception("You have already sent a watch request to this climber.");
            }

            return RedirectToAction("ClimbersImWatching");
        }

        [LoginFilter]
        public ActionResult NewPostPlace()
        {
            return NoMetaView();
        }

        [LoginFilter]
        public ActionResult FirstPost()
        {
            return NoMetaView();
        }

        [LoginFilter]
        public ActionResult NewPost(int? placeID)
        {           
            SetPageMetaData();

            if (!placeID.HasValue)
            {
                return RedirectToAction("NewPostPlace");
            }
            else
            {
                Place place = new CFController().GetPlace(placeID.Value);

                if (place == null) { return RedirectToAction("NewPostPlace"); }
                else
                {
                    return Content("You can no longer post on CF3, please use www.climbfind.com");
                }  
            }
        }

        


        [LoginFilter]
        public ActionResult CommentOnPost(int id)
        {
            FeedClimbingPost post = new CFController().GetFeedClimbingPost(id);

            if (post == null) { return RedirectToAction("Index", "Home"); }
            else
            {
                return NoMetaView(post);
            }  
        }

        [LoginFilter]
        public ActionResult MeetUp(int id)
        {
            FeedClimbingPost post = new CFController().GetFeedClimbingPost(id);

            if (post == null) { return RedirectToAction("Index", "Home"); }
            else
            {
                return NoMetaView(post);
            }
        }

        [LoginFilter]
        public ActionResult DeletePost(int id)
        {
            FeedClimbingPost post = new CFController().GetFeedClimbingPost(id);

            if ((post.UserID != UserID) && !CFProfile.UserIsKrez) { throw new Exception("Cannot delete a feed post that doesn't belong to you"); }
            else
            {
                new CFController().DeleteFeedClimbingPost(post);
            }

            return RedirectToAction("Index", "Home");
        
        }

        [LoginFilter]
        public ActionResult DeletePostComment(int id)
        {
            FeedPostComment comment = new CFController().GetFeedPostComment(id);

            if (comment == null) { return RedirectToAction("Index", "Home"); }
            else
            {
                if (comment.UserID != UserID) { throw new Exception("Cannot delete a feed post comment that doesn't belong to you"); }
                else
                {
                    new CFController().DeleteFeedPostComment(comment);
                }

                return RedirectToAction("CommentOnPost", new { id = comment.FeedPostID });
            }
        }

    }
}
