<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PlacesIClimb.ascx.cs" Inherits="IdentityStuff.Views.ClimberProfiles.PlacesIClimb" %>

<h1>Indoor I've climbed</h1>       
<div id="ProfileIndoor">
    <% if (indoorPlaces.Count == 0) { %><i>None specified</i><% } else {
    foreach (Place place in indoorPlaces) { %>                        
    <img src="<%= ClimbFind.Model.DataAccess.CFDataCache.GetIndoorPlaceProp<string>(p=>p.LogoImageUrl, place.ID) %>" alt='<%= place.ShortName %>' />
    <a href="<%= place.ClimbfindUrl %>"><%= place.ShortName %></a>     
    <% } } %>
</div> 

<h1>Outdoor I've climbed</h1>
<div id="ProfileOutdoor">
    <% if (outdoorPlaces.Count == 0) { %><i>None specified</i><% } else {
    foreach (short countryID in countriesIClimb)
    { %>     
    <div>
        <img src="/images/ui/flags/<%= FlagList.GetFlag((Nation)countryID) %>" />
        <%= FlagList.GetCountryName((Nation)countryID) %>
        <div style="padding:5px"><%= getCountrysPlaceWhereUserClimbs(countryID) %></div>
    </div>
    <% } } %>
</div>
   
