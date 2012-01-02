using System;
using System.Linq;
using System.Web.UI;
using ClimbFind.Web.Mvc.Controllers;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;
using System.Collections.Generic;
using ClimbFind.Model.Enum;
using ClimbFind.Model.Objects;
using ClimbFind.Model.DataAccess;
using Microsoft.Web.Mvc;


namespace ClimbFind.Web.Mvc
{
    public partial class HomepageSettings : ClimbFindViewPage<LoginViewData>
    {
        FeedSettings feedSettings;

        
        protected void Page_Init(object sender, EventArgs e)
        {
            //partnerCallSettings = cfController.GetUsersHomepagePartnerCallSettings(UserID);
            feedSettings = cfController.GetUsersFeedViewSettings(UserID);

            if (!Page.IsPostBack)
            {

                //if (partnerCallSettings.PlaceType == PartnerCallPlaceType.Both)
                //{
                //    TypeBothRB.Checked = true;
                //}
                //else if (partnerCallSettings.PlaceType == PartnerCallPlaceType.Indoor)
                //{
                //    TypeIndoorRB.Checked = true;
                //}
                //else if (partnerCallSettings.PlaceType == PartnerCallPlaceType.Outdoor)
                //{
                //    TypeOutdoorRB.Checked = true;
                //}

                //if (partnerCallSettings.DisplayMode == PartnerCallDisplayMode.All)
                //{
                //    ShowAllRB.Checked = true;
                //}
                //else if (partnerCallSettings.DisplayMode == PartnerCallDisplayMode.Area)
                //{
                //    ShowAreaRB.Checked = true;
                //    if (!feedSettings.AreaID.HasValue) { feedSettings.AreaID = 38; }
                //    AreaTag currentArea = CFDataCache.GetAreaTag(feedSettings.AreaID.Value);
                //    TxB.Text = currentArea.Name;
                //    ResultsHD.Value = currentArea.ID.ToString();
                //}

                NotifyOnPostCommentCB.Checked = feedSettings.NotifyOnPostComment;
                NotifyOnPostsICommentedOnCB.Checked = feedSettings.NotifyOnPostsICommentedOn;

                PrivacyVisibleToAll.Checked = (feedSettings.PostPrivacySettings == (short)FeedPostPrivacy.PostsVisibleToEveryone);
                PrivacyVisibleToWatchers.Checked = (feedSettings.PostPrivacySettings == (short)FeedPostPrivacy.PostsVisibleToWatchingMe);
            }
        }


        //protected void SaveHomepagePartnerCallFeedSetting_Click(object sender, EventArgs e)
        //{
        //    if (PeterBlum.VAM.Globals.Page.IsValid)
        //    {
        //        if (TypeBothRB.Checked) { partnerCallSettings.Types = (byte)PartnerCallPlaceType.Both; }
        //        if (TypeIndoorRB.Checked) { partnerCallSettings.Types = (byte)PartnerCallPlaceType.Indoor; }
        //        if (TypeOutdoorRB.Checked) { partnerCallSettings.Types = (byte)PartnerCallPlaceType.Outdoor; }

        //        if (ShowAllRB.Checked) { partnerCallSettings.ViewBy = (byte)PartnerCallDisplayMode.All; }
        //        if (ShowAreaRB.Checked)
        //        {
        //            partnerCallSettings.ViewBy = (byte)PartnerCallDisplayMode.Area;
        //            partnerCallSettings.AreaID = byte.Parse(ResultsHD.Value);
        //        }

        //        cfController.UpdateUsersPartnerCallFeedSettings(partnerCallSettings);

        //        RedirectTo<HomeController>(c => c.Index());
        //    }
        //}


        protected void SaveFeedSetting_Click(object sender, EventArgs e)
        {
            feedSettings.NotifyOnPostComment = NotifyOnPostCommentCB.Checked;
            feedSettings.NotifyOnPostsICommentedOn = NotifyOnPostsICommentedOnCB.Checked;

            if (PrivacyVisibleToAll.Checked) {
                feedSettings.PostPrivacySettings = (byte)FeedPostPrivacy.PostsVisibleToEveryone;
            }
            else if (PrivacyVisibleToWatchers.Checked)
            {
                feedSettings.PostPrivacySettings = (byte)FeedPostPrivacy.PostsVisibleToWatchingMe;
            }
            
            cfController.UpdateUsersFeedViewSettings(feedSettings);
            RedirectTo<HomeController>(c => c.Index());
        }

    }
}
