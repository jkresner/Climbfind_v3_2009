<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/cf.master" AutoEventWireup="true" CodeBehind="IndoorPlaceList.aspx.cs" Inherits="ClimbFind.Web.Mvc.Views.Moderate.IndoorPlaceList" %>


<asp:Content ID="Content2" ContentPlaceHolderID="m" runat="server">

<style type="text/css">
    table td { vertical-align:top }
    table td img { border:none;padding:0px }
</style>

<h1>Indoor Places</h1>

<table style="font-size:9px;width:100%" class="NoStylesTable">

    <tr>
        <td style="width:30px"></td>
        <td style="width:280px"><b>Name</b></td>
        <td style="width:120px"><b></b></td>
    </tr>
    
<% int j = 1; foreach (IndoorPlace ip in IndoorPlaces)
   { %>
    
    <tr>
        <td><%= j++ %></td>
        <td><img src="/images/ui/flags/<%= ClimbFind.Content.FlagList.GetFlag((Nation)ip.CountryID) %>" /> 
            <a href="<%= ip.ClimbfindUrl %>" target="_blank"><%= ip.Name%></a></td>
        <td><%= Html.ActionLink<ModerateController>(c=>c.EditIndoorPlace(ip.ID), "edit") %> - 
            <%= Html.ActionLink<ModerateController>(c=>c.EditIndoorPlaceLogo(ip.ID), "logo") %> -            
            <%= Html.ActionLink<ModerateController>(c=>c.EditPlaceMedia(ip.ID), "media") %> </td>
    </tr>


<% } %>

</table>

</asp:Content>
