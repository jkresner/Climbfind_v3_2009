<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/cf.master" AutoEventWireup="true" CodeBehind="OutdoorCragList.aspx.cs" Inherits="ClimbFind.Web.Mvc.Views.Moderate.OutdoorCragList" %>


<asp:Content ID="Content2" ContentPlaceHolderID="m" runat="server">

<style type="text/css">
    table td { vertical-align:top }
    table td img { border:none;padding:0px }
</style>

<h1>Outdoor Crags</h1>


<table style="font-size:9px" class="NoStylesTable">

    <tr>
        <td style="width:30px"></td>
        <td style="width:390px"><b>Name</b></td>
        <td></td>
        <td></td>
    </tr>
    
<% int i = 1; foreach (OutdoorCrag crag in Crags)
   { %>
    
    <tr>
        <td><%= i++ %></td>
        <td> 
        <%--<img src="/images/ui/flags/<%= ClimbFind.Content.FlagList.GetFlag((Nation)crag.CountryID) %>" /> --%>
            <b><a href="<%= crag.ClimbfindUrl %>" target="_blank"><%= crag.Name %></a></b>, <%= crag.FriendlyUrlPlaceName %></td>
        <td></td>
        <td>
            <a href="/Moderate/DeleteOutdoorCrag/<%= crag.ID %>">delete</a>
        </td>
    </tr>


<% } %>

</table>


</asp:Content>
