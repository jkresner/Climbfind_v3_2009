<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OtherPlaceRegularsCloud.ascx.cs" Inherits="IdentityStuff.Views.Places.OtherPlaceRegularsCloud" %>

<% foreach (Place place in AllPlaces)
   { %>
      
       
      <%= Html.ActionLink<PlacesController>(c=>c.Regulars(place.FriendlyUrlLocation, place.FriendlyUrlName), place.Name) %> &nbsp

   <% } %>
   
 
  