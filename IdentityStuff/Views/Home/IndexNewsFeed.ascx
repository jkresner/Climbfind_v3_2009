<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndexNewsFeed.ascx.cs" Inherits="IdentityStuff.Views.Home.IndexNewsFeed" %>
<%@ OutputCache Duration="3600" VaryByParam="None" %>

<div class="h1lookalike">Site news</div>                                     
<% foreach (MainNewsFeedItem item in LatestNews){ %><%= item.ItemHtml %><% } %>   

