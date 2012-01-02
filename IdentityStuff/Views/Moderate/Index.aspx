<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="IdentityStuff.Views.Moderate.Index" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<h1>Moderators menu</h1>


<b>Indoor</b>
<ul>
    <li>- <%= Html.ActionLink<ModerateController>(c=>c.IndoorPlaceList(), "View all indoor places") %></li>
    <li>- <%= Html.ActionLink<ModerateController>(c=>c.AddIndoorPlace(), "Add new indoor place") %></li>
</ul>


<b>Outdoor</b>
<ul>
    <li>- <%= Html.ActionLink<ModerateController>(c=>c.OutdoorPlaceList(), "View all outdoor locations") %></li>
    <li>- <%= Html.ActionLink<ModerateController>(c=>c.OutdoorCragList(), "View all outdoor crags") %></li>
    <li>- <%= Html.ActionLink<ModerateController>(c=>c.AddOutdoorLocation(), "Add new outdoor location") %></li>
</ul>


<% if (UserIsModerator) { %>

<b>Area tags</b>

<p style="font-size:10px">Area tags are Climbfind's way of categorising gyms, crags & clubs by areas so people can find information specific to a certain geography.
After creating a gym/crag etc, area tags must be assigned so that it appears on the relevant area pages. For example if you add a gym that is in London,
you would want it to appear on the climbing around 'United Kingdom', 'England' & 'London' pages.</p>

<ul>
    <li>- <%= Html.ActionLink<ModerateController>(c=>c.AreaTagList(), "View all area tags") %></li>
    <li>- <%= Html.ActionLink<ModerateController>(c=>c.AddAreaTag(), "Add new area tag") %></li>
</ul>


<% } %>

</asp:Content>
