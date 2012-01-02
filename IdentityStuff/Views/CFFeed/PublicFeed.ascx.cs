using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClimbFind.Model.Objects;
using ClimbFind.Web.UI;
using ClimbFind.Model.DataAccess;
using ClimbFind.Helpers;
using System.Web.UI.WebControls;
using ClimbFind.Model.Enum;
using ClimbFind.Model.Objects.Interfaces;


namespace IdentityStuff.Views.CFFeed
{
    public partial class PublicFeed : ClimbFindViewUserControl
    {
        protected List<IFeedItem> AllChannelFeedItems, EnglandChannelFeedItems;
        protected List<FeedClimbingPost> AllClimbingPosts, EnglandClimbingPosts;
        protected List<FeedMoviePost> AllMoviePosts, EnglandMoviePosts;
        protected List<FeedPartnerCallPost> AllPartnerCallPosts, EnglandPartnerCallPosts;

        protected FeedSettings Settings;

        protected AreaTag CurrentFeedArea { get { return CFDataCache.GetAreaTag(Settings.AreaID.Value); } }
        protected byte displayMovieCount;
        protected FeedChannel CurrentChannelType { get { return (FeedChannel)Settings.CurrentChannelType; } }
        private byte numberOfPostsToDisplay = 15;



        protected void Page_Init(Object o, EventArgs e)
        {
            Settings = new FeedSettings { AreaID = 9, CurrentChannelType = (byte)FeedChannel.All };
        }

        protected void Page_Load(Object o, EventArgs e)
        {   
            if (!Page.IsPostBack)
            {
                RenderFeedByViewSettings();
            }
        }

        private void RenderFeedByViewSettings()
        {
            CombineAndArrangePosts();
        }

        private void CombineAndArrangePosts()
        {
            AllChannelFeedItems = new List<IFeedItem>(); EnglandChannelFeedItems = new List<IFeedItem>();
            AllMoviePosts = new List<FeedMoviePost>(); EnglandMoviePosts = new List<FeedMoviePost>();

            AllClimbingPosts = cf.GetPostsBySettings(Settings, FeedView.Posted, numberOfPostsToDisplay);
            AllPartnerCallPosts = cf.GetFeedPartnerCallPostsBySettings(Settings, 4);
            AllMoviePosts = cf.GetFeedMoviesBySettings(Settings, 1);
            foreach (FeedClimbingPost cp in AllClimbingPosts) { AllChannelFeedItems.Add(cp); }           
            foreach (FeedMoviePost mp in AllMoviePosts) { AllChannelFeedItems.Add(mp); }
            foreach (FeedPartnerCallPost pcp in AllPartnerCallPosts) { AllChannelFeedItems.Add(pcp); }

            AllChannelFeedItems = (from c in AllChannelFeedItems orderby c.PostedDateTime descending select c).ToList();

            Settings.CurrentChannelType = (byte)FeedChannel.Area;
            EnglandClimbingPosts = cf.GetPostsBySettings(Settings, FeedView.Posted, numberOfPostsToDisplay);
            EnglandPartnerCallPosts = cf.GetFeedPartnerCallPostsBySettings(Settings, 4);
            EnglandMoviePosts = cf.GetFeedMoviesBySettings(Settings, 1);
            foreach (FeedClimbingPost cp in EnglandClimbingPosts) { EnglandChannelFeedItems.Add(cp); }
            foreach (FeedMoviePost mp in EnglandMoviePosts) { EnglandChannelFeedItems.Add(mp); }
            foreach (FeedPartnerCallPost pcp in EnglandPartnerCallPosts) { EnglandChannelFeedItems.Add(pcp); }
            EnglandChannelFeedItems = (from c in EnglandChannelFeedItems orderby c.PostedDateTime descending select c).ToList();
            
        }
    }

}
