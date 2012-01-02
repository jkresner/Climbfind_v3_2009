using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClimbFind.Model.Objects;
using ClimbFind.Web.UI;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects.Interfaces;


namespace IdentityStuff.Views.Home
{
    //-- TODO Possibilities
    //-- 1) Learn how to use the homepage via video
    //-- 2) Add a photo to your profile
    //-- 3) Filter the feed to your area
    //-- 4) Filter the feed to your place
    //-- 5) Verify your email address
    //-- 6) Comment on a thread
    //-- 7) If not posted in 2 weeks post again
    //-- 8) Fill out your extended profile
    //-- 9) Set up feed notifications
    //-- 10) Review watch requests
    //-- 11) Customise CFMail
    //-- 9) List more places on your profile
    //-- Add climbers to your climbers channel
    //-- Add climbfind on facebook
    //-- Check if your 3 favourite places are on Climbfind
    //-- ** Suggest an area tag
    //-- Submite a movie
    //-- ** Tell a friend about CF
    
    //-- ** Update the details for this place (Add a photo)?

    public partial class IndexToDo : ClimbFindViewUserControl
    {
        public Stack<string> ItemStack = new Stack<string>(); 
        public bool UserDoesNotHaveProfilePhoto { get{ return CFDataCache.GetClimberFromCache(UserID).ImageNotUploaded;} }
        protected int NumberOfItemsToDisplay = 2;
        public FeedSettings UsersFeedSettings { get; set; }
        public List<IFeedItem> UsersFeedPosts { get; set; }

        public delegate bool AddItemDelegate();

        protected void Page_Init(Object s, EventArgs e)
        {
            UsersFeedSettings = cf.GetUsersFeedViewSettings(UserID);
            CreateStack();
        }

        private void CreateStack()
        {       
            //AddItem( () => true, 
            //    @"View our short <a href=""/About#HelperVideos"">getting started videos</a> to learn on how to get the most out of Climbfind!");
            AddItem(() => !UsersFeedSettings.AreaID.HasValue,
                @"Filter the climbing feed to your country, state or city by clicking the <i>Channel</i> link that says ""Area""");

            AddItem( () => UserDoesNotHaveProfilePhoto, 
                @"<a href=""/ClimberProfiles/EditPicture""><b>Upload a profile picture</b></a> so people can recognize you."); 

            AddItem( () => !UsersFeedSettings.PlaceID.HasValue,
                @"Click the ""Place"" <i>Channel</i> link at the top of the feed to filter it to any indoor climbing center or outdoor location.");
            
            //-- todo change to show number of requests
            AddItem(() => cf.GetUnrepliedWatchRequests(UserID).Count > 0,
                @"Review <a href=""/CFFeed/ClimbersWatchingMe""> Pending <i>climber channel</i> requests</a>");

            AddItem(() => true,
                @"Be a fan on <a target=""_blank"" href=""http://www.facebook.com/pages/Climbfind/40120560277""><img src=""/images/site-partners/fbfavicon.jpg""/> <b>The Climbfind FB Fan Page</b></a> to receive status updates on new movies and Climbfind news.");

            
            //AddItem(@"Add climbers to your Feed <i>""Climbers""</i> channel via the <a href=""/CFFeed/ClimbersImWatching"">climbers I'm watching</a> page.");

            //AddItem(@"Confirm your top 3 climbing destinations are on our <a href=""/world-climbing-map"">world climbing map</a>, if not add them.");

            ItemStack.Reverse();
        }

        private void AddItem(AddItemDelegate fn, string itemHtml)
        {
            if (ItemStack.Count == NumberOfItemsToDisplay) { return; }
            else if (!(bool)fn.DynamicInvoke()) { return; }
            else { ItemStack.Push(itemHtml); }
        }

        //protected string GetRequestPlural()
        //{
        //    if (ClimberWatchRequests.Count > 1) { return "s"; }
        //    return "";
        //}

        protected string GetNextTODOItem()
        {
            if (ItemStack.Count > 0) { return ItemStack.Pop(); } else { return ""; }
        }


    }
}
