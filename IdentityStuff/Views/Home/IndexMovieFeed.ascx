<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndexMovieFeed.ascx.cs" Inherits="IdentityStuff.Views.Home.IndexMovieFeed" %>
<%@ OutputCache Duration="13600" VaryByParam="None" %>

<div id="MovieFeed">
    <div class="h1lookalike">Latest rock climbing movies</div>
    
    <div class="attentionDIV">
        <b>=> <img src="/images/site-partners/fbfavicon.jpg" style="padding:0" /> Fan <a target="_blank" href="http://www.facebook.com/pages/Climbfind/40120560277"> Climbfind on facebook</a></b>
        to get status updates on new movies in this feed. You can also    
        <%= Html.ActionLink<MediaController>(c=>c.SubmitMovie(), "Submit your own movie") %>!</div>
                            
    <% 
       foreach (KeyValuePair<MediaShare, int> media in LatestMedia)
       { %>
        <div class="YouTubeMovieDIV">
            <div><b><%= media.Key.Name%></b></div>          
            
            <div style="font-size:9px">
                Taken @ <img src='<%= ClimbFind.Model.DataAccess.CFDataCache.GetPlaceProp<string>(c=>c.FlagImageUrl2, media.Value) %>' />
              <a href="<%= ClimbFind.Model.DataAccess.CFDataCache.GetPlaceProp<string>(c=>c.ClimbfindUrl, media.Value)%>">
                <%= ClimbFind.Model.DataAccess.CFDataCache.GetPlaceProp<string>(c=>c.Name, media.Value)%></a>
                <br />
                Submitted by <%= CFControls.ClimberProfileLink(this, ClimbFind.Model.DataAccess.CFDataCache.GetClimberFromCache(media.Key.SubmittedByUserID))%>
                at <%= media.Key.SubmittedDateTime.ToCFDateAndTimeString()%> 
            </div>
            
            <p><%= media.Key.Description%> ... <%= Html.ActionLink<MediaController>(c => c.Detail(media.Key.ID), "Leave comment")%></p>
            <br /><%= media.Key.RenderInBrowser()%>
        </div>
        <% } %>

</div>



