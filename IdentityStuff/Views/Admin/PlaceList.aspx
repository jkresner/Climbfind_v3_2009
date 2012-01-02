<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="PlaceList.aspx.cs" Inherits="ClimbFind.Web.Mvc.Views.Admin.PlaceList" %>
<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<style>
    table td { vertical-align:top;border-bottom:solid 1px #D3D3D3 }
    a { text-decoration:none } 
</style>


<div style="width:48%;float:left;margin:-20px 0px 0px 0px">

<h1>Indoor Places</h1>


<table style="font-size:10px;font-family:arial">

    <tr>
        <td style="width:30px"></td>
        <td style="width:280px"><b>Name</b></td>
        <td></td>
    </tr>
    
<% int j = 1; foreach (IndoorPlace ip in IndoorPlaces)
   { %>
    
    <tr>
        <td><%= j++ %></td>
        <td><img src="/images/ui/flags/<%= ClimbFind.Content.FlagList.GetFlag((Nation)ip.CountryID) %>" /> 
            <a href="<%= ip.ClimbfindUrl %>" target="_blank"><%= ip.Name%></a></td>
        <td>
            <a href="/Admin/DeleteIndoorPlaceCompletely/<%= ip.ID %>" style="color:Red">delete</a>   
        </td>
    </tr>


<% } %>

</table>


</div>


<div style="width:48%;float:right;margin:-20px 0px 0px 20px">

<h1>Outdoor Places</h1>


<table style="font-size:10px;font-family:arial">

    <tr>
        <td style="width:30px"></td>
        <td style="width:240px"><b>Name</b></td>
        <td></td>
    </tr>
    
<% int i = 1; foreach (OutdoorPlace op in OutdoorPlaces)
   { %>
    
    <tr>
        <td><%= i++ %></td>
        <td>
            <img src="/images/ui/flags/<%= ClimbFind.Content.FlagList.GetFlag((Nation)op.CountryID) %>" /> 
            <a href="<%= op.ClimbfindUrl %>" target="_blank"><%= op.Name %></td>
        <td>
            <a href="/Admin/DeleteOutdoorPlaceCompletely/<%= op.ID %>" style="color:Red">delete</a>   
        </td>
    </tr>


<% } %>

</table>

</div>



</asp:Content>
