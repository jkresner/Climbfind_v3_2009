<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OtherAreasInCountryCloud.ascx.cs" Inherits="IdentityStuff.Views.Places.OtherAreasInCountryCloud" %>

<% if (Areas.Count > 1) { %>

<div class="vPageSection">
    <h1>Other areas with climbing in <%= FlagList.GetCountryName((Nation)CurrentViewedArea.CountryID)%></h1>

    <div>

    <% foreach (AreaTag area in Areas) {
           if (area.ID != CurrentViewedArea.ID) { %>
            <% if (!area.IsCountry) { %><a href='<%= area.ClimbfindUrl %>'><%= area.Name%></a><% } else { %>
                <img src="<%= area.FlagImageUrl %>" /><b> <a href='<%= area.ClimbfindUrl %>'><%= area.Name%> (All)</a></b><% } %> &nbsp
     <% } } %>
       
    </div>   
</div>   
   
   
<% } %>
   
   