<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndexCache.ascx.cs" Inherits="IdentityStuff.Views.Places.IndexCache" %>
<%@ OutputCache Duration="13600" VaryByParam="None" %>

<div id="PlacesDIV" class="vPageSectionTop divWithFlags">

<h1>Climbing (indoor / outdoor) by areas</h1>
           
<p style="font-size:9px;margin-bottom:15px"><b>Note</b>: This page is a continuous work in progress.
If you think we are missing a useful area category, please email us. </p>            
      
<div style="float:left;width:165px">
    <%= GetCountriesSetOfAreaPages(Nation.UnitedStates) %> 
</div>
<div style="float:left;width:175px">
    <%= GetCountriesSetOfAreaPages(Nation.England) %>
</div>
<div style="float:left;width:175px">
    <%= GetCountriesSetOfAreaPages(Nation.Canada) %>              
    <%= GetCountriesSetOfAreaPages(Nation.Australia) %>
</div>
<div style="float:left;width:185px">
    <% for (int i =0; i < countriesWithLocations.Count/2; i++) { %>
    <%= GetCountriesSetOfAreaPages((Nation)countriesWithLocations[i])%><% } %> 
</div>                
<div style="float:left;width:180px">
    <% for (int i = countriesWithLocations.Count / 2; i < countriesWithLocations.Count; i++){ %>
    <%= GetCountriesSetOfAreaPages((Nation)countriesWithLocations[i])%><% } %>            
</div>               

  
 
</div> 
 