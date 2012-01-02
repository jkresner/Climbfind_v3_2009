<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyMediaList.ascx.cs" Inherits="IdentityStuff.Views.ClimberProfiles.MyMediaList" %>
<% int j = 1;foreach (MediaShare media in Media) { %>
<dl class="Video">
    <dd><span><%= j++ %> of <%= Media.Count %>) <%= media.Name %></span>
            <p>Submitted  <%= media.SubmittedDateTime.ToString("dd MMM yy") %></p>
       <% if (UserOwnsMedia(media)) { %> - <%= Html.ActionLink<MediaController>(c => c.Delete(media.ID), "Delete")%> <% } %>
        </p>
      <p><%= media.Description %></p>
      <p><b>> <%= Html.ActionLink<MediaController>(c=>c.Detail(media.ID), "Comment on movie") %></b>
              
            <% List<FeedPostComment> comments = new ClimbFind.Controller.CFController().GetCommentsForMedia(media.MessageBoardID); %>
            <% if (comments.Count > 0) { %><div><% foreach (FeedPostComment c in comments) { %>
                <img src="<%= c.UserProfileImgUrl %>" />
                <p><%= CFControls.ClimberProfileLink(this, c.User) %> - <%= c.Message %>
                <% if (UserLoggedIn && (c.UserID == UserID)) { %><a href="/CFFeed/DeletePostComment/<%= c.ID %>">delete</a><% } %></p><% } %>
            </div><% } %>       
     </dd>
    <dt><%= media.RenderInBrowser() %></dt><hr />
</dl><% } %><div class="VideosEnd"></div>
    
    

