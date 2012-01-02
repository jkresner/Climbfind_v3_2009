<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="PartnerWidget2.aspx.cs" Inherits="IdentityStuff.Views.Places.PartnerWidget2" %>
<html>
<head><title>Climbfind Partner Page for <%= place.Name %></title>
<meta name="robots" content="noindex, nofollow" /></head>  
<style type="text/css"><% if (Styles == null) { %>
    Body { font-size:11px }
    #page { width:420px }     
    #options { text-align:right;margin:10px 1px 2px 0px }     
    table { width:100%;font-size:11px }       
    td { vertical-align:top }       
    img { border:none }
    h1 { margin-bottom:0px } 
    h2 { font-style:italic;color:Gray;font-size:14px;margin:0px 0px 0px 0px } 
    label { float:right }
    #Posts tr td { border-top:solid 1px gray;padding:4px }
    #Posts tr td:first-child { width:110px }    
    #Posts img { margin:0px 3px 0px 0px }
<% } else { %><%= Styles.CSS %><% } %>    
</style> 
<body>

<div id="headings">
    <h1>Climbing activity at <a href="<%= place.ClimbfindUrl %>"><%= place.Name %></a></h1>
</div>
<a id="CFLogo" href="http://cf3.climbfind.com/" target="_blank"><img src="http://cf3.climbfind.com/images/site-partners/climbfind-logo-135x50.png" alt="Climbfind logo" /></a>
<div id="options">
 <%= Html.ActionLink<CFFeedController>(c => c.NewPost(place.ID), "Post to the Climbfind feed", new { target = "_blank" })%>
to add yourself to this list
  <br /><%= Html.ActionLink<PartnerCallsController>(c => c.Subscribe(place.FriendlyUrlLocation, place.FriendlyUrlName), "Subscribe", new { target = "_blank" })%> to stay up to date with activity @ <%= place.ShortName %> 
</div>

<% if (FeedPosts.Count > 0) { %>

<table id="Posts"><% foreach (ClimbFind.Model.Objects.Interfaces.IPartnerPageItem item in FeedPosts)
   { %><tr><td><img src="http://cf3.climbfind.com<%= item.User.ProfilePictureUrlMini %>" /></td>
    <td><b>
		<%= Html.ActionLink<ClimberProfilesController>(c => c.Detail(item.User.ID), Html.Encode(item.User.FullName), new { rel = "nofollow", target = "_blank" })%></b>
        <%= item.RenderHTMLPostTopDetailsForPartnerPage() %>        
        <%= item.RenderHTMLPostBodyForPartnerPage()%><%= item.RenderHTMLOptionsForPartnerPage()%>
    </td></tr><% } %>   
</table>
    
<% } else { %>
    <p>:( No one has posted anything for <%= place.Name %></p>
    <p>=> <%= Html.ActionLink<CFFeedController>(c=>c.NewPost(place.ID), "Post when you're climbing") %></p>
<% } %>

</body>
</html>