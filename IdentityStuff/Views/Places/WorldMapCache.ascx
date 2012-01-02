<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WorldMapCache.ascx.cs" Inherits="IdentityStuff.Views.Places.WorldMapCache" %>
<%@ OutputCache Duration="13600" VaryByParam="None" %>

<div class="vPageSectionTop">

    <h1>World map of climbing gyms, walls & outdoor rock climbing</h1>

    <p style="margin:0px 0px 20px 0px;font-size:10px">
        Double click on the map to zoom in. Please 
        
        <img src="http://cf3.climbfind.com/images/UI/virtualEarth/cfpushpin.bmp" style="padding:0px;border:solid 0px white" alt="Indoor climbing location" />
        <b><%= Html.ActionLink<ModerateController>(c=>c.AddIndoorPlace(), "add your climbing gym") %></b>
        
        or <img src="http://cf3.climbfind.com/images/UI/virtualEarth/cfoutdoorpin.bmp" style="padding:0px;border:solid 0px white" alt="Outdoor climbing location" />
       <b><%= Html.ActionLink<ModerateController>(c=>c.AddOutdoorLocation(), "add outdoor climbing") %></b> if it's not on there already.
    </p>
    
    <%= MapBuilder.GenerateWorldPlaceMap("World-Climbing-Map", Places,
                             "VEMapStyle.Road", "VEDashboardSize.Tiny", "Map showing indoor rock climbing gyms and outdoor climbing location around the world")%>  
</div>


<div class="attentionDIV" style="margin-bottom:0px">Is something inaccurate? Please let us know by emailing us at 
        <a href="mailto:%63%6F%6E%74%61%63%74%40%63%6C%69%6D%62%66%69%6E%64%2E%63%6F%6D">&#99;&#111;&#110;&#116;&#97;&#99;&#116;&#64;&#99;&#108;&#105;&#109;&#98;&#102;&#105;&#110;&#100;&#46;&#99;&#111;&#109;</a>.
</div>
