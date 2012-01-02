<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="AboutFeedTags.aspx.cs" Inherits="IdentityStuff.Views.CFFeed.AboutFeedTags" %>
<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<h1>Feed tags</h1>

<p>Feed tags allow you to view feeds posts by specific topics or all topics in a certain category.</p>

<p>Here are explanations of all the different tags. Email us if you think we should add a new one:</p>

<% foreach (FeedTag tag in ClimbFind.Model.DataAccess.CFDataCache.AllFeedTags){  %>
    <div style="margin:0px 0px 5px 0px"><b><i>#<%= tag.Name %></i></b> (category <%= tag.Category %>) <br /><%= tag.Description %></div>

<% } %>
</asp:Content>
