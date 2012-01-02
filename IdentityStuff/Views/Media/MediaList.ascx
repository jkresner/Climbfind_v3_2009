<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MediaList.ascx.cs" Inherits="IdentityStuff.Views.Places.MediaList" %>
<% if (Media.Count > 0) { %>
<% int j = 1;foreach (MediaShare media in MediaByDateSubmitted) { %>
<dl class="Video">
    <dd><span><%= j++ %> of <%= Media.Count %>) <%= media.Name %></span>
            <p>Submitted  <%= media.SubmittedDateTime.ToString("dd MMM yy") %> by 
            <%= CFControls.ClimberProfileLink(this, ClimbFind.Model.DataAccess.CFDataCache.GetClimberFromCache(media.SubmittedByUserID)) %></p>
       <p><b><%= Html.ActionLink<MediaController>(c=>c.Detail(media.ID), "Comment") %></b></p>
      <p><%= media.Description %></p></dd>
    <dt><%= media.RenderInBrowser() %></dt><hr />
</dl><% } %><div class="VideosEnd"></div><%}    else
   { %>No media for this page yet. <% } %>