<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/cf.master" AutoEventWireup="true" CodeBehind="AreaTagList.aspx.cs" Inherits="ClimbFind.Web.Mvc.Views.Moderate.AreaTagList" %>


<asp:Content ID="Content2" ContentPlaceHolderID="m" runat="server">

<style>
    table td { vertical-align:top }
    table td img { border:none;padding:0px }
</style>

<h1>Area Tags</h1>


<table style="font-size:9px" class="NoStylesTable">

    <tr>
        <td style="width:30px"></td>
        <td style="width:190px"><b>Name</b></td>
        <td style="width:60px"><b>Is Country</b></td>
        <td></td>
    </tr>
    
<% int i = 1; foreach (AreaTag tag in Tags)
   { %>
    
    <tr>
        <td><%= i++ %></td>
        <td><img src="/images/ui/flags/<%= ClimbFind.Content.FlagList.GetFlag((Nation)tag.CountryID) %>" /> 
            <a href="<%= tag.ClimbfindUrl %>" target="_blank"><%= tag.Name %></a></td>
        <td>
        <%= tag.IsCountry %>            
       </td>
       <td>
            <%= Html.ActionLink<ModerateController>(c=>c.EditAreaTag(tag.ID), "edit") %>
       </td>
    </tr>


<% } %>

</table>


</asp:Content>
