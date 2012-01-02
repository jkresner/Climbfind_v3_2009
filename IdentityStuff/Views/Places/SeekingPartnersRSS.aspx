<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="SeekingPartnersRSS.aspx.cs" Inherits="IdentityStuff.Views.Places.SeekingPartnersRSS" %><?xml version="1.0"?>
<rss version="2.0">
   <channel>
      <title>Climbing partners at <%= place.Name %></title>
      <link>http://cf3.climbfind.com<%= Html.BuildUrlFromExpression<PlacesController>(c=>c.SeekingPartners(place.FriendlyUrlLocation, place.FriendlyUrlName)) %></link>
      <description>List of people looking for climbing partners at  <%= place.Name %>, <%= FlagList.GetCountryName((Nation)place.CountryID) %>.</description>
      <language>en-us</language>
      <pubDate><%= PubDate %> GMT</pubDate>
      <lastBuildDate><%= LastBuildDate %> GMT</lastBuildDate>
      <docs>http://blogs.law.harvard.edu/tech/rss</docs>
      <generator>Climbfind source code by Jonathon Kresner</generator>
      <managingEditor>contact@climbfind.com</managingEditor>
      <webMaster>contact@climbfind.com</webMaster><% if (CallsForPlace.Count > 0) { %><% foreach (PartnerCall call in CallsForPlace) { %>
        <item>
            <title><%= call.CreatorFullName %> wants to <%= call.GetClimbingTypesEnglsihString() %></title>
            <link>http://cf3.climbfind.com<%= Html.BuildUrlFromExpression<PlacesController>(c=>c.SeekingPartners(place.FriendlyUrlLocation, place.FriendlyUrlName)) %></link>
            <description><![CDATA[<b><a href="http://cf3.climbfind.com<%= Html.BuildUrlFromExpression<ClimberProfilesController>(c => c.Detail(call.CreatorUserID))%>"><%= call.CreatorFullName %></a></b> posted on <%= call.PostedDateTime.ToCFDateString() %>: <% if (!String.IsNullOrEmpty(call.Message)) { %> <%= call.Message%> <% } else { %> No message left <% } %> ... <a href="http://cf3.climbfind.com<%= Html.BuildUrlFromExpression<PartnerCallsController>(c => c.Reply(call.ID))%>">reply now</a>]]></description>
            <pubDate><%= call.PostedDateTime.ToString("ddd, dd MMM yyyy HH:mm:ss") %> GMT</pubDate>
            <guid>http://cf3.climbfind.com<%= Html.BuildUrlFromExpression<PartnerCallsController>(c=>c.Reply(call.ID)) %></guid>
        </item><% } } else { %>
        <item>
            <title>No one has posted a partner call for <%= place.Name %></title>
            <link>http://cf3.climbfind.com/post-an-ad-for-rock-climbing-partners</link>
            <description><![CDATA[<b>Please go to Climbfind and... <a href="http://cf3.climbfind.com/post-an-ad-for-rock-climbing-partners">post a partner call</a> to find climbing partners]]></description>
            <pubDate><%= DateTime.Now.ToString("ddd, dd MMM yyyy HH:mm:ss") %> GMT</pubDate>
            <guid>http://cf3.climbfind.com/post-an-ad-for-rock-climbing-partners</guid>
        </item><% } %>
   </channel>
</rss>