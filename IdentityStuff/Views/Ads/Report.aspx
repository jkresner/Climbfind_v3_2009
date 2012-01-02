<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="IdentityStuff.Views.Ads.Report" %>
<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<h1>Ad reports for <%= Client.Name %></h1>

<b>Ads: </b>

<table>
<tbody>
<tr>
<th scope="col">SrcAdUnitID</th>
<th scope="col">Product</th>
<th scope="col">DateStart</th>
<th scope="col">DateEnd</th>
<th scope="col">Impressions</th>
<th scope="col">Clicks</th>
</tr>
<% foreach (Ad a in Ads) { %>
<tr>
    <td><%= a.SrcAdUnitID %></td>
    <td><a href="<%= a.DestinationPageUrl %>"><%= a.ProductName %></a> (Click to go to link)</td>
    <td><%= a.DateStart.ToCFDateString() %></td>
    <td><%= a.DateEnd.ToCFDateString()%></td>
    <td><%= a.Impressions %></td>    
    <td><%= AdClicks[a.ID].Count %></td>    

</tr>
<% } %>
<tr>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td><b><%= TotalImpressions %></b></td>
    <td><b><%= TotalClicks %></b></td>
</tr>

</tbody></table>



<b>Products: </b>

<% foreach (AdProduct p in Products) { %>
    <div><%= p.Name %></div>    
<% } %>


</asp:Content>
