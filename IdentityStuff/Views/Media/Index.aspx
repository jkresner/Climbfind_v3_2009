<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="IdentityStuff.Views.Media.Index" %>


<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<div class="vPageSectionTop">
<h1>Newest movies</h1>

<%
   int j = 1;
   foreach (MediaShare media in LatestMedia.Keys)
   { %>
    <div class="YouTubeMovieDIV">
        <div><b><%= j++ %> of 15: <%= media.Name %></b>
        
        - <%= Html.ActionLink<MediaController>(c=>c.Detail(media.ID), "Comment") %>
        
        <div style="font-size:9px">Submitted by 
        <%= CFControls.ClimberProfileLink(this, ClimbFind.Model.DataAccess.CFDataCache.GetClimberFromCache(media.SubmittedByUserID)) %>
        on <%= media.SubmittedDateTime.ToCFDateAndTimeString() %></div>
        </div>
        
        <p><%= media.Description %></p>
        <br /><%= media.RenderInBrowser() %>
    </div>
<% } %>
    
    
</div>


<%--<div class="vPageSection">
    <h1>Highest rated media</h1>
</div>


<div class="vPageSection">
    <h1>Your media</h1>



</div>

--%>

</asp:Content>
