<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="FeatureArticles.aspx.cs" Inherits="IdentityStuff.Views.News.FeatureArticles" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<div class="vPageSectionTop">

    <h1>Feature Articles</h1>

    <p>We decided that this wasn't our strength. But we're going to leave these up anyway:</p>
    
    <ul> 
        <% foreach (FeatureArticle article in Articles)
           { %>
                <li><%= article.Date.ToString("dd MMM yyyy")%> 
                
                <b><%= Html.ActionLink<NewsController>(c => c.FeatureArticle(article.Date.ToString("yyyy-MM-dd"), article.FriendlyUrl), article.ArticleHeading, new { title = article.MetaDescription })%></b>
                    <br />By <%= article.ReportedBy %>
                
                </li>
        <% } %>
    
    </ul>

</div>

</asp:Content>

