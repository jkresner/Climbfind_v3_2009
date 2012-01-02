<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FeedItemList.ascx.cs" Inherits="IdentityStuff.Views.CFFeed.FeedItemList" %>

<% if (FeedItems.Count > 0)
   { %>
<ul id="FeedItems">

<% foreach (ClimbFind.Model.Objects.Interfaces.IFeedItem item in FeedItems) { %>
    <li> 
        <%= Html.ImagePreview(item.User.ProfilePictureUrlMini, item.User.ProfilePictureUrl, item.User.FullName) %>       
        <div>
            <i><%= CFControls.ClimberProfileLink(this, item.User) %></i>
            <span><%= item.PostedDateTime.GetAgoString()%></span>
            <%= item.RenderHTMLPostTopDetails() %>        
            <br />
            <%= item.RenderHTMLOptions() %>
        </div>   
        <%= item.RenderHTMLPostBody() %>
        <% if (item.Comments.Count > 0) { %><dl><% foreach (FeedPostComment c in item.Comments) { %>
            <dt><%= Html.ImagePreview(c.User.ProfilePictureUrlMini, c.User.ProfilePictureUrl, c.User.FullName)%></dt>
            <dd><%= CFControls.ClimberProfileLink(this, c.User) %> - <%= c.Message %>
            <% if ((c.UserID == UserID)) { %><a href="/CFFeed/DeletePostComment/<%= c.ID %>">delete</a><% } } %></dd>
        </dl><% } %>   
        <hr />
    </li><% } %>   
</ul> 

 <% } else  { %>
<div style="border-top:solid 1px #D3D3D3;clear:both"><p>:( No one has posted anything for the Channel/View combination you have selected.</p></div>
<%} %>