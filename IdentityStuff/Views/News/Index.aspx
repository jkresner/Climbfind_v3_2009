<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="IdentityStuff.Views.News.Index" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">


<div class="vPageSectionTop">
    
    <h1>Latest news feed</h1>

    <div style="font-weight:bold;margin:0px 0px 15px 0px">    
        <%= Html.ActionLink<NewsController>(c => c.MainFeed(), "> View whole news feed")%>
    </div>





    <div id="NewsFeed">

        <% foreach (MainNewsFeedItem item in LatestNews){ %><%= item.ItemHtml %><% } %>

    </div>
    
</div>


</asp:Content>

