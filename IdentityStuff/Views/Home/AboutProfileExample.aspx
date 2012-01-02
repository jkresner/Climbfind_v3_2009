<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/cf.Master" AutoEventWireup="true" CodeBehind="AboutProfileExample.aspx.cs" Inherits="IdentityStuff.Views.Home.AboutProfileExample" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<div class="vPageSecionTop">

<h1>Example Climbfind profile</h1>


<%= Html.RenderUserControl("~/Controls/ClimbFindProfileFull.ascx", Current)%>

</div>

<div class="vPageSection" style="margin:10px 0px 10px 0px"> 

    <h1>Places <%= Current.NickName %> Climbs</h1>

    <%= Html.RenderUserControl("~/Views/ClimberProfiles/PlacesIClimb.ascx", Current) %>

</div> 

<% if (!extendedProfile.IsEmpty)
   { %>

<div class="vPageSection"> 

    <h1>Extended profile</h1>
    
    <%= Html.RenderUserControl("~/Views/ClimberProfiles/ExtendedProfile.ascx", extendedProfile)%>

</div>   

<% } %>


    
</asp:Content>
