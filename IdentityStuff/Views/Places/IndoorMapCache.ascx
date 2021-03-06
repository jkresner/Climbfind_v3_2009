﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndoorMapCache.ascx.cs" Inherits="IdentityStuff.Views.Places.IndoorMapCache" %>
<%@ OutputCache Duration="13600" VaryByParam="None" %>

<div class="vPageSectionTop">

    <h1>World map of climbing gyms, rock climbing walls & indoor climbing centres</h1>

    <p style="margin:0px 0px 20px 0px;font-size:10px">
        Double click on the map to zoom in. Please 
        <img src="http://cf3.climbfind.com/images/UI/virtualEarth/cfpushpin.bmp" style="padding:0px;border:solid 0px white" alt="Indoor climbing location" />
        <b><%= Html.ActionLink<ModerateController>(c=>c.AddIndoorPlace(), "add your climbing gym") %></b>
        if it's not on there already.
    </p>
     
    <%= MapBuilder.GenerateWorldPlaceMap("World-Indoor-Climbing-Map", IndoorPlaces, "VEMapStyle.Road", "VEDashboardSize.Tiny", "Map of indoor climbing gyms, indoor climbing centres and climbing walls around the world")%>  

</div>


<div class="attentionDIV" style="margin-bottom:0px">Is something inaccurate? Please let us know by emailing us at 
        <a href="mailto:%63%6F%6E%74%61%63%74%40%63%6C%69%6D%62%66%69%6E%64%2E%63%6F%6D">&#99;&#111;&#110;&#116;&#97;&#99;&#116;&#64;&#99;&#108;&#105;&#109;&#98;&#102;&#105;&#110;&#100;&#46;&#99;&#111;&#109;</a>.
</div>
