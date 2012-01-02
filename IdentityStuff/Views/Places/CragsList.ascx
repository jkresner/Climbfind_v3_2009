<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CragsList.ascx.cs" Inherits="IdentityStuff.Views.Places.CragsList" %>

<% foreach (OutdoorCrag crag in Crags) { %>
<span><b><%= Html.ActionLink<PlacesController>(c=>c.DetailCrag(place.FriendlyUrlLocation, place.FriendlyUrlName, crag.FriendlyUrlName), crag.Name) %></b> &nbsp &nbsp </span>
<% } %>
        
        
     <%--(<%= ((CragType)crag.Type).ToString() %>)   
     --%>   