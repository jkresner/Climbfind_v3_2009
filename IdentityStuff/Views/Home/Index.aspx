<%@ Page Language="C#" MasterPageFile="~/Views/Shared/cf.master" AutoEventWireup="True" CodeBehind="Index.aspx.cs" Inherits="ClimbFind.Web.Mvc.Views.Home.Index" %>
<%@ Register TagName="IndexNewsFeed" TagPrefix="cf" Src="~/Views/Home/IndexNewsFeed.ascx" %>
<%@ Register TagName="IndexSiteAffiliates" TagPrefix="cf" Src="~/Views/Home/IndexSiteAffiliates.ascx" %>
<%@ Register TagName="PublicFeed" TagPrefix="cf" Src="~/Views/CFFeed/PublicFeed.ascx" %>
<%@ Register TagName="IndexMovieFeed" TagPrefix="cf" Src="~/Views/Home/IndexMovieFeed.ascx" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<div id="AboutCF3Column">

    <div>
        <h1 title="Find a climbing partner">Connect with the climbing world</h1>

        <img src="/images/rock-climbing.jpg" class="float-left imgGrayBorder" alt="Online Rock Climbing Community" />
        
        <p id="HomeIntro">
            <b>Climbfind connects you with climbers in your local climbing community &
            around the world</b> Use it to find climbing locations, get familiar with people who climb where you climb,
            organize car pools, find climbing partners & share movies. <a href="/Join"><b>Join Climbfind now!</b></a>
        </p>
    </div>
    
    <div id="ClimbingPlaces">   
        <h1>Rock climbing locations</h1>
        
        <script type="text/javascript"> $(document).ready(function() { $('#PlacesSlideshow').innerfade({ animationtype: 'fade', speed: 1400, timeout: 6000, type: 'sequence', containerheight: '170px' }); }); </script> 
        
        <ul id="PlacesSlideshow">
            <li><a href="/places/outdoor-rock-climbing/england/the-peak-district">
                <img src="/images/ui/flags/england.png"/> The Peak District, England</a>
                <img src="/images/specialpages/homepage/the-peak-district.jpg" />            
            </li>
            <li><a href="/places/outdoor-rock-climbing/australia/arapiles">
                <img src="/images/ui/flags/au.png"/> Arapiles, VIC Australia</a>
                <img src="/images/specialpages/homepage/arapiles.jpg" />            
            </li>
            <li><a href="/places/outdoor-rock-climbing/united-states/yosemite">
                <img src="/images/ui/flags/us.png"/> Yosemite, California USA</a>
                <img src="/images/specialpages/homepage/yosemite.jpg" />
            </li>
            <li><a href="/places/outdoor-rock-climbing/thailand/tonsai-beach-phra-nang-bay">
                <img src="/images/ui/flags/th.png"/> Tonsai Beach, Thailand</a>
                <img src="/images/specialpages/homepage/tonsai.jpg" />
            </li>
            <li><a href="/places/outdoor-rock-climbing/canada/squamish">
                <img src="/images/ui/flags/ca.png"/> Squamish, B.C. Canada</a>
                <img src="/images/specialpages/homepage/squamish.jpg" />
            </li>
        </ul>       
               
        <p style="font-size:10px;padding-top:2px;text-align:justify">
        Climbfind currently has <%= ClimbFind.Model.DataAccess.CFDataCache.AllPlaces.Count %>
        community added climbing locations
        categorised into <%= ClimbFind.Model.DataAccess.CFDataCache.AllAreaTags.Count %> 
        <a href="/Places">climbing areas</a> across         
        <%= (from c in ClimbFind.Model.DataAccess.CFDataCache.AllPlaces select c.CountryID).Distinct().Count() %>
         countries. Browse to all of them via our <a href="/world-climbing-map" title="Rock climbing map">World climbing map</a>
         or selectively by typing in an area like '<i><a href="/climbing-around/united-states/san-francisco" title="Rock climbing San Francisco">San Francisco</a></i>' into the search bar at the top right of the site.
        </p>
                
    </div>    

    <hr />

    <div id="Movies">
        <cf:IndexMovieFeed ID="IndexMovieFeedUC" runat="server" />         
    </div>

    <div style="padding-top:10px">  
        <cf:IndexSiteAffiliates id="IndexSiteAffiliatesUC" runat="server" />           
    </div>

</div>

<div id="PublicCF3FeedColumn">
    
    <div>
        <h2>Climbing feed</h2>
        
            <p style="font-style:italic;font-size:10px;margin:5px 11px 10px 5px;text-align:justify">
                The Climbing feed tells you where people are climbing and who's looking for partners / lifts.
                You can instantly filter   
                the feed to any country, state, city, indoor climbing gym or outdoor location.
                Click "England" to see it in action.
            </p>
        <cf:PublicFeed ID="F" runat="server" />
    </div>

</div>


</asp:Content>


