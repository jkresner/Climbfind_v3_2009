<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="MainFeed.aspx.cs" Inherits="IdentityStuff.Views.News.MainFeed" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<div class="vPageSectionTop">

    <h1>Climbfind news feed</h1>

    <div id="NewsFeed">

        <% foreach (MainNewsFeedItem item in AllNews){ %><%= item.ItemHtml %><% } %>

    </div>
</div>

</asp:Content>

