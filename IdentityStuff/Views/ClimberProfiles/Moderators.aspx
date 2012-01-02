<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="Moderators.aspx.cs" Inherits="IdentityStuff.Views.ClimberProfiles.Moderators" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<div style="width:660px;float:left">
<div class="vPageSectionTop">
    <h1>Climbfind Moderators</h1>
     
    <p>Climbfind is nearly a year old! Our focus for the first 12 months was starting a world wide community. 
    We're stoked that we already have over 5000 members from around the globe.
    The site also currently has <%= ClimbFind.Model.DataAccess.CFDataCache.AllPlaces.Count %>
    community added climbing destinations
    categorised into <%= ClimbFind.Model.DataAccess.CFDataCache.AllAreaTags.Count %> 
    <a href="/Places">climbing areas</a> across         
    <%= (from c in ClimbFind.Model.DataAccess.CFDataCache.AllPlaces select c.CountryID).Distinct().Count() %>
     countries.
    
    In 2010 we will be switching our focus to concentrating our efforts on improving our list 
     of climbing locations. Our moderators 
    team will be responsible for ensuring that our content will be as available and accurate as possible.</p>

    <p>We are looking to form a '2010 Team' who are passionate about helping us build the most 
    comprehensive database of climbing locations on the internet. Being part of the team will entitle you to
    to some free climbing gear :)</p>
    
    <p>If you are interested in contributing an hour or so each week, please <b><a href="mailto:%63%6F%6E%74%61%63%74%40%63%6C%69%6D%62%66%69%6E%64%2E%63%6F%6D">email us</a></b> to find out more.</p>
    
</div>
</div>     

<div style="width:165px;float:right;margin:0px 20px 0px 0px">
    <%= CFAdControls.Ad("Home.TopRight", 32)%>
</div>


</asp:Content>
