<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/cf.master" AutoEventWireup="true" CodeBehind="OutdoorPlaceList.aspx.cs" Inherits="ClimbFind.Web.Mvc.Views.Moderate.OutdoorPlaceList" %>


<asp:Content ID="Content2" ContentPlaceHolderID="m" runat="server">

<style>
    table td { vertical-align:top }
    table td img { border:none;padding:0px }
</style>

<h1>Outdoor Places</h1>


<table style="font-size:9px" class="NoStylesTable">

    <tr>
        <td style="width:30px"></td>
        <td style="width:190px"><b>Name</b></td>
        <td></td>
    </tr>
    
<% int i = 1; foreach (OutdoorPlace op in OutdoorPlaces)
   { %>
    
    <tr>
        <td><%= i++ %></td>
        <td><img src="/images/ui/flags/<%= ClimbFind.Content.FlagList.GetFlag((Nation)op.CountryID) %>" /> 
            <a href="<%= op.ClimbfindUrl %>" target="_blank"><%= op.Name %></a></td>
        <td>
            
        </td>
    </tr>


<% } %>

</table>


</asp:Content>
