<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="IdentityStuff.Views.Shared.Footer" %>

<div id="footer"><div id="footer-content">

	<div class="col">
	    <h2>Climbfind history</h2>
        <ul>             
            <li class="top"><a title="Climbfind news" href="/News">Climbfind news feed</a></li>
            <li style="margin-top:0px"><a href="/Media/UsersMedia/a9646cc3-18cb-4a62-8402-5263ba8b3476">Video walkthrough tours</a></li>           
            <li style="margin-top:0px"><a href="/News/FeatureArticles">Featured articles</a></li>
            <li style="margin-top:0px"><a href="/2009-Climbfind-USA-Canada-Road-Trip" title="Climbfind drives from Vancouver, Canada to Los Angeles, USA in 9 weeks">2009 Climbfind Canada/USA Road Trip</a></li>
            <li style="margin-top:0px"><a href="/2008-UK-Roadtrip" title="Climbfind visits 30 indoor climbing walls around England, Scotland & Wales in 7 days">2008 Climbfind UK Road Trip</a></li>
            <li style="margin-top:0px"><a href="/Competitions">Winter 2008/2009 UK comp coverage</a></li>
        </ul>
	</div>
				
	<div class="col">
        <h2>Climbing resources</h2>
		<ul>
			<li class="top"><%= Html.ActionLink<HomeController>(c => c.Glossary(), "Glossary")%></li>     				
            <li style="margin-top:0px"><%= Html.ActionLink<HomeController>(c => c.GradeConverter(), "Grade chart")%></li>     				
            <li style="margin-top:0px"><%= Html.ActionLink<PartnerCallsController>(c => c.ByPlace(), "Climbing partners", new { title = "Partners for rock climbing" })%></li>
            <li style="margin-top:0px"><%= Html.ActionLink<PlacesController>(c => c.WorldMap(), "World climbing map")%></li>    
		    <li style="margin-top:0px"><%= Html.ActionLink<ClubsController>(c => c.Index(), "Climbing & Mountaineering Clubs")%></li>     				
		</ul>							

        <h2>Site</h2>
		<ul>
			<li class="top"><%= Html.ActionLink<HomeController>(c => c.Feedback(), "Feedback")%></li>     				
			<li style="margin-top:0px"><%= Html.ActionLink<HomeController>(c => c.Promote(), "Promote")%></li>
			<li style="margin-top:0px"><%= Html.ActionLink<ModerateController>(c => c.Index(), "Moderators menu")%></li>
		</ul>
	</div>

	<div class="col2">
		<h2>About</h2>
		<p>Contact <a href="mailto:%63%6F%6E%74%61%63%74%40%63%6C%69%6D%62%66%69%6E%64%2E%63%6F%6D">&#99;&#111;&#110;&#116;&#97;&#99;&#116;&#64;&#99;&#108;&#105;&#109;&#98;&#102;&#105;&#110;&#100;&#46;&#99;&#111;&#109;</a></p>
		<p>&copy; copyright 2010 <a href="http://www.kresner.com">Jonathon Kresner</a></p>		
		<p>Site launched: 16 Oct 2008 <br />Last updated: 12 Nov 2010<br />Current version: v3.52</p>
		<p>Design modified from original by <a href="http://www.styleshout.com/">styleshout</a></p>				
	</div>
  
</div></div>

<div style="clear:both"></div>
        
<%--<% if (!ClimbFind.Controller.CFSettings.IsDevelopmentEnvironment) { %>
<script src="http://www.google-analytics.com/urchin.js" type="text/javascript"></script>           
<script type="text/javascript">
    _uacct = "UA-1693127-4";
    urchinTracker();
</script><% } %>--%>
           
