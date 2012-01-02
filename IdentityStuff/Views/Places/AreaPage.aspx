<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="AreaPage.aspx.cs" Inherits="IdentityStuff.Views.Places.AreaPage" %>
<%@ Register TagName="AreaMapRight160x600" TagPrefix="Ad" Src="~/Controls/AdUnits/AreaMapRight160x600.ascx" %>
<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<div class="vPageSectionTop" id="<%= MapDivID + "-DIV" %>">

<div style="width:690px;float:left">
    <h1>Map of climbing around <%= Area.ParagraphName %></h1>

    <p style="margin:0px 0px 20px 0px;font-size:10px">
        Double click to zoom, and move the mouse over the
        <img src="/images/UI/virtualEarth/cfpushpin.bmp" style="padding:0px;border:solid 0px white" alt="<%= Area.Name %> indoor climbing location" />
        <img src="/images/UI/virtualEarth/cfoutdoorpin.bmp" style="padding:0px;border:solid 0px white" alt="<%= Area.Name %> outdoor climbing location" />
         icons for details on climbing locations aroung <%= Area.ParagraphName %>.</p>

    <%= MapBuilder.GeneratePlaceMap(MapDivID, (double)Area.Latitude, (double)Area.Longitude, Area.DefaultVirtualEarthZoom,
        PlacesInThisArea, "VEMapStyle.Road", "VEDashboardSize.Normal", 680, 440, MapTitle) %>

    <hr />
    <div class="attentionDIV">Something inaccurate? <b><a href="mailto:%63%6F%6E%74%61%63%74%40%63%6C%69%6D%62%66%69%6E%64%2E%63%6F%6D">Email us</a></b> & let us know.</div>
</div>

<div style="width:165px;float:right;margin:-10px 15px 0px 0px">
    <Ad:AreaMapRight160x600 id="Ad" runat="server" />
</div>

  
</div>



<div id="AreaPageIndoorGymsDIV" class="vPageSection">

    <h1 style="margin-top:20px">Climbing gyms in <%= Area.ParagraphName %></h1>

    <% if (IndoorPlacesInThisArea.Count == 0)
       { %> <p>Climbfind does not know of any indoor rock climbing places around <%= Area.ParagraphName%>. If you know of some indoor climbing walls or rock climbing gyms <b><%= Html.ActionLink<ModerateController>(c => c.AddIndoorPlace(), "add indoor climbing")%></b> now.</p>
    <% } else { %>
    <% foreach (IndoorPlace place in IndoorPlacesInThisArea)
       { %> 
       <div><% if (DisplayPlaceImage) { %><a href="<%= place.ClimbfindUrl %>"><img src="<%= place.LogoImageUrl %>" /></a><% } %>                
            <p><b><a href="<%= place.ClimbfindUrl %>"><%= place.Name %></a></b>
            <br /><b>Address:</b> <%= place.Address%> <br /><b>Phone:</b> <%= place.Contact %></p></div>
    <% } }%>
</div>


<div id="AreaPageOutdoorLocationsDIV" class="vPageSection">

    <h1>Outdoor climbing around <%= Area.ParagraphName %></h1>

    <% if (OutdoorPlacesInThisArea.Count == 0)
       { %> <p>Climbfind does not know of any outdoor rock climbing around <%= Area.ParagraphName%>. If you know some outdoor climbing locations 
        <%= Html.ActionLink<ModerateController>(c=>c.AddOutdoorLocation(), "Add outdoor climbing") %> now.</p> 
       <% } else
       { %>

    <% foreach (OutdoorPlace place in OutdoorPlacesInThisArea)
       { %>
       
            <div><% if (DisplayPlaceImage) { %><div><a href="<%= place.ClimbfindUrl %>"><img src="<%= place.DescriptionImageUrl %>" alt="<%= place.Name.Replace(" ", "-") + "-Logo" %>" /></a></div><% } %>
                <p><b><%= Html.ActionLink<PlacesController>(c => c.DetailOutdoor(place.FriendlyUrlLocation, place.FriendlyUrlName), place.Name)%></b><br />                    
                    <% if (String.IsNullOrEmpty(place.Directions)) { %> We need info, <a href="/Moderate/EditOutdoorLocation/<%= place.ID %>">update directions</a> to <%= place.Name %>
                    <% } else { %><b>Directions:</b> <%= place.Directions.Take(300) %>... <% } %></p></div>                
       <% } %>
    <% } %>
</div>

<div class="vPageSection">

    <h1 style="margin-top:20px">Mountaineering clubs & climbing clubs around <%= Area.ParagraphName %></h1>

    <% if (ClubsInThisArea.Count == 0)
       { %> <p>Climbfind does not know of any rock climbing clubs in <%= Area.ParagraphName %>. If you know of a club, email us at <a href="mailto:%63%6F%6E%74%61%63%74%40%63%6C%69%6D%62%66%69%6E%64%2E%63%6F%6D">&#99;&#111;&#110;&#116;&#97;&#99;&#116;&#64;&#99;&#108;&#105;&#109;&#98;&#102;&#105;&#110;&#100;&#46;&#99;&#111;&#109;</a>!</p><% }
       else
       { %>
       
     <style type="text/css"> .SingleProfileInList { width:145px;margin-top:15px } </style>  
       
     <div>           
    <% foreach (Club club in ClubsInThisArea)
       { %>
       <div class="SingleProfileInList"><img src="<%= club.LogoMiniImageUrl %>" /><div><a href='<%= club.ClimbfindUrl %>'><%= club.Name %></a></div></div>
       <% } %> </div> <% }%>

</div>



<%= CFControls.OtherAreasInCountryCloud(this, (Nation)Area.CountryID)%>



</asp:Content>
