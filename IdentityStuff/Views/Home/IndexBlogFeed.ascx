<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndexBlogFeed.ascx.cs" Inherits="IdentityStuff.Views.Home.IndexBlogFeed" %>
<%@ OutputCache Duration="53600" VaryByParam="None" %>

<div id="BlogFeed">
    <h2>Latest blog posts</h2>                              
    <% foreach (CFUserSyndicationItem item in SyndicatedItems)
       { %>
    <div>
        <img src="<%= item.Owner.ProfilePictureUrlMini %>" style="width:40px;float:left" />        
        <div>
            <%= CFControls.ClimberProfileLink(this, item.Owner) %>
            <i>posted <%= item.PublishDate.ToString("dd MMM yyyy") %></i> 
            <a href="<%= item.Links.FirstOrDefault().Uri.ToString() %>" target="_blank"><b><%= item.Title.Text %></b></a>
        </div>
        <p><%= item.Blurb %> <a href="<%= item.Links.FirstOrDefault().Uri.ToString() %>" target="_blank">read full post</a></p>
    </div>
    <hr />
    <% } %>
</div>



