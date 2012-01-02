<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="SeekingPartners.aspx.cs" Inherits="IdentityStuff.Views.Places.SeekingPartners" %>
<%@ Register TagName="AreaMapRight160x600" TagPrefix="Ad" Src="~/Controls/AdUnits/AreaMapRight160x600.ascx" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<div style="width:680px;float:left">

<div class="vPageSectionTop">
    
    <h1>Climbing activity @ <%= place.Name %></h1>

    <p>Climbfind is here to help you find a partner and meet other rock climbers at
    <a href="<%= place.ClimbfindUrl %>"><%= place.Name %></a>. 
    Below is a all the activity around people that are looking for <%= place.ShortName %> partners.</p>
    
    <p class="attentionDIV" style="margin-bottom:0px"> => 
    <b><%= Html.ActionLink<PartnerCallsController>(c=>c.Subscribe(place.FriendlyUrlLocation, place.FriendlyUrlName), "Subscribe to activity at " + place.Name) %></b> 
    and receive notification by email or RSS.</p>
</div>

<div class="vPageSection">   
    <% if (FeedPosts.Count > 0) { %>
        <%= Html.RenderUserControl("~/Views/CFFeed/FeedItemList.ascx", FeedPosts) %>
    <% } else { %>
        <p>:( No one has posted anything for <%= place.Name %></p>
        <p><b>Start the conversation!</b></p>
        <p>=> <%= Html.ActionLink<CFFeedController>(c=>c.NewPost(place.ID), "Post when you're climbing here") %></p>
        <p>=> <%= Html.ActionLink<MediaController>(c=>c.AddPlaceYouTube(place.ID), "Submit a movie of " + place.Name) %></p>
    <% } %>
</div>

</div>
<div style="width:165px;float:right;margin:-10px 15px 0px 0px">
    <Ad:AreaMapRight160x600 id="AreaAd" runat="server" />
    <br /><br /> 
 
    <Ad:Google160x600 ID="GoogleAds" runat="server" />
</div>

</asp:Content>
