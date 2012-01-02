<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="UsersMedia.aspx.cs" Inherits="IdentityStuff.Views.Media.UsersMedia" %>


<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">


<div class="vPageSectionTop">
    <h1>Climbing movies submitted by <%= UserWithMedia.FullName %></h1>


    <% if (Media.Count == 0)
       {        
           if (!UserLoggedIn || UserID != UserWithMedia.ID)
           {
           %><p><%= UserWithMedia.FullName%> has not added any movies to climbfind. </p><% }
           else { %>       
            <p>You have not submitted any climbing movies to Climbfind :(</p>            
            <p>Get cracking! <b><%= Html.ActionLink<MediaController>(c=>c.SubmitMovie(), "Submit a climbing movie") %></b> 
            and share your passion for climbing with our community.</p>                 
        <% } } 
       else { %>
        <p class="attentionDIV" style="border:solid 1px brown;padding:4px;width:360px"><%= CFControls.AddThisBookmark(this, this.Request.RawUrl.ToString(), UserWithMedia.FullName + "'s climbing movies")%><a href="/climber-profile/<%= UserWithMedia.ID %>"><%= UserWithMedia.FullName%></a>'s movies</p>
    
        
    <br />

        <%= Html.RenderUserControl("~/Views/ClimberProfiles/MyMediaList.ascx", Media)%>  
    <% } %>

</div>

</asp:Content>
