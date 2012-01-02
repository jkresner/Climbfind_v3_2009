<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="IdentityStuff.Views.Shared.Header" %>

<div id="header-wrap">
<div id="header-content">	
	<a href="/" title="www.climbfind.com, find rock climbing partners"><img src="/images/ui/logo/climbfind-find-climbing-partner.png" alt="Climbfind logo" title="www.climbfind.com - Find a climbing partner" /></a>	
    <p><asp:LoginView ID="LoginView" runat="server">
            <AnonymousTemplate>Hey, don't forget to <a href="/login">sign in</a> or <a href="/join">join climbfind</a>!</AnonymousTemplate>
            <LoggedInTemplate>Welcome, <%= Page.User.Identity.Name %> [<%= Html.ActionLink<HomeController>(c=>c.Logout(), "sign out") %>]                </LoggedInTemplate>
        </asp:LoginView></p>
    
    <form action="/Search" method="post">
    <input type="text" id="searchstr" name="searchstr" style="width:115px" /><input type="submit" value="Find" style="border:none" /></form>            
                   
        <ul id="nav" style="color:#F3A251">
            <li><a href="/" title="Find climbing partners on Climbfind">Home</a></li>
            <li><a href="http://cf4.climbfind.com" style="color:#FFF3AD">CF2011</a></li>
			<li><span>Feed</span>
                <ul id="nav-feed">
                    <li><%= Html.ActionLink<CFFeedController>(c => c.NewPostPlace(), "Post to feed")%></li>
                    <% if (UserLoggedIn) { %>
                    <li><%= Html.ActionLink<HomeController>(c => c.HomepageSettings(), "Settings")%></li>
                    <li><%= Html.ActionLink<PartnerCallsController>(c => c.Notifications(), "Notifications")%></li>
<%--                <li><%= Html.ActionLink<CFFeedController>(c => c.ClimbersImWatching(), "I'm Watching")%></li>
                    <li><%= Html.ActionLink<CFFeedController>(c => c.ClimbersWatchingMe(), "Watching me")%></li>--%>
                    <% } %>
                </ul>
            </li>
            <li><span>Places</span>
                <ul id="nav-places">
                    <li><%= Html.ActionLink<PlacesController>(c => c.Indoor(), "Indoor climbing", new { title = "World map of indoor climbing places" })%></li>
                    <li><%= Html.ActionLink<PlacesController>(c => c.Outdoor(), "Outdoor climbing", new { title = "World map of outdoor climbing locations" })%></li>
                    <li><%= Html.ActionLink<PlacesController>(c => c.Index(), "Climbing areas", new { title = "Find indoor climbing gyms, outdoor climbing locations by area" })%></li>
                </ul>            
            </li>
            <li><span>ME</span>
                <ul id="nav-me">
                    <li><%= Html.ActionLink<ClimberProfilesController>(c=>c.Me(),"Profile") %></li>                
                    <li><%= Html.ActionLink<HomeController>(c=>c.Inbox(),"Inbox") %></li>
                    <% if (UserLoggedIn) { %>
                    <li><%= Html.ActionLink<HomeController>(c => c.Sent(), "Sent")%></li>
                    <li><%= Html.ActionLink<MediaController>(c => c.MyMovies(), "Movies")%></li><% } %>
                </ul>
            </li>
			<li><span>Community</span>
                <ul id="nav-community">
                    <li><a href="http://cf4.climbfind.com/team" target="_blank" title="International Rock Climbing Community">CF 2011 Team</a></li>                    
                </ul>   
            </li>
            <%-- <li><a href="/Feedback">Feedback</a></li>--%>
            <li><a href="/Help">Help</a></li>
            <li><a href="/About">About</a></li>     
        </ul>               

</div>
</div>

<script type="text/javascript" src="/js/jquery-1.3.1.min.js"></script>
<script type="text/javascript" src="/js/CF3.52.js"></script>

<hr id="header-close" />