<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FilterGoTo.aspx.cs" Inherits="IdentityStuff.Views.Places.FilterGoTo" %><% foreach (Place p in ViewData.Model) { %>
<a href="<%= p.ClimbfindUrl %>" target="_blank"><img src="<%= p.FlagImageUrl2 %>" /> <%= p.Name %></a>    
<% } %>